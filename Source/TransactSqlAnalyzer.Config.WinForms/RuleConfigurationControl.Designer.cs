namespace TransactSqlAnalyzer.Config.WinForms
{
    partial class RuleConfigurationControl
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
            this.groupBoxSeverity = new System.Windows.Forms.GroupBox();
            this.radioButtonInfo = new System.Windows.Forms.RadioButton();
            this.radioButtonWarning = new System.Windows.Forms.RadioButton();
            this.radioButtonError = new System.Windows.Forms.RadioButton();
            this.checkBoxIsEnabled = new System.Windows.Forms.CheckBox();
            this.comboBoxMaxSqlVersion = new System.Windows.Forms.ComboBox();
            this.comboBoxMinSqlVersion = new System.Windows.Forms.ComboBox();
            this.labelMaxSqlVersion = new System.Windows.Forms.Label();
            this.labelMinSqlVersion = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxFriendlyName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelFriendlyName = new System.Windows.Forms.Label();
            this.groupBoxSeverity.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSeverity
            // 
            this.groupBoxSeverity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSeverity.Controls.Add(this.radioButtonInfo);
            this.groupBoxSeverity.Controls.Add(this.radioButtonWarning);
            this.groupBoxSeverity.Controls.Add(this.radioButtonError);
            this.groupBoxSeverity.Location = new System.Drawing.Point(3, 27);
            this.groupBoxSeverity.Name = "groupBoxSeverity";
            this.groupBoxSeverity.Size = new System.Drawing.Size(418, 96);
            this.groupBoxSeverity.TabIndex = 13;
            this.groupBoxSeverity.TabStop = false;
            this.groupBoxSeverity.Text = "Severity";
            // 
            // radioButtonInfo
            // 
            this.radioButtonInfo.AutoSize = true;
            this.radioButtonInfo.Location = new System.Drawing.Point(7, 68);
            this.radioButtonInfo.Name = "radioButtonInfo";
            this.radioButtonInfo.Size = new System.Drawing.Size(43, 17);
            this.radioButtonInfo.TabIndex = 2;
            this.radioButtonInfo.TabStop = true;
            this.radioButtonInfo.Text = "Info";
            this.radioButtonInfo.UseVisualStyleBackColor = true;
            // 
            // radioButtonWarning
            // 
            this.radioButtonWarning.AutoSize = true;
            this.radioButtonWarning.Location = new System.Drawing.Point(7, 44);
            this.radioButtonWarning.Name = "radioButtonWarning";
            this.radioButtonWarning.Size = new System.Drawing.Size(65, 17);
            this.radioButtonWarning.TabIndex = 1;
            this.radioButtonWarning.TabStop = true;
            this.radioButtonWarning.Text = "Warning";
            this.radioButtonWarning.UseVisualStyleBackColor = true;
            // 
            // radioButtonError
            // 
            this.radioButtonError.AutoSize = true;
            this.radioButtonError.Location = new System.Drawing.Point(7, 20);
            this.radioButtonError.Name = "radioButtonError";
            this.radioButtonError.Size = new System.Drawing.Size(47, 17);
            this.radioButtonError.TabIndex = 0;
            this.radioButtonError.TabStop = true;
            this.radioButtonError.Text = "Error";
            this.radioButtonError.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsEnabled
            // 
            this.checkBoxIsEnabled.AutoSize = true;
            this.checkBoxIsEnabled.Location = new System.Drawing.Point(3, 3);
            this.checkBoxIsEnabled.Name = "checkBoxIsEnabled";
            this.checkBoxIsEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxIsEnabled.TabIndex = 12;
            this.checkBoxIsEnabled.Text = "Enabled";
            this.checkBoxIsEnabled.UseVisualStyleBackColor = true;
            // 
            // comboBoxMaxSqlVersion
            // 
            this.comboBoxMaxSqlVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMaxSqlVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaxSqlVersion.FormattingEnabled = true;
            this.comboBoxMaxSqlVersion.Location = new System.Drawing.Point(87, 362);
            this.comboBoxMaxSqlVersion.Name = "comboBoxMaxSqlVersion";
            this.comboBoxMaxSqlVersion.Size = new System.Drawing.Size(334, 21);
            this.comboBoxMaxSqlVersion.TabIndex = 23;
            // 
            // comboBoxMinSqlVersion
            // 
            this.comboBoxMinSqlVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMinSqlVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMinSqlVersion.FormattingEnabled = true;
            this.comboBoxMinSqlVersion.Location = new System.Drawing.Point(87, 334);
            this.comboBoxMinSqlVersion.Name = "comboBoxMinSqlVersion";
            this.comboBoxMinSqlVersion.Size = new System.Drawing.Size(334, 21);
            this.comboBoxMinSqlVersion.TabIndex = 22;
            // 
            // labelMaxSqlVersion
            // 
            this.labelMaxSqlVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMaxSqlVersion.AutoSize = true;
            this.labelMaxSqlVersion.Location = new System.Drawing.Point(7, 365);
            this.labelMaxSqlVersion.Name = "labelMaxSqlVersion";
            this.labelMaxSqlVersion.Size = new System.Drawing.Size(83, 13);
            this.labelMaxSqlVersion.TabIndex = 21;
            this.labelMaxSqlVersion.Text = "Max Sql Version";
            // 
            // labelMinSqlVersion
            // 
            this.labelMinSqlVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMinSqlVersion.AutoSize = true;
            this.labelMinSqlVersion.Location = new System.Drawing.Point(7, 337);
            this.labelMinSqlVersion.Name = "labelMinSqlVersion";
            this.labelMinSqlVersion.Size = new System.Drawing.Size(80, 13);
            this.labelMinSqlVersion.TabIndex = 20;
            this.labelMinSqlVersion.Text = "Min Sql Version";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(87, 185);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(334, 143);
            this.textBoxDescription.TabIndex = 19;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCategory.Location = new System.Drawing.Point(87, 159);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(334, 20);
            this.textBoxCategory.TabIndex = 17;
            // 
            // textBoxFriendlyName
            // 
            this.textBoxFriendlyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFriendlyName.Location = new System.Drawing.Point(87, 133);
            this.textBoxFriendlyName.Name = "textBoxFriendlyName";
            this.textBoxFriendlyName.Size = new System.Drawing.Size(334, 20);
            this.textBoxFriendlyName.TabIndex = 15;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(7, 188);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 18;
            this.labelDescription.Text = "Description";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(7, 162);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(74, 13);
            this.labelCategory.TabIndex = 16;
            this.labelCategory.Text = "Rule Category";
            // 
            // labelFriendlyName
            // 
            this.labelFriendlyName.AutoSize = true;
            this.labelFriendlyName.Location = new System.Drawing.Point(7, 133);
            this.labelFriendlyName.Name = "labelFriendlyName";
            this.labelFriendlyName.Size = new System.Drawing.Size(74, 13);
            this.labelFriendlyName.TabIndex = 14;
            this.labelFriendlyName.Text = "Friendly Name";
            // 
            // RuleConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxSeverity);
            this.Controls.Add(this.checkBoxIsEnabled);
            this.Controls.Add(this.comboBoxMaxSqlVersion);
            this.Controls.Add(this.comboBoxMinSqlVersion);
            this.Controls.Add(this.labelMaxSqlVersion);
            this.Controls.Add(this.labelMinSqlVersion);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.textBoxFriendlyName);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelFriendlyName);
            this.Name = "RuleConfigurationControl";
            this.Size = new System.Drawing.Size(425, 387);
            this.groupBoxSeverity.ResumeLayout(false);
            this.groupBoxSeverity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSeverity;
        private System.Windows.Forms.RadioButton radioButtonInfo;
        private System.Windows.Forms.RadioButton radioButtonWarning;
        private System.Windows.Forms.RadioButton radioButtonError;
        private System.Windows.Forms.CheckBox checkBoxIsEnabled;
        private System.Windows.Forms.ComboBox comboBoxMaxSqlVersion;
        private System.Windows.Forms.ComboBox comboBoxMinSqlVersion;
        private System.Windows.Forms.Label labelMaxSqlVersion;
        private System.Windows.Forms.Label labelMinSqlVersion;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxFriendlyName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelFriendlyName;
    }
}
