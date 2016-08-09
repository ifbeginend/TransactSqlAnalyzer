namespace TransactSqlAnalyzer.Gui
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.labelRuleConfiguration = new System.Windows.Forms.Label();
            this.labelSqlVersion = new System.Windows.Forms.Label();
            this.checkBoxInitialQuotedIdentifiers = new System.Windows.Forms.CheckBox();
            this.comboBoxSqlVersion = new System.Windows.Forms.ComboBox();
            this.textBoxConfigFile = new System.Windows.Forms.TextBox();
            this.buttonSelectConfigFile = new System.Windows.Forms.Button();
            this.buttonLoadSqlScript = new System.Windows.Forms.Button();
            this.textBoxSqlScript = new System.Windows.Forms.TextBox();
            this.labelSqlScript = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonShowVisits = new System.Windows.Forms.Button();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.checkBoxVerbose = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 89);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.labelSqlScript);
            this.splitContainer.Panel1.Controls.Add(this.textBoxSqlScript);
            this.splitContainer.Panel1.Controls.Add(this.buttonLoadSqlScript);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.textBoxResult);
            this.splitContainer.Size = new System.Drawing.Size(851, 544);
            this.splitContainer.SplitterDistance = 225;
            this.splitContainer.TabIndex = 6;
            // 
            // labelRuleConfiguration
            // 
            this.labelRuleConfiguration.AutoSize = true;
            this.labelRuleConfiguration.Location = new System.Drawing.Point(12, 17);
            this.labelRuleConfiguration.Name = "labelRuleConfiguration";
            this.labelRuleConfiguration.Size = new System.Drawing.Size(53, 13);
            this.labelRuleConfiguration.TabIndex = 0;
            this.labelRuleConfiguration.Text = "Config file";
            // 
            // labelSqlVersion
            // 
            this.labelSqlVersion.AutoSize = true;
            this.labelSqlVersion.Location = new System.Drawing.Point(12, 42);
            this.labelSqlVersion.Name = "labelSqlVersion";
            this.labelSqlVersion.Size = new System.Drawing.Size(66, 13);
            this.labelSqlVersion.TabIndex = 3;
            this.labelSqlVersion.Text = "TSql version";
            // 
            // checkBoxInitialQuotedIdentifiers
            // 
            this.checkBoxInitialQuotedIdentifiers.AutoSize = true;
            this.checkBoxInitialQuotedIdentifiers.Location = new System.Drawing.Point(86, 66);
            this.checkBoxInitialQuotedIdentifiers.Name = "checkBoxInitialQuotedIdentifiers";
            this.checkBoxInitialQuotedIdentifiers.Size = new System.Drawing.Size(133, 17);
            this.checkBoxInitialQuotedIdentifiers.TabIndex = 5;
            this.checkBoxInitialQuotedIdentifiers.Text = "Initial quoted identifiers";
            this.checkBoxInitialQuotedIdentifiers.UseVisualStyleBackColor = true;
            // 
            // comboBoxSqlVersion
            // 
            this.comboBoxSqlVersion.FormattingEnabled = true;
            this.comboBoxSqlVersion.Location = new System.Drawing.Point(86, 39);
            this.comboBoxSqlVersion.Name = "comboBoxSqlVersion";
            this.comboBoxSqlVersion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSqlVersion.TabIndex = 4;
            // 
            // textBoxConfigFile
            // 
            this.textBoxConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfigFile.Location = new System.Drawing.Point(86, 13);
            this.textBoxConfigFile.Name = "textBoxConfigFile";
            this.textBoxConfigFile.ReadOnly = true;
            this.textBoxConfigFile.Size = new System.Drawing.Size(696, 20);
            this.textBoxConfigFile.TabIndex = 1;
            // 
            // buttonSelectConfigFile
            // 
            this.buttonSelectConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectConfigFile.Location = new System.Drawing.Point(788, 12);
            this.buttonSelectConfigFile.Name = "buttonSelectConfigFile";
            this.buttonSelectConfigFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectConfigFile.TabIndex = 2;
            this.buttonSelectConfigFile.Text = "Config...";
            this.buttonSelectConfigFile.UseVisualStyleBackColor = true;
            this.buttonSelectConfigFile.Click += new System.EventHandler(this.buttonSelectConfigFile_Click);
            // 
            // buttonLoadSqlScript
            // 
            this.buttonLoadSqlScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadSqlScript.Location = new System.Drawing.Point(776, 199);
            this.buttonLoadSqlScript.Name = "buttonLoadSqlScript";
            this.buttonLoadSqlScript.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadSqlScript.TabIndex = 2;
            this.buttonLoadSqlScript.Text = "Load...";
            this.buttonLoadSqlScript.UseVisualStyleBackColor = true;
            this.buttonLoadSqlScript.Click += new System.EventHandler(this.buttonLoadSqlScript_Click);
            // 
            // textBoxSqlScript
            // 
            this.textBoxSqlScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSqlScript.Location = new System.Drawing.Point(0, 20);
            this.textBoxSqlScript.Multiline = true;
            this.textBoxSqlScript.Name = "textBoxSqlScript";
            this.textBoxSqlScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSqlScript.Size = new System.Drawing.Size(851, 173);
            this.textBoxSqlScript.TabIndex = 1;
            this.textBoxSqlScript.WordWrap = false;
            // 
            // labelSqlScript
            // 
            this.labelSqlScript.AutoSize = true;
            this.labelSqlScript.Location = new System.Drawing.Point(4, 4);
            this.labelSqlScript.Name = "labelSqlScript";
            this.labelSqlScript.Size = new System.Drawing.Size(59, 13);
            this.labelSqlScript.TabIndex = 0;
            this.labelSqlScript.Text = "TSql Script";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Location = new System.Drawing.Point(0, 0);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(851, 315);
            this.textBoxResult.TabIndex = 0;
            this.textBoxResult.WordWrap = false;
            // 
            // buttonShowVisits
            // 
            this.buttonShowVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowVisits.Location = new System.Drawing.Point(707, 648);
            this.buttonShowVisits.Name = "buttonShowVisits";
            this.buttonShowVisits.Size = new System.Drawing.Size(75, 23);
            this.buttonShowVisits.TabIndex = 7;
            this.buttonShowVisits.Text = "Show visits";
            this.buttonShowVisits.UseVisualStyleBackColor = true;
            this.buttonShowVisits.Click += new System.EventHandler(this.buttonShowVisits_Click);
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalyze.Location = new System.Drawing.Point(788, 648);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalyze.TabIndex = 8;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // checkBoxVerbose
            // 
            this.checkBoxVerbose.AutoSize = true;
            this.checkBoxVerbose.Location = new System.Drawing.Point(255, 66);
            this.checkBoxVerbose.Name = "checkBoxVerbose";
            this.checkBoxVerbose.Size = new System.Drawing.Size(65, 17);
            this.checkBoxVerbose.TabIndex = 9;
            this.checkBoxVerbose.Text = "Verbose";
            this.checkBoxVerbose.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 683);
            this.Controls.Add(this.checkBoxVerbose);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.buttonShowVisits);
            this.Controls.Add(this.buttonSelectConfigFile);
            this.Controls.Add(this.textBoxConfigFile);
            this.Controls.Add(this.comboBoxSqlVersion);
            this.Controls.Add(this.checkBoxInitialQuotedIdentifiers);
            this.Controls.Add(this.labelSqlVersion);
            this.Controls.Add(this.labelRuleConfiguration);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transact SQL Analyzer";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label labelRuleConfiguration;
        private System.Windows.Forms.Label labelSqlVersion;
        private System.Windows.Forms.CheckBox checkBoxInitialQuotedIdentifiers;
        private System.Windows.Forms.ComboBox comboBoxSqlVersion;
        private System.Windows.Forms.TextBox textBoxConfigFile;
        private System.Windows.Forms.Button buttonSelectConfigFile;
        private System.Windows.Forms.Label labelSqlScript;
        private System.Windows.Forms.TextBox textBoxSqlScript;
        private System.Windows.Forms.Button buttonLoadSqlScript;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonShowVisits;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.CheckBox checkBoxVerbose;
    }
}

