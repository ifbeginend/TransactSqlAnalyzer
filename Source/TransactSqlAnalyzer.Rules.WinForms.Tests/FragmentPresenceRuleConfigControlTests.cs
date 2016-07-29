
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactSqlAnalyzer.Rules;
using TransactSqlAnalyzer.Rules.WinForms;

namespace TransactSqlAnalyzer.Rules.WinForms.Tests
{
    [TestClass]
    public class FragmentPresenceRuleConfigControlTests
    {
        // Todo Meaningful tests

        [TestMethod]
        public void FragmentPresenceRuleConfigControl_AcceptsSpecificConfiguration()
        {
            // Arrange
            var guiControl = new FragmentPresenceRuleConfigControl();
            var rule = new FragmentPresenceRule();

            // Act
            guiControl.FillControl(rule.SpecificConfiguration);
            guiControl.FillModel(rule.SpecificConfiguration);

            // Assert
        }
    }
}
