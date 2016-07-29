using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Linq;
using System.Windows.Forms;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Utils;
using TransactSqlAnalyzer.WinForms;

namespace TransactSqlAnalyzer.Config.WinForms
{
    public partial class RuleConfigurationControl : UserControl, IWinFormsRuleConfigurationControl
    {
        private const string NullVersion = "(none)";

        public RuleConfigurationControl()
        {
            InitializeComponent();

            var sqlVersionHelper = new SqlVersionHelper();
            var versions = Enum.GetNames(typeof(SqlVersion));
            var sortedVersions = versions.OrderBy(x => sqlVersionHelper.GetVersion((SqlVersion)Enum.Parse(typeof(SqlVersion), x))).ToArray();

            comboBoxMinSqlVersion.Items.Clear();
            comboBoxMinSqlVersion.Items.Add(NullVersion);
            comboBoxMinSqlVersion.Items.AddRange(sortedVersions);

            comboBoxMaxSqlVersion.Items.Clear();
            comboBoxMaxSqlVersion.Items.Add(NullVersion);
            comboBoxMaxSqlVersion.Items.AddRange(sortedVersions);
        }

        // Todo improve, eg. work with binding, ...

        public void FillModel(RuleConfiguration config)
        {
            config.IsRuleEnabled = checkBoxIsEnabled.Checked;
            if (radioButtonError.Checked)
            {
                config.Severity = MessageSeverity.Error;
            }
            else if (radioButtonWarning.Checked)
            {
                config.Severity = MessageSeverity.Warning;
            }
            else if (radioButtonInfo.Checked)
            {
                config.Severity = MessageSeverity.Info;
            }
            else
            {
                throw new NotSupportedException("Unknown severity.");
            }

            config.FriendlyName = textBoxFriendlyName.Text;
            config.Category = textBoxCategory.Text;
            config.Description = textBoxDescription.Text;

            // Todo validate min <= max
            if (comboBoxMinSqlVersion.Text == NullVersion)
            {
                config.SupportedSqlVersions.MinSqlVersion = null;
            }
            else
            {
                config.SupportedSqlVersions.MinSqlVersion = (SqlVersion)Enum.Parse(typeof(SqlVersion), comboBoxMinSqlVersion.Text);
            }

            if (comboBoxMaxSqlVersion.Text == NullVersion)
            {
                config.SupportedSqlVersions.MaxSqlVersion = null;
            }
            else
            {
                config.SupportedSqlVersions.MaxSqlVersion = (SqlVersion)Enum.Parse(typeof(SqlVersion), comboBoxMaxSqlVersion.Text);
            }
        }

        public void FillControl(RuleConfiguration config)
        {
            checkBoxIsEnabled.Checked = config.IsRuleEnabled;
            radioButtonError.Checked = config.Severity == MessageSeverity.Error;
            radioButtonWarning.Checked = config.Severity == MessageSeverity.Warning;
            radioButtonInfo.Checked = config.Severity == MessageSeverity.Info;
            textBoxFriendlyName.Text = config.FriendlyName;
            textBoxCategory.Text = config.Category;
            textBoxDescription.Text = config.Description;
            comboBoxMinSqlVersion.Text = config.SupportedSqlVersions.MinSqlVersion?.ToString() ?? NullVersion;
            comboBoxMaxSqlVersion.Text = config.SupportedSqlVersions.MaxSqlVersion?.ToString() ?? NullVersion;
        }

        public UserControl CreateConfigControl()
        {
            return this;
        }
    }
}
