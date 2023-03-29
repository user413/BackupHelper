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
            components = new System.ComponentModel.Container();
            listViewProfile = new ListView();
            columnHeaderProfileName = new ColumnHeader();
            columnHeaderLastTimeExecuted = new ColumnHeader();
            columnHeaderProfileLastTimeModified = new ColumnHeader();
            columnHeaderProfileTimeCreated = new ColumnHeader();
            contextMenuStripProfile = new ContextMenuStrip(components);
            toolStripMenuItemChangeName = new ToolStripMenuItem();
            toolStripMenuItemClone = new ToolStripMenuItem();
            toolStripMenuItemGroup = new ToolStripMenuItem();
            toolStripMenuItemGenerateShortcut = new ToolStripMenuItem();
            toolStripMenuItemDeleteProfile = new ToolStripMenuItem();
            buttonAddProfile = new Button();
            buttonOpenLogFile = new Button();
            labelVersion = new Label();
            saveFileDialogShortcut = new SaveFileDialog();
            contextMenuStripProfile.SuspendLayout();
            SuspendLayout();
            // 
            // listViewProfile
            // 
            listViewProfile.AllowDrop = true;
            listViewProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewProfile.Columns.AddRange(new ColumnHeader[] { columnHeaderProfileName, columnHeaderLastTimeExecuted, columnHeaderProfileLastTimeModified, columnHeaderProfileTimeCreated });
            listViewProfile.ContextMenuStrip = contextMenuStripProfile;
            listViewProfile.FullRowSelect = true;
            listViewProfile.GridLines = true;
            listViewProfile.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewProfile.Location = new Point(0, 0);
            listViewProfile.Name = "listViewProfile";
            listViewProfile.ShowItemToolTips = true;
            listViewProfile.Size = new Size(698, 324);
            listViewProfile.TabIndex = 0;
            listViewProfile.UseCompatibleStateImageBehavior = false;
            listViewProfile.View = View.Details;
            listViewProfile.KeyDown += ListViewProfile_KeyDown;
            // 
            // columnHeaderProfileName
            // 
            columnHeaderProfileName.Text = "Profile Name";
            columnHeaderProfileName.Width = 363;
            // 
            // columnHeaderLastTimeExecuted
            // 
            columnHeaderLastTimeExecuted.Text = "Time Executed";
            columnHeaderLastTimeExecuted.Width = 110;
            // 
            // columnHeaderProfileLastTimeModified
            // 
            columnHeaderProfileLastTimeModified.Text = "Time Modified";
            columnHeaderProfileLastTimeModified.Width = 110;
            // 
            // columnHeaderProfileTimeCreated
            // 
            columnHeaderProfileTimeCreated.Text = "Created At";
            columnHeaderProfileTimeCreated.Width = 110;
            // 
            // contextMenuStripProfile
            // 
            contextMenuStripProfile.Items.AddRange(new ToolStripItem[] { toolStripMenuItemChangeName, toolStripMenuItemClone, toolStripMenuItemGroup, toolStripMenuItemGenerateShortcut, toolStripMenuItemDeleteProfile });
            contextMenuStripProfile.Name = "contextMenuStripProfile";
            contextMenuStripProfile.Size = new Size(169, 114);
            // 
            // toolStripMenuItemChangeName
            // 
            toolStripMenuItemChangeName.Name = "toolStripMenuItemChangeName";
            toolStripMenuItemChangeName.Size = new Size(168, 22);
            toolStripMenuItemChangeName.Text = "Change name";
            toolStripMenuItemChangeName.Click += ToolStripMenuItemChangeName_Click;
            // 
            // toolStripMenuItemClone
            // 
            toolStripMenuItemClone.Name = "toolStripMenuItemClone";
            toolStripMenuItemClone.Size = new Size(168, 22);
            toolStripMenuItemClone.Text = "Clone";
            toolStripMenuItemClone.Click += ToolStripMenuItemClone_Click;
            // 
            // toolStripMenuItemGroup
            // 
            toolStripMenuItemGroup.Name = "toolStripMenuItemGroup";
            toolStripMenuItemGroup.Size = new Size(168, 22);
            toolStripMenuItemGroup.Text = "Group";
            toolStripMenuItemGroup.Click += ToolStripMenuItemGroup_Click;
            // 
            // toolStripMenuItemGenerateShortcut
            // 
            toolStripMenuItemGenerateShortcut.Name = "toolStripMenuItemGenerateShortcut";
            toolStripMenuItemGenerateShortcut.Size = new Size(168, 22);
            toolStripMenuItemGenerateShortcut.Text = "Generate shortcut";
            toolStripMenuItemGenerateShortcut.Click += ToolStripMenuItemGenerateShortcut_Click;
            // 
            // toolStripMenuItemDeleteProfile
            // 
            toolStripMenuItemDeleteProfile.Name = "toolStripMenuItemDeleteProfile";
            toolStripMenuItemDeleteProfile.Size = new Size(168, 22);
            toolStripMenuItemDeleteProfile.Text = "Delete";
            toolStripMenuItemDeleteProfile.Click += ToolStripMenuItemDeleteProfile_Click;
            // 
            // buttonAddProfile
            // 
            buttonAddProfile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddProfile.BackColor = SystemColors.ControlLightLight;
            buttonAddProfile.FlatAppearance.BorderSize = 0;
            buttonAddProfile.Location = new Point(0, 324);
            buttonAddProfile.Name = "buttonAddProfile";
            buttonAddProfile.Size = new Size(100, 30);
            buttonAddProfile.TabIndex = 2;
            buttonAddProfile.Text = "Add Profile";
            buttonAddProfile.UseVisualStyleBackColor = false;
            buttonAddProfile.Click += ButtonAddProfile_Click;
            // 
            // buttonOpenLogFile
            // 
            buttonOpenLogFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOpenLogFile.Location = new Point(598, 324);
            buttonOpenLogFile.Name = "buttonOpenLogFile";
            buttonOpenLogFile.Size = new Size(100, 30);
            buttonOpenLogFile.TabIndex = 5;
            buttonOpenLogFile.Text = "Open Log File";
            buttonOpenLogFile.UseVisualStyleBackColor = true;
            buttonOpenLogFile.Click += ButtonOpenLogFile_Click;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labelVersion.Location = new Point(116, 332);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(0, 13);
            labelVersion.TabIndex = 10;
            // 
            // FormProfileMenu
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 354);
            Controls.Add(labelVersion);
            Controls.Add(buttonOpenLogFile);
            Controls.Add(buttonAddProfile);
            Controls.Add(listViewProfile);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormProfileMenu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Profile List - Backup Helper";
            contextMenuStripProfile.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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

