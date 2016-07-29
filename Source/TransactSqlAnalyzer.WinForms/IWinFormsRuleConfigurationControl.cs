using System.Windows.Forms;
using TransactSqlAnalyzer.Rules.Common;

namespace TransactSqlAnalyzer.WinForms
{
    /// <summary>
    /// Provides a GUI control for editing the general <see cref="RuleConfiguration"/>.
    /// </summary>
    public interface IWinFormsRuleConfigurationControl
    {
        UserControl CreateConfigControl();
        void FillModel(RuleConfiguration configuration);
        void FillControl(RuleConfiguration configuration);
    }
}
