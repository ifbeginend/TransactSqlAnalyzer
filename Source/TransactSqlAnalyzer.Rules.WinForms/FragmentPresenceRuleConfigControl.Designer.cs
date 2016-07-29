namespace TransactSqlAnalyzer.Rules.WinForms
{
    partial class FragmentPresenceRuleConfigControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelect = new System.Windows.Forms.Button();
            this.listBoxSelectedFragments = new System.Windows.Forms.ListBox();
            this.textBoxViolationMessage = new System.Windows.Forms.TextBox();
            this.labelViolationMessage = new System.Windows.Forms.Label();
            this.labelSelectedFragmentTypes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Location = new System.Drawing.Point(225, 214);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 10;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // listBoxSelectedFragments
            // 
            this.listBoxSelectedFragments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSelectedFragments.FormattingEnabled = true;
            this.listBoxSelectedFragments.Location = new System.Drawing.Point(7, 21);
            this.listBoxSelectedFragments.Name = "listBoxSelectedFragments";
            this.listBoxSelectedFragments.Size = new System.Drawing.Size(293, 186);
            this.listBoxSelectedFragments.Sorted = true;
            this.listBoxSelectedFragments.TabIndex = 9;
            // 
            // textBoxViolationMessage
            // 
            this.textBoxViolationMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxViolationMessage.Location = new System.Drawing.Point(101, 245);
            this.textBoxViolationMessage.Name = "textBoxViolationMessage";
            this.textBoxViolationMessage.Size = new System.Drawing.Size(199, 20);
            this.textBoxViolationMessage.TabIndex = 8;
            // 
            // labelViolationMessage
            // 
            this.labelViolationMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelViolationMessage.AutoSize = true;
            this.labelViolationMessage.Location = new System.Drawing.Point(3, 247);
            this.labelViolationMessage.Name = "labelViolationMessage";
            this.labelViolationMessage.Size = new System.Drawing.Size(92, 13);
            this.labelViolationMessage.TabIndex = 7;
            this.labelViolationMessage.Text = "Violation message";
            // 
            // labelSelectedFragmentTypes
            // 
            this.labelSelectedFragmentTypes.AutoSize = true;
            this.labelSelectedFragmentTypes.Location = new System.Drawing.Point(4, 4);
            this.labelSelectedFragmentTypes.Name = "labelSelectedFragmentTypes";
            this.labelSelectedFragmentTypes.Size = new System.Drawing.Size(152, 13);
            this.labelSelectedFragmentTypes.TabIndex = 6;
            this.labelSelectedFragmentTypes.Text = "Selected TSQL fragment types";
            // 
            // FragmentPresenceRuleConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.listBoxSelectedFragments);
            this.Controls.Add(this.textBoxViolationMessage);
            this.Controls.Add(this.labelViolationMessage);
            this.Controls.Add(this.labelSelectedFragmentTypes);
            this.Name = "FragmentPresenceRuleConfigControl";
            this.Size = new System.Drawing.Size(303, 268);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ListBox listBoxSelectedFragments;
        private System.Windows.Forms.TextBox textBoxViolationMessage;
        private System.Windows.Forms.Label labelViolationMessage;
        private System.Windows.Forms.Label labelSelectedFragmentTypes;
    }
}
