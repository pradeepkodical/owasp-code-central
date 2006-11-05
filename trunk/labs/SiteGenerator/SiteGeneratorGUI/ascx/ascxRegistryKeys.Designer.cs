namespace Owasp.SiteGenerator.ascx
{
    partial class ascxRegistryKeys
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
            this.txtRegistryKeys = new System.Windows.Forms.TextBox();
            this.lvRegistry_RegQueryValueExW = new System.Windows.Forms.ListView();
            this.Hook = new System.Windows.Forms.ColumnHeader();
            this.iProcID = new System.Windows.Forms.ColumnHeader();
            this.hKey = new System.Windows.Forms.ColumnHeader();
            this.lpValueName = new System.Windows.Forms.ColumnHeader();
            this.lpReserved = new System.Windows.Forms.ColumnHeader();
            this.lpType = new System.Windows.Forms.ColumnHeader();
            this.lpData = new System.Windows.Forms.ColumnHeader();
            this.lpcbData = new System.Windows.Forms.ColumnHeader();
            this.rv = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvRegistry_Others = new System.Windows.Forms.ListView();
            this.chHook = new System.Windows.Forms.ColumnHeader();
            this.chProgId = new System.Windows.Forms.ColumnHeader();
            this.v0 = new System.Windows.Forms.ColumnHeader();
            this.v1 = new System.Windows.Forms.ColumnHeader();
            this.v2 = new System.Windows.Forms.ColumnHeader();
            this.v3 = new System.Windows.Forms.ColumnHeader();
            this.v4 = new System.Windows.Forms.ColumnHeader();
            this.v5 = new System.Windows.Forms.ColumnHeader();
            this.v6 = new System.Windows.Forms.ColumnHeader();
            this.v7 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRegistryKeys
            // 
            this.txtRegistryKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistryKeys.Location = new System.Drawing.Point(3, 316);
            this.txtRegistryKeys.Multiline = true;
            this.txtRegistryKeys.Name = "txtRegistryKeys";
            this.txtRegistryKeys.Size = new System.Drawing.Size(931, 80);
            this.txtRegistryKeys.TabIndex = 1;
            // 
            // lvRegistry_RegQueryValueExW
            // 
            this.lvRegistry_RegQueryValueExW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRegistry_RegQueryValueExW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Hook,
            this.iProcID,
            this.hKey,
            this.lpValueName,
            this.lpReserved,
            this.lpType,
            this.lpData,
            this.lpcbData,
            this.rv});
            this.lvRegistry_RegQueryValueExW.FullRowSelect = true;
            this.lvRegistry_RegQueryValueExW.Location = new System.Drawing.Point(6, 6);
            this.lvRegistry_RegQueryValueExW.Name = "lvRegistry_RegQueryValueExW";
            this.lvRegistry_RegQueryValueExW.Size = new System.Drawing.Size(911, 257);
            this.lvRegistry_RegQueryValueExW.TabIndex = 2;
            this.lvRegistry_RegQueryValueExW.UseCompatibleStateImageBehavior = false;
            this.lvRegistry_RegQueryValueExW.View = System.Windows.Forms.View.Details;
            // 
            // Hook
            // 
            this.Hook.Text = "Hook";
            // 
            // iProcID
            // 
            this.iProcID.Text = "Proc ID";
            // 
            // hKey
            // 
            this.hKey.Text = "hKey";
            this.hKey.Width = 40;
            // 
            // lpValueName
            // 
            this.lpValueName.Text = "lpValueName";
            this.lpValueName.Width = 320;
            // 
            // lpReserved
            // 
            this.lpReserved.Text = "lpReserved";
            this.lpReserved.Width = 97;
            // 
            // lpType
            // 
            this.lpType.Text = "lpType";
            this.lpType.Width = 92;
            // 
            // lpData
            // 
            this.lpData.Text = "lpData";
            this.lpData.Width = 88;
            // 
            // lpcbData
            // 
            this.lpcbData.Text = "lpcbData";
            this.lpcbData.Width = 88;
            // 
            // rv
            // 
            this.rv.Text = "rv";
            this.rv.Width = 58;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Raw Data";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 292);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvRegistry_RegQueryValueExW);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RegQueryValueExW";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvRegistry_Others);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Others";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvRegistry_Others
            // 
            this.lvRegistry_Others.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRegistry_Others.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chHook,
            this.chProgId,
            this.v0,
            this.v1,
            this.v2,
            this.v3,
            this.v4,
            this.v5,
            this.v6,
            this.v7});
            this.lvRegistry_Others.FullRowSelect = true;
            this.lvRegistry_Others.Location = new System.Drawing.Point(3, 3);
            this.lvRegistry_Others.Name = "lvRegistry_Others";
            this.lvRegistry_Others.Size = new System.Drawing.Size(914, 264);
            this.lvRegistry_Others.TabIndex = 6;
            this.lvRegistry_Others.UseCompatibleStateImageBehavior = false;
            this.lvRegistry_Others.View = System.Windows.Forms.View.Details;
            // 
            // chHook
            // 
            this.chHook.Text = "Hook";
            this.chHook.Width = 72;
            // 
            // chProgId
            // 
            this.chProgId.Text = "Proc ID";
            this.chProgId.Width = 59;
            // 
            // v0
            // 
            this.v0.Text = "v0";
            this.v0.Width = 113;
            // 
            // v1
            // 
            this.v1.Text = "v1";
            this.v1.Width = 110;
            // 
            // v2
            // 
            this.v2.Text = "v2";
            this.v2.Width = 88;
            // 
            // v3
            // 
            this.v3.Text = "v3";
            this.v3.Width = 94;
            // 
            // v4
            // 
            this.v4.Text = "v4";
            this.v4.Width = 88;
            // 
            // v5
            // 
            this.v5.Text = "v5";
            this.v5.Width = 77;
            // 
            // v6
            // 
            this.v6.Text = "v6";
            this.v6.Width = 55;
            // 
            // v7
            // 
            this.v7.Text = "v7";
            this.v7.Width = 87;
            // 
            // ascxRegistryKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegistryKeys);
            this.Name = "ascxRegistryKeys";
            this.Size = new System.Drawing.Size(937, 399);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtRegistryKeys;
        public System.Windows.Forms.ListView lvRegistry_RegQueryValueExW;
        private System.Windows.Forms.ColumnHeader hKey;
        private System.Windows.Forms.ColumnHeader iProcID;
        private System.Windows.Forms.ColumnHeader lpValueName;
        private System.Windows.Forms.ColumnHeader lpReserved;
        private System.Windows.Forms.ColumnHeader lpType;
        private System.Windows.Forms.ColumnHeader lpData;
        private System.Windows.Forms.ColumnHeader lpcbData;
        private System.Windows.Forms.ColumnHeader rv;
        private System.Windows.Forms.ColumnHeader Hook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListView lvRegistry_Others;
        private System.Windows.Forms.ColumnHeader chHook;
        private System.Windows.Forms.ColumnHeader chProgId;
        private System.Windows.Forms.ColumnHeader v0;
        private System.Windows.Forms.ColumnHeader v1;
        private System.Windows.Forms.ColumnHeader v2;
        private System.Windows.Forms.ColumnHeader v3;
        private System.Windows.Forms.ColumnHeader v4;
        private System.Windows.Forms.ColumnHeader v5;
        private System.Windows.Forms.ColumnHeader v6;
        private System.Windows.Forms.ColumnHeader v7;
        
    }
}
