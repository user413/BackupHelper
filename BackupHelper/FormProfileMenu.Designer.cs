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
            this.ToolStripMenuItemClone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddProfile = new System.Windows.Forms.Button();
            this.buttonOpenLogFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMoveProfileUp = new System.Windows.Forms.Label();
            this.labelMoveProfileDown = new System.Windows.Forms.Label();
            this.contextMenuStripProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProfile
            // 
            this.listViewProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.listViewProfile.MultiSelect = false;
            this.listViewProfile.Name = "listViewProfile";
            this.listViewProfile.ShowItemToolTips = true;
            this.listViewProfile.Size = new System.Drawing.Size(698, 211);
            this.listViewProfile.TabIndex = 0;
            this.listViewProfile.UseCompatibleStateImageBehavior = false;
            this.listViewProfile.View = System.Windows.Forms.View.Details;
            this.listViewProfile.DoubleClick += new System.EventHandler(this.ListViewProfileItem_DoubleClick);
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
            this.ToolStripMenuItemClone,
            this.toolStripMenuItemDeleteProfile});
            this.contextMenuStripProfile.Name = "contextMenuStripProfile";
            this.contextMenuStripProfile.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuItemChangeName
            // 
            this.toolStripMenuItemChangeName.Name = "toolStripMenuItemChangeName";
            this.toolStripMenuItemChangeName.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemChangeName.Text = "Change name";
            this.toolStripMenuItemChangeName.Click += new System.EventHandler(this.ToolStripMenuItemChangeName_Click);
            // 
            // ToolStripMenuItemClone
            // 
            this.ToolStripMenuItemClone.Name = "ToolStripMenuItemClone";
            this.ToolStripMenuItemClone.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemClone.Text = "Clone";
            this.ToolStripMenuItemClone.Click += new System.EventHandler(this.ToolStripMenuItemClone_Click);
            // 
            // toolStripMenuItemDeleteProfile
            // 
            this.toolStripMenuItemDeleteProfile.Name = "toolStripMenuItemDeleteProfile";
            this.toolStripMenuItemDeleteProfile.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemDeleteProfile.Text = "Delete";
            this.toolStripMenuItemDeleteProfile.Click += new System.EventHandler(this.ToolStripMenuItemDeleteProfile_Click);
            // 
            // buttonAddProfile
            // 
            this.buttonAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProfile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddProfile.FlatAppearance.BorderSize = 0;
            this.buttonAddProfile.Location = new System.Drawing.Point(0, 211);
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
            this.buttonOpenLogFile.Location = new System.Drawing.Point(598, 211);
            this.buttonOpenLogFile.Name = "buttonOpenLogFile";
            this.buttonOpenLogFile.Size = new System.Drawing.Size(100, 30);
            this.buttonOpenLogFile.TabIndex = 5;
            this.buttonOpenLogFile.Text = "Open Log File";
            this.buttonOpenLogFile.UseVisualStyleBackColor = true;
            this.buttonOpenLogFile.Click += new System.EventHandler(this.ButtonOpenLogFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Move Selected Profile:";
            // 
            // labelMoveProfileUp
            // 
            this.labelMoveProfileUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMoveProfileUp.AutoSize = true;
            this.labelMoveProfileUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelMoveProfileUp.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveProfileUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelMoveProfileUp.Location = new System.Drawing.Point(232, 213);
            this.labelMoveProfileUp.Name = "labelMoveProfileUp";
            this.labelMoveProfileUp.Size = new System.Drawing.Size(25, 25);
            this.labelMoveProfileUp.TabIndex = 11;
            this.labelMoveProfileUp.Text = "˄";
            this.labelMoveProfileUp.Click += new System.EventHandler(this.LabelMoveProfileUp_Click);
            // 
            // labelMoveProfileDown
            // 
            this.labelMoveProfileDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMoveProfileDown.AutoSize = true;
            this.labelMoveProfileDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelMoveProfileDown.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveProfileDown.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelMoveProfileDown.Location = new System.Drawing.Point(258, 213);
            this.labelMoveProfileDown.Name = "labelMoveProfileDown";
            this.labelMoveProfileDown.Size = new System.Drawing.Size(25, 25);
            this.labelMoveProfileDown.TabIndex = 12;
            this.labelMoveProfileDown.Text = "˅";
            this.labelMoveProfileDown.Click += new System.EventHandler(this.LabelMoveProfileDown_Click);
            // 
            // FormProfileMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 241);
            this.Controls.Add(this.labelMoveProfileDown);
            this.Controls.Add(this.labelMoveProfileUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenLogFile);
            this.Controls.Add(this.buttonAddProfile);
            this.Controls.Add(this.listViewProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormProfileMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile List - Backup helper";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMoveProfileUp;
        private System.Windows.Forms.Label labelMoveProfileDown;
        public System.Windows.Forms.ListView listViewProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProfile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChangeName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteProfile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClone;
    }
}

