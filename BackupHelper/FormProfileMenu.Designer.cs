namespace BackupHelper
{
    partial class FormProfileMenu
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
            this.components = new System.ComponentModel.Container();
            this.listViewProfile = new System.Windows.Forms.ListView();
            this.columnHeaderProfileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastTimeExecuted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProfileLastTimeModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProfileTimeCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemChangeName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGenerateShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddProfile = new System.Windows.Forms.Button();
            this.buttonOpenLogFile = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.saveFileDialogShortcut = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProfile
            // 
            this.listViewProfile.AllowDrop = true;
            this.listViewProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProfileName,
            this.columnHeaderLastTimeExecuted,
            this.columnHeaderProfileLastTimeModified,
            this.columnHeaderProfileTimeCreated});
            this.listViewProfile.ContextMenuStrip = this.contextMenuStripProfile;
            this.listViewProfile.FullRowSelect = true;
            this.listViewProfile.GridLines = true;
            this.listViewProfile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewProfile.HideSelection = false;
            this.listViewProfile.Location = new System.Drawing.Point(0, 0);
            this.listViewProfile.Name = "listViewProfile";
            this.listViewProfile.ShowItemToolTips = true;
            this.listViewProfile.Size = new System.Drawing.Size(698, 324);
            this.listViewProfile.TabIndex = 0;
            this.listViewProfile.UseCompatibleStateImageBehavior = false;
            this.listViewProfile.View = System.Windows.Forms.View.Details;
            this.listViewProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewProfile_KeyDown);
            // 
            // columnHeaderProfileName
            // 
            this.columnHeaderProfileName.Text = "Profile Name";
            this.columnHeaderProfileName.Width = 363;
            // 
            // columnHeaderLastTimeExecuted
            // 
            this.columnHeaderLastTimeExecuted.Text = "Time Executed";
            this.columnHeaderLastTimeExecuted.Width = 110;
            // 
            // columnHeaderProfileLastTimeModified
            // 
            this.columnHeaderProfileLastTimeModified.Text = "Time Modified";
            this.columnHeaderProfileLastTimeModified.Width = 110;
            // 
            // columnHeaderProfileTimeCreated
            // 
            this.columnHeaderProfileTimeCreated.Text = "Created At";
            this.columnHeaderProfileTimeCreated.Width = 110;
            // 
            // contextMenuStripProfile
            // 
            this.contextMenuStripProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemChangeName,
            this.toolStripMenuItemClone,
            this.toolStripMenuItemGroup,
            this.toolStripMenuItemGenerateShortcut,
            this.toolStripMenuItemDeleteProfile});
            this.contextMenuStripProfile.Name = "contextMenuStripProfile";
            this.contextMenuStripProfile.Size = new System.Drawing.Size(181, 136);
            // 
            // toolStripMenuItemChangeName
            // 
            this.toolStripMenuItemChangeName.Name = "toolStripMenuItemChangeName";
            this.toolStripMenuItemChangeName.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItemChangeName.Text = "Change name";
            this.toolStripMenuItemChangeName.Click += new System.EventHandler(this.ToolStripMenuItemChangeName_Click);
            // 
            // toolStripMenuItemClone
            // 
            this.toolStripMenuItemClone.Name = "toolStripMenuItemClone";
            this.toolStripMenuItemClone.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItemClone.Text = "Clone";
            this.toolStripMenuItemClone.Click += new System.EventHandler(this.ToolStripMenuItemClone_Click);
            // 
            // toolStripMenuItemGroup
            // 
            this.toolStripMenuItemGroup.Name = "toolStripMenuItemGroup";
            this.toolStripMenuItemGroup.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItemGroup.Text = "Group";
            this.toolStripMenuItemGroup.Click += new System.EventHandler(this.ToolStripMenuItemGroup_Click);
            // 
            // toolStripMenuItemGenerateShortcut
            // 
            this.toolStripMenuItemGenerateShortcut.Name = "toolStripMenuItemGenerateShortcut";
            this.toolStripMenuItemGenerateShortcut.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItemGenerateShortcut.Text = "Generate shortcut";
            this.toolStripMenuItemGenerateShortcut.Click += new System.EventHandler(this.ToolStripMenuItemGenerateShortcut_Click);
            // 
            // toolStripMenuItemDeleteProfile
            // 
            this.toolStripMenuItemDeleteProfile.Name = "toolStripMenuItemDeleteProfile";
            this.toolStripMenuItemDeleteProfile.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItemDeleteProfile.Text = "Delete";
            this.toolStripMenuItemDeleteProfile.Click += new System.EventHandler(this.ToolStripMenuItemDeleteProfile_Click);
            // 
            // buttonAddProfile
            // 
            this.buttonAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProfile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddProfile.FlatAppearance.BorderSize = 0;
            this.buttonAddProfile.Location = new System.Drawing.Point(0, 324);
            this.buttonAddProfile.Name = "buttonAddProfile";
            this.buttonAddProfile.Size = new System.Drawing.Size(100, 30);
            this.buttonAddProfile.TabIndex = 2;
            this.buttonAddProfile.Text = "Add Profile";
            this.buttonAddProfile.UseVisualStyleBackColor = false;
            this.buttonAddProfile.Click += new System.EventHandler(this.ButtonAddProfile_Click);
            // 
            // buttonOpenLogFile
            // 
            this.buttonOpenLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenLogFile.Location = new System.Drawing.Point(598, 324);
            this.buttonOpenLogFile.Name = "buttonOpenLogFile";
            this.buttonOpenLogFile.Size = new System.Drawing.Size(100, 30);
            this.buttonOpenLogFile.TabIndex = 5;
            this.buttonOpenLogFile.Text = "Open Log File";
            this.buttonOpenLogFile.UseVisualStyleBackColor = true;
            this.buttonOpenLogFile.Click += new System.EventHandler(this.ButtonOpenLogFile_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(116, 332);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(0, 13);
            this.labelVersion.TabIndex = 10;
            // 
            // FormProfileMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 354);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonOpenLogFile);
            this.Controls.Add(this.buttonAddProfile);
            this.Controls.Add(this.listViewProfile);
            this.Name = "FormProfileMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile List - Backup Helper";
            this.contextMenuStripProfile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeaderProfileName;
        private System.Windows.Forms.ColumnHeader columnHeaderProfileTimeCreated;
        private System.Windows.Forms.Button buttonAddProfile;
        private System.Windows.Forms.Button buttonOpenLogFile;
        private System.Windows.Forms.ColumnHeader columnHeaderProfileLastTimeModified;
        private System.Windows.Forms.ColumnHeader columnHeaderLastTimeExecuted;
        private System.Windows.Forms.Label labelVersion;
        public System.Windows.Forms.ListView listViewProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProfile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChangeName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteProfile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClone;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGroup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGenerateShortcut;
        private System.Windows.Forms.SaveFileDialog saveFileDialogShortcut;
    }
}

