using DryIoc;
using log4net;
using System.Windows.Forms;
using TransactSqlAnalyzer.Core;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Utils;
using TransactSqlAnalyzer.WinForms;

namespace TransactSqlAnalyzer.Config.WinForms
{
    public partial class EditRuleForm : Form
    {
        private ILog Logger { get; } = LogManager.GetLogger(typeof(EditRuleForm));

        public EditRuleForm()
        {
            InitializeComponent();
        }

        public bool EditRule(IRule rule, IWin32Window owner)
        {
            Check.NotNull(rule, nameof(rule));

            labelRuleType.Text = $"Rule type: {rule.GetType().Name}";
            if (rule is IRuleWithConfiguration<ISpecificConfiguration>)
            {
                labelRuleType.Text = $"Rule type: {rule.GetType().Name}, with specific configuration";
            }

            // resolve control for general config
            var configControl = IocContainer.Instance.Resolve<IWinFormsRuleConfigurationControl>(IfUnresolved.Throw);
            var guiControl = configControl.CreateConfigControl();
            tableLayoutPanel.Controls.Add(guiControl);
            tableLayoutPanel.SetRow(guiControl, 1);
            configControl.FillControl(rule.Configuration);

            // if rulewithconfig: resolve control for specific config
            var specificRule = rule as IRuleWithConfiguration<ISpecificConfiguration>;
            IWinFormsSpecificConfigControl typedControl = null;
            if (specificRule != null)
            {
                var configType = specificRule.SpecificConfiguration.GetType();
                var controlType = typeof(IWinFormsSpecificConfigControl<>).MakeGenericType(configType);
                var specificControl = IocContainer.Instance.Resolve(controlType, IfUnresolved.ReturnDefault);

                if (specificControl == null)
                {
                    Logger.Warn($"Unable to resolve configuration control for rule type '{rule.GetType().FullName}'. Expected a control of type '{controlType.GetType().FullName}'.");
                }
                else
                {
                    // Todo possible? var typedControl = (IWinformsConfigControl<SelectAsteriskRuleConfig>)specificControl;
                    typedControl = (IWinFormsSpecificConfigControl)specificControl;

                    // Todo improve GUI (dock/scrolling, ...)
                    var specificGuiControl = typedControl.CreateConfigControl();
                    var specificGuiControlPanel = new Panel();
                    specificGuiControlPanel.Size = new System.Drawing.Size(300, 245);
                    specificGuiControlPanel.AutoScroll = true;
                    specificGuiControlPanel.Controls.Add(specificGuiControl);
                    specificGuiControl.Dock = DockStyle.Fill;

                    tableLayoutPanel.Controls.Add(specificGuiControlPanel);
                    tableLayoutPanel.SetRow(specificGuiControlPanel, 2);
                    specificGuiControlPanel.Dock = DockStyle.Fill;

                    typedControl.FillControl(specificRule.SpecificConfiguration);
                }
            }

            var isModified = this.ShowDialog(owner) == DialogResult.OK;

            if (isModified)
            {
                configControl.FillModel(rule.Configuration);
                if (specificRule != null && typedControl != null)
                {
                    typedControl.FillModel(specificRule.SpecificConfiguration);
                }
            }

            return isModified;
        }
    }
}
