using DryIoc;
using log4net;
using log4net.Core;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransactSqlAnalyzer.Core;
using TransactSqlAnalyzer.Core.Services;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Services;
using TransactSqlAnalyzer.Rules.Common.Utils;

namespace TransactSqlAnalyzer.Gui
{
    public partial class MainForm : Form
    {
        private const string ConfigFileDialogFilter = "Rule configuration files (*.ruleconfig)|*.ruleconfig|All files (*.*)|*.*";
        private const string ScriptFileDialogFilter = "Sql files (*.sql)|*.sql|All files (*.*)|*.*";

        private ILog Logger { get; } = LogManager.GetLogger(typeof(MainForm));
        private Lazy<IRule> debugVisitorRule;

        public MainForm()
        {
            InitializeComponent();

            debugVisitorRule = new Lazy<IRule>(CreateAndInstantiateDebugVisitor);

            Logger.RegisterEventingAppender(LogMessage, Level.Info);

            checkBoxInitialQuotedIdentifiers.Checked = false;
            comboBoxSqlVersion.Items.AddRange(Enum.GetNames(typeof(SqlVersion)));
            comboBoxSqlVersion.SelectedIndex = comboBoxSqlVersion.Items.Count - 1;
        }

        private SqlVersion SelectedSqlVersion
        {
            get
            {
                var sqlVersion = (SqlVersion)Enum.Parse(typeof(SqlVersion), (string)comboBoxSqlVersion.SelectedItem);
                return sqlVersion;
            }
        }

        private void buttonSelectConfigFile_Click(object sender, EventArgs e)
        {
            Logger.AssistedExecute(() =>
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.Filter = ConfigFileDialogFilter;
                    openFileDialog.Multiselect = false;
                    openFileDialog.Title = "Load rule configuration";

                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        textBoxConfigFile.Text = openFileDialog.FileName;
                    }
                }
            });
        }

        private void buttonLoadSqlScript_Click(object sender, EventArgs e)
        {
            Logger.AssistedExecute(() =>
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.Filter = ScriptFileDialogFilter;
                    openFileDialog.Multiselect = false;
                    openFileDialog.Title = "Load SQL script";

                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        textBoxSqlScript.Text = File.ReadAllText(openFileDialog.FileName);
                    }
                }
            });
        }

        private void buttonShowVisits_Click(object sender, EventArgs e)
        {
            Logger.AssistedExecute(() =>
            {
                textBoxResult.Clear();

                RegisterServices();
                var analyzer = IocContainer.Instance.Resolve<IAnalyzerServices>();
                var script = analyzer.Parse(textBoxSqlScript.Text);

                var rules = new[] { debugVisitorRule.Value };
                var allRuleResults = analyzer.EvaluateRules(textBoxSqlScript.Text, script, SelectedSqlVersion, rules);

                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine();

                allRuleResults.ToList().ForEach(x =>
                {
                    stringBuilder.AppendLine(analyzer.GetRuleResultSummary(script, x));
                    if (checkBoxVerbose.Checked)
                    {
                        stringBuilder.AppendLine(analyzer.GetFragmentOrTokenText(script, x));
                        stringBuilder.AppendLine();
                    }
                });
                stringBuilder.AppendLine();
                textBoxResult.AppendText(stringBuilder.ToString());
            }, 
            measureTime: true);
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            Logger.AssistedExecute(() =>
            {
                textBoxResult.Clear();

                SetupAnalyzer(SelectedSqlVersion, checkBoxInitialQuotedIdentifiers.Checked);

                var configServices = IocContainer.Instance.Resolve<IConfigurationServices>();
                var configuredRules = configServices.CreateConfiguredRules(textBoxConfigFile.Text).ToList();

                var analyzer = IocContainer.Instance.Resolve<IAnalyzerServices>();
                var script = analyzer.Parse(textBoxSqlScript.Text);

                var allRuleResults = analyzer.EvaluateRules(textBoxSqlScript.Text, script, SelectedSqlVersion, configuredRules);

                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine();
                allRuleResults.ToList().ForEach(x =>
                {
                    stringBuilder.AppendLine(analyzer.GetRuleResultSummary(script, x));
                    if (checkBoxVerbose.Checked)
                    {
                        stringBuilder.AppendLine(analyzer.GetFragmentOrTokenText(script, x) + Environment.NewLine);
                    }
                });
                stringBuilder.AppendLine();
                textBoxResult.AppendText(stringBuilder.ToString());
            }, 
            measureTime: true);
        }

        private IRule CreateAndInstantiateDebugVisitor()
        {
            Logger.Info("Generating and compiling debug visitor, please wait...");
            var debugRule = new DebugVisitorRuleGenerator().CompileAndCreateDebugVisitor();
            debugRule.Configuration.FriendlyName = "DebugVisitor";
            debugRule.Configuration.Severity = MessageSeverity.Info;
            debugRule.Configuration.IsRuleEnabled = true;
            debugRule.Configuration.Category = "Debug";
            debugRule.Configuration.Description = "Reports every implicit and explicit TSql fragment visit.";
            return debugRule;
        }

        private void LogMessage(LoggingEvent logInfo)
        {
            if (textBoxResult.InvokeRequired)
            {
                Invoke(new MethodInvoker(() => LogMessage(logInfo)));
            }
            else
            {
                textBoxResult.AppendText($"{logInfo.Level}  {logInfo.RenderedMessage}{Environment.NewLine}");
                if (logInfo.ExceptionObject != null)
                {
                    textBoxResult.AppendText($"{logInfo.ExceptionObject}{Environment.NewLine}");
                }
            }
        }

        private Registrations RegisterServices()
        {
            var registrations = new Registrations();
            // Todo :-(  improve design...
            registrations.Reset();
            var sqlVersion = (SqlVersion)Enum.Parse(typeof(SqlVersion), (string)comboBoxSqlVersion.SelectedItem);
            registrations.RegisterServices(sqlVersion, checkBoxInitialQuotedIdentifiers.Checked);
            return registrations;
        }

        private void SetupAnalyzer(SqlVersion sqlVersion, bool initialQuotedIdentifiers)
        {
            var registrations = RegisterServices();

            Logger.Info("Plugins:");
            var pluginLoader = IocContainer.Instance.Resolve<IPluginLoaderService>();
            var pluginLoadResults = pluginLoader.LoadPlugins();
            foreach (var pluginLoadResult in pluginLoadResults)
            {
                if (pluginLoadResult.SuccessfullyLoaded)
                {
                    Logger.Info($"  Assembly: {pluginLoadResult.AssemblyFullName}");
                    Logger.Info($"  Name: {pluginLoadResult.PluginServices.Information.Name}, Description: {pluginLoadResult.PluginServices.Information.Description}");
                    var ruleTypes = pluginLoadResult.PluginServices.GetRuleTypes();
                    Logger.Info($"  {ruleTypes.Count} Ruletypes: {string.Join(", ", ruleTypes)}");
                    registrations.RegisterRuleTypes(ruleTypes);

                    var configControlTypes = pluginLoadResult.PluginServices.GetConfigControlTypes();
                    registrations.RegisterConfigControlTypes(configControlTypes);
                }
                foreach (var loadMessage in pluginLoadResult.LoadMessages)
                {
                    Logger.Info($"  Message:{loadMessage.Severity} {loadMessage.Message}");
                }
            }

            if (!pluginLoadResults.Any(x => x.SuccessfullyLoaded))
            {
                Logger.Warn("No rule plugins found in base directory.");
            }

            IocContainer.Instance.VerifyResolutions();
        }
    }
}
