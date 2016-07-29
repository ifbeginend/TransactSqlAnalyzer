namespace TransactSqlAnalyzer.Config.WinForms
{
    partial class RuleConfigurationForm
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
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.treeViewAvailableRuleTypes = new System.Windows.Forms.TreeView();
            this.labelAvailableRuleTypeInfo = new System.Windows.Forms.Label();
            this.panelSelectedRuleInfo = new System.Windows.Forms.Panel();
            this.colMaxSqlVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.colMinSqlVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewConfiguredRules = new System.Windows.Forms.ListView();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelConfiguredRules = new System.Windows.Forms.Label();
            this.labelAvailableRuleTypes = new System.Windows.Forms.Label();
            this.panelSelectedRuleInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadConfig.Location = new System.Drawing.Point(816, 587);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadConfig.TabIndex = 21;
            this.buttonLoadConfig.Text = "Load Config";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfigure.Location = new System.Drawing.Point(979, 586);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(75, 23);
            this.buttonConfigure.TabIndex = 19;
            this.buttonConfigure.Text = "Configure";
            this.buttonConfigure.UseVisualStyleBackColor = true;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(897, 586);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 18;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(256, 586);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // treeViewAvailableRuleTypes
            // 
            this.treeViewAvailableRuleTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewAvailableRuleTypes.HideSelection = false;
            this.treeViewAvailableRuleTypes.Location = new System.Drawing.Point(13, 26);
            this.treeViewAvailableRuleTypes.Name = "treeViewAvailableRuleTypes";
            this.treeViewAvailableRuleTypes.Size = new System.Drawing.Size(237, 425);
            this.treeViewAvailableRuleTypes.TabIndex = 16;
            this.treeViewAvailableRuleTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAvailableRules_AfterSelect);
            // 
            // labelAvailableRuleTypeInfo
            // 
            this.labelAvailableRuleTypeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAvailableRuleTypeInfo.Location = new System.Drawing.Point(0, 0);
            this.labelAvailableRuleTypeInfo.Name = "labelAvailableRuleTypeInfo";
            this.labelAvailableRuleTypeInfo.Size = new System.Drawing.Size(236, 153);
            this.labelAvailableRuleTypeInfo.TabIndex = 0;
            this.labelAvailableRuleTypeInfo.Text = "labelAvailableRuleTypeInfo";
            // 
            // panelSelectedRuleInfo
            // 
            this.panelSelectedRuleInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSelectedRuleInfo.Controls.Add(this.labelAvailableRuleTypeInfo);
            this.panelSelectedRuleInfo.Location = new System.Drawing.Point(14, 457);
            this.panelSelectedRuleInfo.Name = "panelSelectedRuleInfo";
            this.panelSelectedRuleInfo.Size = new System.Drawing.Size(236, 153);
            this.panelSelectedRuleInfo.TabIndex = 15;
            // 
            // colMaxSqlVersion
            // 
            this.colMaxSqlVersion.Text = "Max SQL Version";
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveConfig.Location = new System.Drawing.Point(1061, 586);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveConfig.TabIndex = 20;
            this.buttonSaveConfig.Text = "Save Config";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // colMinSqlVersion
            // 
            this.colMinSqlVersion.Text = "Min SQL Version";
            // 
            // colFriendlyName
            // 
            this.colFriendlyName.Text = "Friendly Name";
            this.colFriendlyName.Width = 149;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.Width = 104;
            // 
            // colSeverity
            // 
            this.colSeverity.Text = "Severity";
            this.colSeverity.Width = 94;
            // 
            // colEnabled
            // 
            this.colEnabled.Text = "Enabled";
            this.colEnabled.Width = 104;
            // 
            // colRule
            // 
            this.colRule.Text = "Rule";
            this.colRule.Width = 218;
            // 
            // listViewConfiguredRules
            // 
            this.listViewConfiguredRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewConfiguredRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRule,
            this.colEnabled,
            this.colSeverity,
            this.colCategory,
            this.colFriendlyName,
            this.colDescription,
            this.colMinSqlVersion,
            this.colMaxSqlVersion});
            this.listViewConfiguredRules.FullRowSelect = true;
            this.listViewConfiguredRules.HideSelection = false;
            this.listViewConfiguredRules.Location = new System.Drawing.Point(256, 26);
            this.listViewConfiguredRules.Name = "listViewConfiguredRules";
            this.listViewConfiguredRules.Size = new System.Drawing.Size(880, 554);
            this.listViewConfiguredRules.TabIndex = 14;
            this.listViewConfiguredRules.UseCompatibleStateImageBehavior = false;
            this.listViewConfiguredRules.View = System.Windows.Forms.View.Details;
            this.listViewConfiguredRules.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewConfiguredRules_ItemSelectionChanged);
            this.listViewConfiguredRules.DoubleClick += new System.EventHandler(this.listViewConfiguredRules_DoubleClick);
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 201;
            // 
            // labelConfiguredRules
            // 
            this.labelConfiguredRules.AutoSize = true;
            this.labelConfiguredRules.Location = new System.Drawing.Point(253, 10);
            this.labelConfiguredRules.Name = "labelConfiguredRules";
            this.labelConfiguredRules.Size = new System.Drawing.Size(88, 13);
            this.labelConfiguredRules.TabIndex = 13;
            this.labelConfiguredRules.Text = "Configured Rules";
            // 
            // labelAvailableRuleTypes
            // 
            this.labelAvailableRuleTypes.AutoSize = true;
            this.labelAvailableRuleTypes.Location = new System.Drawing.Point(10, 10);
            this.labelAvailableRuleTypes.Name = "labelAvailableRuleTypes";
            this.labelAvailableRuleTypes.Size = new System.Drawing.Size(107, 13);
            this.labelAvailableRuleTypes.TabIndex = 12;
            this.labelAvailableRuleTypes.Text = "Available Rule Types";
            // 
            // RuleConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 621);
            this.Controls.Add(this.buttonLoadConfig);
            this.Controls.Add(this.buttonConfigure);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.treeViewAvailableRuleTypes);
            this.Controls.Add(this.panelSelectedRuleInfo);
            this.Controls.Add(this.buttonSaveConfig);
            this.Controls.Add(this.listViewConfiguredRules);
            this.Controls.Add(this.labelConfiguredRules);
            this.Controls.Add(this.labelAvailableRuleTypes);
            this.Name = "RuleConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rule Configuration";
            this.panelSelectedRuleInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadConfig;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TreeView treeViewAvailableRuleTypes;
        private System.Windows.Forms.Label labelAvailableRuleTypeInfo;
        private System.Windows.Forms.Panel panelSelectedRuleInfo;
        private System.Windows.Forms.ColumnHeader colMaxSqlVersion;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.ColumnHeader colMinSqlVersion;
        private System.Windows.Forms.ColumnHeader colFriendlyName;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colSeverity;
        private System.Windows.Forms.ColumnHeader colEnabled;
        private System.Windows.Forms.ColumnHeader colRule;
        private System.Windows.Forms.ListView listViewConfiguredRules;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.Label labelConfiguredRules;
        private System.Windows.Forms.Label labelAvailableRuleTypes;
    }
}