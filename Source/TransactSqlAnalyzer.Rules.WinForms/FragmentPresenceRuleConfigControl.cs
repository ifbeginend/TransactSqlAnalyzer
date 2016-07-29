using System;
using System.Linq;
using System.Windows.Forms;
using TransactSqlAnalyzer.Rules.Common;
using TransactSqlAnalyzer.Rules.Common.Utils;
using TransactSqlAnalyzer.WinForms;

namespace TransactSqlAnalyzer.Rules.WinForms
{
    public partial class FragmentPresenceRuleConfigControl : UserControl, IWinFormsSpecificConfigControl<FragmentPresenceRuleConfig>
    {
        private SqlFragmentTypeList currentlySelectedFragmentTypes = new SqlFragmentTypeList();

        public FragmentPresenceRuleConfigControl()
        {
            InitializeComponent();
        }

        public UserControl CreateConfigControl()
        {
            return this;
        }

        public void FillControl(ISpecificConfiguration configuration)
        {
            var selectProhibitedFragmentTypesConfig = Check.OfType<FragmentPresenceRuleConfig>(configuration, nameof(configuration));

            // use a copy (to leave types unchanged in case the user cancels the edit form)
            currentlySelectedFragmentTypes.Clear();
            selectProhibitedFragmentTypesConfig.AffectedFragmentTypes.ToList().ForEach(aX => currentlySelectedFragmentTypes.Add(aX));

            UpdateListBox();

            textBoxViolationMessage.Text = selectProhibitedFragmentTypesConfig.ViolationMessage;
        }

        public void FillModel(ISpecificConfiguration configuration)
        {
            var selectProhibitedFragmentTypesConfig = Check.OfType<FragmentPresenceRuleConfig>(configuration, nameof(configuration));

            selectProhibitedFragmentTypesConfig.AffectedFragmentTypes.Clear();
            currentlySelectedFragmentTypes.ToList().ForEach(aX => selectProhibitedFragmentTypesConfig.AffectedFragmentTypes.Add(aX));

            selectProhibitedFragmentTypesConfig.ViolationMessage = textBoxViolationMessage.Text;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            using (var selectFragmentForm = new SelectFragmentsForm())
            {
                selectFragmentForm.SelectFragments(this, currentlySelectedFragmentTypes);
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            listBoxSelectedFragments.Items.Clear();
            listBoxSelectedFragments.Items.AddRange(currentlySelectedFragmentTypes.Select(aX => aX.Name).ToArray());
        }
    }
}
