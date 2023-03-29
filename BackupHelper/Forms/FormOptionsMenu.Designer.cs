using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            buttonAddOption = new Button();
            listViewOptions = new ListView();
            columnHeaderSourcePath = new ColumnHeader();
            columnHeaderDestinyPath = new ColumnHeader();
            columnHeaderMethod = new ColumnHeader();
            columnHeaderMoveSubfolders = new ColumnHeader();
            columnHeaderKeepOrigin = new ColumnHeader();
            columnHeaderCleanDestinyDir = new ColumnHeader();
            columnHeaderDeleteUncommonFiles = new ColumnHeader();
            columnHeaderReorganizeFiles = new ColumnHeader();
            contextMenuStripOptionsList = new ContextMenuStrip(components);
            toolStripMenuItemClone = new ToolStripMenuItem();
            toolStripMenuItemRemove = new ToolStripMenuItem();
            toolStripMenuItemCopySourcePath = new ToolStripMenuItem();
            toolStripMenuItemCopyDestinyPath = new ToolStripMenuItem();
            toolStripMenuItemOpenSourceFolder = new ToolStripMenuItem();
            toolStripMenuItemOpenDestinyFolder = new ToolStripMenuItem();
            buttonExecute = new Button();
            progressBarOptions = new ProgressBar();
            buttonCancel = new Button();
            labelTransfering = new Label();
            textBoxTransfering = new TextBox();
            buttonShowResult = new Button();
            checkBoxShowResult = new CheckBox();
            contextMenuStripOptionsList.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAddOption
            // 
            buttonAddOption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddOption.Location = new Point(1, 224);
            buttonAddOption.Name = "buttonAddOption";
            buttonAddOption.Size = new Size(95, 30);
            buttonAddOption.TabIndex = 1;
            buttonAddOption.Text = "Add Option";
            buttonAddOption.UseVisualStyleBackColor = true;
            buttonAddOption.Click += ButtonAddOption_Click;
            // 
            // listViewOptions
            // 
            listViewOptions.AllowDrop = true;
            listViewOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewOptions.BackColor = SystemColors.Window;
            listViewOptions.Columns.AddRange(new ColumnHeader[] { columnHeaderSourcePath, columnHeaderDestinyPath, columnHeaderMethod, columnHeaderMoveSubfolders, columnHeaderKeepOrigin, columnHeaderCleanDestinyDir, columnHeaderDeleteUncommonFiles, columnHeaderReorganizeFiles });
            listViewOptions.ContextMenuStrip = contextMenuStripOptionsList;
            listViewOptions.FullRowSelect = true;
            listViewOptions.GridLines = true;
            listViewOptions.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewOptions.Location = new Point(0, 0);
            listViewOptions.Name = "listViewOptions";
            listViewOptions.ShowItemToolTips = true;
            listViewOptions.Size = new Size(1163, 224);
            listViewOptions.TabIndex = 0;
            listViewOptions.UseCompatibleStateImageBehavior = false;
            listViewOptions.View = View.Details;
            listViewOptions.KeyDown += ListViewOptions_KeyPress;
            // 
            // columnHeaderSourcePath
            // 
            columnHeaderSourcePath.Text = "Source Path";
            columnHeaderSourcePath.Width = 290;
            // 
            // columnHeaderDestinyPath
            // 
            columnHeaderDestinyPath.Text = "Destiny Path";
            columnHeaderDestinyPath.Width = 290;
            // 
            // columnHeaderMethod
            // 
            columnHeaderMethod.Text = "Filename Conflict Opt.";
            columnHeaderMethod.Width = 175;
            // 
            // columnHeaderMoveSubfolders
            // 
            columnHeaderMoveSubfolders.Text = "Move Subfolders";
            columnHeaderMoveSubfolders.Width = 80;
            // 
            // columnHeaderKeepOrigin
            // 
            columnHeaderKeepOrigin.Text = "Keep Origin Files";
            columnHeaderKeepOrigin.Width = 80;
            // 
            // columnHeaderCleanDestinyDir
            // 
            columnHeaderCleanDestinyDir.Text = "Clean Dest. Dir.";
            columnHeaderCleanDestinyDir.Width = 80;
            // 
            // columnHeaderDeleteUncommonFiles
            // 
            columnHeaderDeleteUncommonFiles.Text = "Del. Uncommon Files";
            columnHeaderDeleteUncommonFiles.Width = 80;
            // 
            // columnHeaderReorganizeFiles
            // 
            columnHeaderReorganizeFiles.Text = "Reorg. renamed files";
            columnHeaderReorganizeFiles.Width = 80;
            // 
            // contextMenuStripOptionsList
            // 
            contextMenuStripOptionsList.Items.AddRange(new ToolStripItem[] { toolStripMenuItemClone, toolStripMenuItemRemove, toolStripMenuItemCopySourcePath, toolStripMenuItemCopyDestinyPath, toolStripMenuItemOpenSourceFolder, toolStripMenuItemOpenDestinyFolder });
            contextMenuStripOptionsList.Name = "contextMenuStrip1";
            contextMenuStripOptionsList.Size = new Size(179, 136);
            contextMenuStripOptionsList.Opening += ContextMenuStripOptionsList_Opening;
            // 
            // toolStripMenuItemClone
            // 
            toolStripMenuItemClone.Name = "toolStripMenuItemClone";
            toolStripMenuItemClone.Size = new Size(178, 22);
            toolStripMenuItemClone.Text = "Clone";
            toolStripMenuItemClone.Click += CloneOptionToolStripMenuItem_Click;
            // 
            // toolStripMenuItemRemove
            // 
            toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            toolStripMenuItemRemove.Size = new Size(178, 22);
            toolStripMenuItemRemove.Text = "Remove";
            toolStripMenuItemRemove.Click += ToolStripMenuItemRemove_Click;
            // 
            // toolStripMenuItemCopySourcePath
            // 
            toolStripMenuItemCopySourcePath.Name = "toolStripMenuItemCopySourcePath";
            toolStripMenuItemCopySourcePath.Size = new Size(178, 22);
            toolStripMenuItemCopySourcePath.Text = "Copy source path";
            toolStripMenuItemCopySourcePath.Click += ToolStripMenuItemCopySourcePath_Click;
            // 
            // toolStripMenuItemCopyDestinyPath
            // 
            toolStripMenuItemCopyDestinyPath.Name = "toolStripMenuItemCopyDestinyPath";
            toolStripMenuItemCopyDestinyPath.Size = new Size(178, 22);
            toolStripMenuItemCopyDestinyPath.Text = "Copy destiny path";
            toolStripMenuItemCopyDestinyPath.Click += ToolStripMenuItemCopyDestinyPath_Click;
            // 
            // toolStripMenuItemOpenSourceFolder
            // 
            toolStripMenuItemOpenSourceFolder.Name = "toolStripMenuItemOpenSourceFolder";
            toolStripMenuItemOpenSourceFolder.Size = new Size(178, 22);
            toolStripMenuItemOpenSourceFolder.Text = "Open source folder";
            toolStripMenuItemOpenSourceFolder.Click += ToolStripMenuItemOpenSourceFolder_Click;
            // 
            // toolStripMenuItemOpenDestinyFolder
            // 
            toolStripMenuItemOpenDestinyFolder.Name = "toolStripMenuItemOpenDestinyFolder";
            toolStripMenuItemOpenDestinyFolder.Size = new Size(178, 22);
            toolStripMenuItemOpenDestinyFolder.Text = "Open destiny folder";
            toolStripMenuItemOpenDestinyFolder.Click += ToolStripMenuItemOpenDestinyFolder_Click;
            // 
            // buttonExecute
            // 
            buttonExecute.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonExecute.BackColor = Color.White;
            buttonExecute.FlatAppearance.BorderColor = Color.Red;
            buttonExecute.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            buttonExecute.Location = new Point(95, 224);
            buttonExecute.Name = "buttonExecute";
            buttonExecute.Size = new Size(95, 30);
            buttonExecute.TabIndex = 4;
            buttonExecute.Text = "Execute";
            buttonExecute.UseVisualStyleBackColor = false;
            buttonExecute.Click += ButtonExecute_Click;
            // 
            // progressBarOptions
            // 
            progressBarOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBarOptions.Enabled = false;
            progressBarOptions.Location = new Point(0, 254);
            progressBarOptions.Maximum = 10000;
            progressBarOptions.Name = "progressBarOptions";
            progressBarOptions.Size = new Size(1163, 12);
            progressBarOptions.TabIndex = 4;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.BackColor = Color.FromArgb(255, 192, 192);
            buttonCancel.FlatAppearance.BorderColor = Color.Red;
            buttonCancel.FlatAppearance.BorderSize = 2;
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(1068, 224);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(95, 30);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "CANCEL";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Visible = false;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // labelTransfering
            // 
            labelTransfering.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelTransfering.AutoSize = true;
            labelTransfering.Location = new Point(12, 233);
            labelTransfering.Name = "labelTransfering";
            labelTransfering.Size = new Size(63, 13);
            labelTransfering.TabIndex = 6;
            labelTransfering.Text = "Transfering:";
            labelTransfering.Visible = false;
            // 
            // textBoxTransfering
            // 
            textBoxTransfering.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTransfering.BackColor = SystemColors.Control;
            textBoxTransfering.BorderStyle = BorderStyle.None;
            textBoxTransfering.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxTransfering.Location = new Point(85, 233);
            textBoxTransfering.Name = "textBoxTransfering";
            textBoxTransfering.ReadOnly = true;
            textBoxTransfering.Size = new Size(964, 13);
            textBoxTransfering.TabIndex = 7;
            textBoxTransfering.Visible = false;
            // 
            // buttonShowResult
            // 
            buttonShowResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonShowResult.Enabled = false;
            buttonShowResult.Location = new Point(1054, 224);
            buttonShowResult.Name = "buttonShowResult";
            buttonShowResult.Size = new Size(108, 30);
            buttonShowResult.TabIndex = 8;
            buttonShowResult.Text = "Show Last Result";
            buttonShowResult.UseVisualStyleBackColor = true;
            buttonShowResult.Click += ButtonShowResult_Click;
            // 
            // checkBoxShowResult
            // 
            checkBoxShowResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBoxShowResult.AutoSize = true;
            checkBoxShowResult.Checked = true;
            checkBoxShowResult.CheckState = CheckState.Checked;
            checkBoxShowResult.Location = new Point(912, 232);
            checkBoxShowResult.Name = "checkBoxShowResult";
            checkBoxShowResult.Size = new Size(137, 17);
            checkBoxShowResult.TabIndex = 7;
            checkBoxShowResult.Text = "Show result when done";
            checkBoxShowResult.UseVisualStyleBackColor = true;
            // 
            // FormOptionsMenu
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1163, 261);
            Controls.Add(checkBoxShowResult);
            Controls.Add(textBoxTransfering);
            Controls.Add(labelTransfering);
            Controls.Add(progressBarOptions);
            Controls.Add(buttonExecute);
            Controls.Add(listViewOptions);
            Controls.Add(buttonAddOption);
            Controls.Add(buttonShowResult);
            Controls.Add(buttonCancel);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormOptionsMenu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options - Backup Helper";
            FormClosing += FormOptionsMenu_FormClosing;
            contextMenuStripOptionsList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenSourceFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDestinyFolder;
        private System.Windows.Forms.ColumnHeader columnHeaderDeleteUncommonFiles;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClone;
        public ListView listViewOptions;
        private ToolStripMenuItem toolStripMenuItemRemove;
        private ColumnHeader columnHeaderReorganizeFiles;
    }
}