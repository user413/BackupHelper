﻿using System.Windows.Forms;

namespace BackupHelper
{
    partial class FormOptionsMenu
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
            this.buttonAddOption = new System.Windows.Forms.Button();
            this.listViewOptions = new System.Windows.Forms.ListView();
            this.columnHeaderSourcePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDestinyPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMoveSubfolders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderKeepOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCleanDestinyDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDeleteCommonFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripOptionsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopySourcePath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopyDestinyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.openSourceFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDestinyFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.progressBarOptions = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTransfering = new System.Windows.Forms.Label();
            this.textBoxTransfering = new System.Windows.Forms.TextBox();
            this.buttonShowResult = new System.Windows.Forms.Button();
            this.checkBoxShowResult = new System.Windows.Forms.CheckBox();
            this.labelMoveOption = new System.Windows.Forms.Label();
            this.labelMoveOptionUp = new System.Windows.Forms.Label();
            this.labelMoveOptionDown = new System.Windows.Forms.Label();
            this.contextMenuStripOptionsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddOption
            // 
            this.buttonAddOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddOption.Location = new System.Drawing.Point(0, 224);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(95, 30);
            this.buttonAddOption.TabIndex = 1;
            this.buttonAddOption.Text = "Add Option";
            this.buttonAddOption.UseVisualStyleBackColor = true;
            this.buttonAddOption.Click += new System.EventHandler(this.ButtonAddOption_Click);
            // 
            // listViewOptions
            // 
            this.listViewOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewOptions.BackColor = System.Drawing.SystemColors.Window;
            this.listViewOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSourcePath,
            this.columnHeaderDestinyPath,
            this.columnHeaderMethod,
            this.columnHeaderMoveSubfolders,
            this.columnHeaderKeepOrigin,
            this.columnHeaderCleanDestinyDir,
            this.columnHeaderDeleteCommonFiles});
            this.listViewOptions.ContextMenuStrip = this.contextMenuStripOptionsList;
            this.listViewOptions.FullRowSelect = true;
            this.listViewOptions.GridLines = true;
            this.listViewOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOptions.HideSelection = false;
            this.listViewOptions.Location = new System.Drawing.Point(0, 0);
            this.listViewOptions.MultiSelect = false;
            this.listViewOptions.Name = "listViewOptions";
            this.listViewOptions.ShowItemToolTips = true;
            this.listViewOptions.Size = new System.Drawing.Size(980, 224);
            this.listViewOptions.TabIndex = 0;
            this.listViewOptions.UseCompatibleStateImageBehavior = false;
            this.listViewOptions.View = System.Windows.Forms.View.Details;
            this.listViewOptions.DoubleClick += new System.EventHandler(this.ListViewOptionsMenu_DoubleClick);
            this.listViewOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewOptions_KeyPress);
            // 
            // columnHeaderSourcePath
            // 
            this.columnHeaderSourcePath.Text = "Source Path";
            this.columnHeaderSourcePath.Width = 281;
            // 
            // columnHeaderDestinyPath
            // 
            this.columnHeaderDestinyPath.Text = "Destiny Path";
            this.columnHeaderDestinyPath.Width = 274;
            // 
            // columnHeaderMethod
            // 
            this.columnHeaderMethod.Text = "Filename Conflict Opt.";
            this.columnHeaderMethod.Width = 129;
            // 
            // columnHeaderMoveSubfolders
            // 
            this.columnHeaderMoveSubfolders.Text = "Move Subfolders";
            this.columnHeaderMoveSubfolders.Width = 73;
            // 
            // columnHeaderKeepOrigin
            // 
            this.columnHeaderKeepOrigin.Text = "Keep Origin Files";
            this.columnHeaderKeepOrigin.Width = 73;
            // 
            // columnHeaderCleanDestinyDir
            // 
            this.columnHeaderCleanDestinyDir.Text = "Clean Dest. Dir.";
            this.columnHeaderCleanDestinyDir.Width = 73;
            // 
            // columnHeaderDeleteCommonFiles
            // 
            this.columnHeaderDeleteCommonFiles.Text = "Del. Common Files";
            this.columnHeaderDeleteCommonFiles.Width = 73;
            // 
            // contextMenuStripOptionsList
            // 
            this.contextMenuStripOptionsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cloneOptionToolStripMenuItem,
            this.ToolStripMenuItemRemove,
            this.toolStripMenuItemCopySourcePath,
            this.toolStripMenuItemCopyDestinyPath,
            this.openSourceFolderToolStripMenuItem,
            this.openDestinyFolderToolStripMenuItem});
            this.contextMenuStripOptionsList.Name = "contextMenuStrip1";
            this.contextMenuStripOptionsList.Size = new System.Drawing.Size(179, 136);
            this.contextMenuStripOptionsList.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripOptionsList_Opening);
            // 
            // cloneOptionToolStripMenuItem
            // 
            this.cloneOptionToolStripMenuItem.Name = "cloneOptionToolStripMenuItem";
            this.cloneOptionToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.cloneOptionToolStripMenuItem.Text = "Clone";
            this.cloneOptionToolStripMenuItem.Click += new System.EventHandler(this.CloneOptionToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemRemove
            // 
            this.ToolStripMenuItemRemove.Name = "ToolStripMenuItemRemove";
            this.ToolStripMenuItemRemove.Size = new System.Drawing.Size(178, 22);
            this.ToolStripMenuItemRemove.Text = "Remove";
            this.ToolStripMenuItemRemove.Click += new System.EventHandler(this.ToolStripMenuItemRemove_Click);
            // 
            // toolStripMenuItemCopySourcePath
            // 
            this.toolStripMenuItemCopySourcePath.Name = "toolStripMenuItemCopySourcePath";
            this.toolStripMenuItemCopySourcePath.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemCopySourcePath.Text = "Copy source path";
            this.toolStripMenuItemCopySourcePath.Click += new System.EventHandler(this.ToolStripMenuItemCopySourcePath_Click);
            // 
            // toolStripMenuItemCopyDestinyPath
            // 
            this.toolStripMenuItemCopyDestinyPath.Name = "toolStripMenuItemCopyDestinyPath";
            this.toolStripMenuItemCopyDestinyPath.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemCopyDestinyPath.Text = "Copy destiny path";
            this.toolStripMenuItemCopyDestinyPath.Click += new System.EventHandler(this.ToolStripMenuItemCopyDestinyPath_Click);
            // 
            // openSourceFolderToolStripMenuItem
            // 
            this.openSourceFolderToolStripMenuItem.Name = "openSourceFolderToolStripMenuItem";
            this.openSourceFolderToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openSourceFolderToolStripMenuItem.Text = "Open source folder";
            this.openSourceFolderToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemOpenSourceFolder_Click);
            // 
            // openDestinyFolderToolStripMenuItem
            // 
            this.openDestinyFolderToolStripMenuItem.Name = "openDestinyFolderToolStripMenuItem";
            this.openDestinyFolderToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openDestinyFolderToolStripMenuItem.Text = "Open destiny folder";
            this.openDestinyFolderToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemOpenDestinyFolder_Click);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExecute.BackColor = System.Drawing.Color.White;
            this.buttonExecute.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonExecute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonExecute.Location = new System.Drawing.Point(94, 224);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(95, 30);
            this.buttonExecute.TabIndex = 4;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = false;
            this.buttonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
            // 
            // progressBarOptions
            // 
            this.progressBarOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarOptions.Enabled = false;
            this.progressBarOptions.Location = new System.Drawing.Point(0, 254);
            this.progressBarOptions.Maximum = 10000;
            this.progressBarOptions.Name = "progressBarOptions";
            this.progressBarOptions.Size = new System.Drawing.Size(980, 10);
            this.progressBarOptions.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonCancel.FlatAppearance.BorderSize = 2;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(885, 224);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 30);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelTransfering
            // 
            this.labelTransfering.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTransfering.AutoSize = true;
            this.labelTransfering.Location = new System.Drawing.Point(12, 233);
            this.labelTransfering.Name = "labelTransfering";
            this.labelTransfering.Size = new System.Drawing.Size(63, 13);
            this.labelTransfering.TabIndex = 6;
            this.labelTransfering.Text = "Transfering:";
            this.labelTransfering.Visible = false;
            // 
            // textBoxTransfering
            // 
            this.textBoxTransfering.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTransfering.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTransfering.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTransfering.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTransfering.Location = new System.Drawing.Point(85, 233);
            this.textBoxTransfering.Name = "textBoxTransfering";
            this.textBoxTransfering.ReadOnly = true;
            this.textBoxTransfering.Size = new System.Drawing.Size(784, 13);
            this.textBoxTransfering.TabIndex = 7;
            this.textBoxTransfering.Visible = false;
            // 
            // buttonShowResult
            // 
            this.buttonShowResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowResult.Enabled = false;
            this.buttonShowResult.Location = new System.Drawing.Point(872, 224);
            this.buttonShowResult.Name = "buttonShowResult";
            this.buttonShowResult.Size = new System.Drawing.Size(108, 30);
            this.buttonShowResult.TabIndex = 8;
            this.buttonShowResult.Text = "Show Last Result";
            this.buttonShowResult.UseVisualStyleBackColor = true;
            this.buttonShowResult.Click += new System.EventHandler(this.ButtonShowResult_Click);
            // 
            // checkBoxShowResult
            // 
            this.checkBoxShowResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowResult.AutoSize = true;
            this.checkBoxShowResult.Checked = true;
            this.checkBoxShowResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowResult.Location = new System.Drawing.Point(729, 232);
            this.checkBoxShowResult.Name = "checkBoxShowResult";
            this.checkBoxShowResult.Size = new System.Drawing.Size(137, 17);
            this.checkBoxShowResult.TabIndex = 7;
            this.checkBoxShowResult.Text = "Show result when done";
            this.checkBoxShowResult.UseVisualStyleBackColor = true;
            // 
            // labelMoveOption
            // 
            this.labelMoveOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMoveOption.AutoSize = true;
            this.labelMoveOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveOption.Location = new System.Drawing.Point(206, 232);
            this.labelMoveOption.Name = "labelMoveOption";
            this.labelMoveOption.Size = new System.Drawing.Size(115, 13);
            this.labelMoveOption.TabIndex = 9;
            this.labelMoveOption.Text = "Move Selected Option:";
            // 
            // labelMoveOptionUp
            // 
            this.labelMoveOptionUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMoveOptionUp.AutoSize = true;
            this.labelMoveOptionUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelMoveOptionUp.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveOptionUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelMoveOptionUp.Location = new System.Drawing.Point(323, 226);
            this.labelMoveOptionUp.Name = "labelMoveOptionUp";
            this.labelMoveOptionUp.Size = new System.Drawing.Size(25, 25);
            this.labelMoveOptionUp.TabIndex = 5;
            this.labelMoveOptionUp.Text = "˄";
            this.labelMoveOptionUp.Click += new System.EventHandler(this.LabelMoveOptionUp_Click);
            // 
            // labelMoveOptionDown
            // 
            this.labelMoveOptionDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMoveOptionDown.AutoSize = true;
            this.labelMoveOptionDown.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelMoveOptionDown.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveOptionDown.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelMoveOptionDown.Location = new System.Drawing.Point(349, 226);
            this.labelMoveOptionDown.Name = "labelMoveOptionDown";
            this.labelMoveOptionDown.Size = new System.Drawing.Size(25, 25);
            this.labelMoveOptionDown.TabIndex = 6;
            this.labelMoveOptionDown.Text = "˅";
            this.labelMoveOptionDown.Click += new System.EventHandler(this.LabelMoveOptionDown_Click);
            // 
            // FormOptionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(980, 261);
            this.Controls.Add(this.labelMoveOptionDown);
            this.Controls.Add(this.labelMoveOptionUp);
            this.Controls.Add(this.labelMoveOption);
            this.Controls.Add(this.checkBoxShowResult);
            this.Controls.Add(this.buttonShowResult);
            this.Controls.Add(this.textBoxTransfering);
            this.Controls.Add(this.labelTransfering);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBarOptions);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.listViewOptions);
            this.Controls.Add(this.buttonAddOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormOptionsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options - Backup Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOptionsMenu_FormClosing);
            this.contextMenuStripOptionsList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddOption;
        private System.Windows.Forms.ColumnHeader columnHeaderSourcePath;
        private System.Windows.Forms.ColumnHeader columnHeaderDestinyPath;
        private System.Windows.Forms.ColumnHeader columnHeaderMethod;
        private System.Windows.Forms.ColumnHeader columnHeaderMoveSubfolders;
        private System.Windows.Forms.ColumnHeader columnHeaderKeepOrigin;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ProgressBar progressBarOptions;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTransfering;
        private System.Windows.Forms.TextBox textBoxTransfering;
        private System.Windows.Forms.ColumnHeader columnHeaderCleanDestinyDir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOptionsList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopySourcePath;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyDestinyPath;
        private System.Windows.Forms.Button buttonShowResult;
        private System.Windows.Forms.CheckBox checkBoxShowResult;
        private System.Windows.Forms.ToolStripMenuItem openSourceFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDestinyFolderToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderDeleteCommonFiles;
        private System.Windows.Forms.Label labelMoveOption;
        private System.Windows.Forms.Label labelMoveOptionUp;
        private System.Windows.Forms.Label labelMoveOptionDown;
        private System.Windows.Forms.ToolStripMenuItem cloneOptionToolStripMenuItem;
        public ListView listViewOptions;
        private ToolStripMenuItem ToolStripMenuItemRemove;
    }
}