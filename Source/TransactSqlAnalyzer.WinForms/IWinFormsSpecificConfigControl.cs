using System.Windows.Forms;
using TransactSqlAnalyzer.Rules.Common;

namespace TransactSqlAnalyzer.WinForms
{
    /// <summary>
    /// Provides a GUI control for editing a specific rule configuration.
    /// </summary>
    public interface IWinFormsSpecificConfigControl
    {
        UserControl CreateConfigControl();
        void FillModel(ISpecificConfiguration configuration);
        void FillControl(ISpecificConfiguration configuration);
    }

    /// <summary>
    /// Links the GUI control to a specific rule configuration
    /// </summary>
    public interface IWinFormsSpecificConfigControl<T> : IWinFormsSpecificConfigControl
        where T : ISpecificConfiguration
    {
        // Todo improvement possible? Would be nice, but doesn't work...
        //void FillModel(T configuration);
        //void FillControl(T configuration);
    }
}
