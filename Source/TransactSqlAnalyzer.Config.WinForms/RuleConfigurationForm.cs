using DryIoc;
using log4net;
using log4net.Core;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TransactSqlAnalyzer.Core;
using TransactSqlAnalyzer.Core.Services;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.WinForms;

namespace TransactSqlAnalyzer.Config.WinForms
{
    /// <summary>
    /// Crude GUI for editing analyzer configurations.
    /// </summary>
    public partial class RuleConfigurationForm : Form
    {
        private ILog Logger { get; } = LogManager.GetLogger(typeof(RuleConfigurationForm));

        private const string FileDialogFilter = "Rule configuration files (*.ruleconfig)|*.ruleconfig|All files (*.*)|*.*";
        private List<IRule> configuredRules = new List<IRule>();
        private string fileName;

        public RuleConfigurationForm()
        {
            InitializeComponent();

            Logger.RegisterEventingAppender(LogMessage, Level.Warn);

            RegisterServicesAndPlugins();
            InitAvailableRules();
            UpdateButtons();
        }

        private void LogMessage(LoggingEvent logInfo)
        {
            var message = $"{logInfo.Level}: {logInfo.RenderedMessage}{Environment.NewLine}{logInfo.ExceptionObject?.ToString()}";
            MessageBox.Show(this, message, "Rule configuration");
        }

        public void UpdateButtons()
        {
            buttonAdd.Enabled = treeViewAvailableRuleTypes.Nodes.Count > 0 && treeViewAvailableRuleTypes.SelectedNode != null;
            buttonLoadConfig.Enabled = true;
            buttonRemove.Enabled = listViewConfiguredRules.SelectedIndices.Count > 0;
            buttonConfigure.Enabled = listViewConfiguredRules.SelectedIndices.Count == 1;
            buttonSaveConfig.Enabled = true;
        }

        private void RegisterServicesAndPlugins()
        {
            var registrations = new Registrations();

            // (don't care about sql version for rule configuration)
            registrations.RegisterServices(SqlVersion.Sql120, false);

            var pluginLoader = IocContainer.Instance.Resolve<IPluginLoaderService>();
            var pluginLoadResults = pluginLoader.LoadPlugins();
            foreach (var pluginLoadResult in pluginLoadResults)
            {
                if (pluginLoadResult.SuccessfullyLoaded)
                {
                    var ruleTypes = pluginLoadResult.PluginServices.GetRuleTypes();
                    registrations.RegisterRuleTypes(ruleTypes);

                    var configControlTypes = pluginLoadResult.PluginServices.GetConfigControlTypes();
                    registrations.RegisterConfigControlTypes(configControlTypes);
                }
            }
            IocContainer.Instance.VerifyResolutions();

            // Todo improve...
            IocContainer.Instance.Register<IWinFormsRuleConfigurationControl, RuleConfigurationControl>(setup: Setup.With(allowDisposableTransient: true));
        }

        private void InitAvailableRules()
        {
            // init controls
            treeViewAvailableRuleTypes.Nodes.Clear();
            labelAvailableRuleTypeInfo.Text = string.Empty;

            // left: get all rule types and add to available rules
            var rules = IocContainer.Instance.ResolveMany<IRule>();
            foreach (var rule in rules)
            {
                TreeNode node = new TreeNode();
                node.Text = rule.GetType().Name;
                node.Tag = rule;
                treeViewAvailableRuleTypes.Nodes.Add(node);
            }
            treeViewAvailableRuleTypes.Sort();
            treeViewAvailableRuleTypes.SelectedNode = treeViewAvailableRuleTypes.Nodes.Count > 0 ? treeViewAvailableRuleTypes.Nodes[0] : null;
        }

        private void UpdateListView()
        {
            listViewConfiguredRules.Items.Clear();
            foreach (var configuredRule in configuredRules)
            {
                ListViewItem item = new ListViewItem(configuredRule.GetType().Name);
                item.Checked = configuredRule.Configuration.IsRuleEnabled;
                item.SubItems.Add(item.Checked ? "Enabled" : "Disabled");
                item.SubItems.Add(configuredRule.Configuration.Severity.ToString());
                item.SubItems.Add(configuredRule.Configuration.Category);
                item.SubItems.Add(configuredRule.Configuration.FriendlyName);
                item.SubItems.Add(configuredRule.Configuration.Description);
                item.SubItems.Add(configuredRule.Configuration.SupportedSqlVersions.MinSqlVersion?.ToString() ?? "");
                item.SubItems.Add(configuredRule.Configuration.SupportedSqlVersions.MaxSqlVersion?.ToString() ?? "");
                item.Tag = configuredRule;
                listViewConfiguredRules.Items.Add(item);
            }
            UpdateButtons();
        }

        private void treeViewAvailableRules_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var rule = e.Node.Tag as IRule;
            labelAvailableRuleTypeInfo.Text = $"{rule.GetType().Name}: {Environment.NewLine}{rule.RuleTypeDescription}";
            UpdateButtons();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (treeViewAvailableRuleTypes.SelectedNode != null)
            {
                IRule availableRule = (IRule)treeViewAvailableRuleTypes.SelectedNode.Tag;
                var newRule = (IRule)IocContainer.Instance.Resolve(availableRule.GetType());
                configuredRules.Add(newRule);
                UpdateListView();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listViewConfiguredRules.SelectedItems)
            {
                configuredRules.Remove((IRule)selectedItem.Tag);
            }
            UpdateListView();
        }

        private void listViewConfiguredRules_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            UpdateButtons();
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            EditSelectedRule();
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = FileDialogFilter;
                saveFileDialog.DefaultExt = ".ruleconfig";
                saveFileDialog.AddExtension = true;
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.SupportMultiDottedExtensions = true;
                saveFileDialog.ValidateNames = true;
                saveFileDialog.Title = "Save rule configuration";
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    saveFileDialog.FileName = fileName;
                }

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    var configServices = IocContainer.Instance.Resolve<IConfigurationServices>();
                    configServices.StoreConfiguration(configuredRules, saveFileDialog.FileName);
                    UpdateButtons();
                }
            }
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.Filter = FileDialogFilter;
                openFileDialog.Multiselect = false;
                openFileDialog.Title = "Load rule configuration";

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    Text = $"Rule configuration - {fileName}";

                    var configServices = IocContainer.Instance.Resolve<IConfigurationServices>();
                    configuredRules = configServices.CreateConfiguredRules(fileName).ToList();
                    UpdateListView();
                }
            }
        }

        private void listViewConfiguredRules_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedRule();
        }

        private void EditSelectedRule()
        {
            var selectedRule = (IRule)listViewConfiguredRules.SelectedItems[0].Tag;
            using (var editRuleForm = new EditRuleForm())
            {
                var isRuleModified = editRuleForm.EditRule(selectedRule, this);
                if (isRuleModified)
                {
                    UpdateListView();
                }
            }
        }
    }
}
