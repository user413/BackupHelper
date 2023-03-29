using System;
using System.ComponentModel;

namespace BackupHelper
{
    partial class FormReport
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormReport));
            tabPageCreatedDirectories = new TabPage();
            listViewCreatedDirectories = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            contextMenuStripCreatedDirectories = new ContextMenuStrip(components);
            ToolStripMenuItemCopyDirectoryPath = new ToolStripMenuItem();
            ToolStripMenuItemCopyOriginPath = new ToolStripMenuItem();
            tabPageRenamedFiles = new TabPage();
            listViewRenamedFiles = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            contextMenuStripRenamedFiles = new ContextMenuStrip(components);
            ToolStripMenuItemCopySourceFilePath4 = new ToolStripMenuItem();
            ToolStripMenuItemCopyDestinyPath4 = new ToolStripMenuItem();
            tabPageReplacedFiles = new TabPage();
            listViewReplacedFiles = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            contextMenuStripReplacedFiles = new ContextMenuStrip(components);
            ToolStripMenuItemCopySourceFilePath3 = new ToolStripMenuItem();
            ToolStripMenuItemCopyDestinyPath3 = new ToolStripMenuItem();
            tabPageNotTransfered = new TabPage();
            listViewNotTransferedFiles = new ListView();
            columnHeaderNotTransFile = new ColumnHeader();
            columnHeaderNotTransDestiny = new ColumnHeader();
            columnHeaderNotTransReason = new ColumnHeader();
            contextMenuStripNotTransferedFiles = new ContextMenuStrip(components);
            ToolStripMenuItemCopySourceFilePath2 = new ToolStripMenuItem();
            ToolStripMenuItemCopyDestinyPath2 = new ToolStripMenuItem();
            tabPageTransfered = new TabPage();
            listViewTransferedFiles = new ListView();
            columnHeaderTransFile = new ColumnHeader();
            columnHeaderTransDestiny = new ColumnHeader();
            contextMenuStripTransferedFiles = new ContextMenuStrip(components);
            ToolStripMenuItemCopySourceFilePath1 = new ToolStripMenuItem();
            ToolStripMenuItemCopyDestinyPath1 = new ToolStripMenuItem();
            tabControlReport = new TabControl();
            tabPageRemovedFilesAndDirectories = new TabPage();
            listViewRemovedFilesAndDirectories = new ListView();
            columnHeaderEntry = new ColumnHeader();
            columnHeaderDescription = new ColumnHeader();
            contextMenuStripRemovedFilesAndDirectories = new ContextMenuStrip(components);
            toolStripMenuItemCopyEntry = new ToolStripMenuItem();
            tabPageCreatedDirectories.SuspendLayout();
            contextMenuStripCreatedDirectories.SuspendLayout();
            tabPageRenamedFiles.SuspendLayout();
            contextMenuStripRenamedFiles.SuspendLayout();
            tabPageReplacedFiles.SuspendLayout();
            contextMenuStripReplacedFiles.SuspendLayout();
            tabPageNotTransfered.SuspendLayout();
            contextMenuStripNotTransferedFiles.SuspendLayout();
            tabPageTransfered.SuspendLayout();
            contextMenuStripTransferedFiles.SuspendLayout();
            tabControlReport.SuspendLayout();
            tabPageRemovedFilesAndDirectories.SuspendLayout();
            contextMenuStripRemovedFilesAndDirectories.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageCreatedDirectories
            // 
            tabPageCreatedDirectories.Controls.Add(listViewCreatedDirectories);
            tabPageCreatedDirectories.Location = new Point(4, 24);
            tabPageCreatedDirectories.Name = "tabPageCreatedDirectories";
            tabPageCreatedDirectories.Padding = new Padding(3, 3, 3, 3);
            tabPageCreatedDirectories.Size = new Size(1102, 315);
            tabPageCreatedDirectories.TabIndex = 5;
            tabPageCreatedDirectories.Text = "Created Directories";
            tabPageCreatedDirectories.UseVisualStyleBackColor = true;
            // 
            // listViewCreatedDirectories
            // 
            listViewCreatedDirectories.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewCreatedDirectories.ContextMenuStrip = contextMenuStripCreatedDirectories;
            listViewCreatedDirectories.Dock = DockStyle.Fill;
            listViewCreatedDirectories.FullRowSelect = true;
            listViewCreatedDirectories.GridLines = true;
            listViewCreatedDirectories.Location = new Point(3, 3);
            listViewCreatedDirectories.Name = "listViewCreatedDirectories";
            listViewCreatedDirectories.ShowItemToolTips = true;
            listViewCreatedDirectories.Size = new Size(1096, 309);
            listViewCreatedDirectories.TabIndex = 2;
            listViewCreatedDirectories.UseCompatibleStateImageBehavior = false;
            listViewCreatedDirectories.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Directory";
            columnHeader1.Width = 555;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Origin";
            columnHeader2.Width = 535;
            // 
            // contextMenuStripCreatedDirectories
            // 
            contextMenuStripCreatedDirectories.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemCopyDirectoryPath, ToolStripMenuItemCopyOriginPath });
            contextMenuStripCreatedDirectories.Name = "contextMenuStripCreatedDirectories";
            contextMenuStripCreatedDirectories.Size = new Size(214, 48);
            contextMenuStripCreatedDirectories.Opening += ContextMenuStripCreatedDirectories_Opening;
            // 
            // ToolStripMenuItemCopyDirectoryPath
            // 
            ToolStripMenuItemCopyDirectoryPath.Name = "ToolStripMenuItemCopyDirectoryPath";
            ToolStripMenuItemCopyDirectoryPath.Size = new Size(213, 22);
            ToolStripMenuItemCopyDirectoryPath.Text = "Copy directory path";
            ToolStripMenuItemCopyDirectoryPath.Click += ToolStripMenuItemCopyDirectoryPath_Click;
            // 
            // ToolStripMenuItemCopyOriginPath
            // 
            ToolStripMenuItemCopyOriginPath.Name = "ToolStripMenuItemCopyOriginPath";
            ToolStripMenuItemCopyOriginPath.Size = new Size(213, 22);
            ToolStripMenuItemCopyOriginPath.Text = "Copy directory origin path";
            ToolStripMenuItemCopyOriginPath.Click += ToolStripMenuItemCopyOriginPath_Click;
            // 
            // tabPageRenamedFiles
            // 
            tabPageRenamedFiles.Controls.Add(listViewRenamedFiles);
            tabPageRenamedFiles.Location = new Point(4, 24);
            tabPageRenamedFiles.Name = "tabPageRenamedFiles";
            tabPageRenamedFiles.Padding = new Padding(3, 3, 3, 3);
            tabPageRenamedFiles.Size = new Size(1102, 315);
            tabPageRenamedFiles.TabIndex = 3;
            tabPageRenamedFiles.Text = "Renamed Files";
            tabPageRenamedFiles.UseVisualStyleBackColor = true;
            // 
            // listViewRenamedFiles
            // 
            listViewRenamedFiles.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            listViewRenamedFiles.ContextMenuStrip = contextMenuStripRenamedFiles;
            listViewRenamedFiles.Dock = DockStyle.Fill;
            listViewRenamedFiles.FullRowSelect = true;
            listViewRenamedFiles.GridLines = true;
            listViewRenamedFiles.Location = new Point(3, 3);
            listViewRenamedFiles.Name = "listViewRenamedFiles";
            listViewRenamedFiles.ShowItemToolTips = true;
            listViewRenamedFiles.Size = new Size(1096, 309);
            listViewRenamedFiles.TabIndex = 2;
            listViewRenamedFiles.UseCompatibleStateImageBehavior = false;
            listViewRenamedFiles.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Source File";
            columnHeader3.Width = 579;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Destiny File";
            columnHeader4.Width = 512;
            // 
            // contextMenuStripRenamedFiles
            // 
            contextMenuStripRenamedFiles.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemCopySourceFilePath4, ToolStripMenuItemCopyDestinyPath4 });
            contextMenuStripRenamedFiles.Name = "contextMenuStripRenamedFiles";
            contextMenuStripRenamedFiles.Size = new Size(187, 48);
            contextMenuStripRenamedFiles.Opening += ContextMenuStripRenamedFiles_Opening;
            // 
            // ToolStripMenuItemCopySourceFilePath4
            // 
            ToolStripMenuItemCopySourceFilePath4.Name = "ToolStripMenuItemCopySourceFilePath4";
            ToolStripMenuItemCopySourceFilePath4.Size = new Size(186, 22);
            ToolStripMenuItemCopySourceFilePath4.Text = "Copy source file path";
            ToolStripMenuItemCopySourceFilePath4.Click += ToolStripMenuItemCopySourceFilePath4_Click;
            // 
            // ToolStripMenuItemCopyDestinyPath4
            // 
            ToolStripMenuItemCopyDestinyPath4.Name = "ToolStripMenuItemCopyDestinyPath4";
            ToolStripMenuItemCopyDestinyPath4.Size = new Size(186, 22);
            ToolStripMenuItemCopyDestinyPath4.Text = "Copy destiny path";
            ToolStripMenuItemCopyDestinyPath4.Click += ToolStripMenuItemCopyDestinyPath4_Click;
            // 
            // tabPageReplacedFiles
            // 
            tabPageReplacedFiles.Controls.Add(listViewReplacedFiles);
            tabPageReplacedFiles.Location = new Point(4, 24);
            tabPageReplacedFiles.Name = "tabPageReplacedFiles";
            tabPageReplacedFiles.Padding = new Padding(3, 3, 3, 3);
            tabPageReplacedFiles.Size = new Size(1102, 315);
            tabPageReplacedFiles.TabIndex = 2;
            tabPageReplacedFiles.Text = "Replaced Files";
            tabPageReplacedFiles.UseVisualStyleBackColor = true;
            // 
            // listViewReplacedFiles
            // 
            listViewReplacedFiles.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            listViewReplacedFiles.ContextMenuStrip = contextMenuStripReplacedFiles;
            listViewReplacedFiles.Dock = DockStyle.Fill;
            listViewReplacedFiles.FullRowSelect = true;
            listViewReplacedFiles.GridLines = true;
            listViewReplacedFiles.Location = new Point(3, 3);
            listViewReplacedFiles.Name = "listViewReplacedFiles";
            listViewReplacedFiles.ShowItemToolTips = true;
            listViewReplacedFiles.Size = new Size(1096, 309);
            listViewReplacedFiles.TabIndex = 3;
            listViewReplacedFiles.UseCompatibleStateImageBehavior = false;
            listViewReplacedFiles.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Source File";
            columnHeader5.Width = 550;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Destiny";
            columnHeader6.Width = 538;
            // 
            // contextMenuStripReplacedFiles
            // 
            contextMenuStripReplacedFiles.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemCopySourceFilePath3, ToolStripMenuItemCopyDestinyPath3 });
            contextMenuStripReplacedFiles.Name = "contextMenuStripReplacedFiles";
            contextMenuStripReplacedFiles.Size = new Size(187, 48);
            contextMenuStripReplacedFiles.Opening += ContextMenuStripReplacedFiles_Opening;
            // 
            // ToolStripMenuItemCopySourceFilePath3
            // 
            ToolStripMenuItemCopySourceFilePath3.Name = "ToolStripMenuItemCopySourceFilePath3";
            ToolStripMenuItemCopySourceFilePath3.Size = new Size(186, 22);
            ToolStripMenuItemCopySourceFilePath3.Text = "Copy source file path";
            ToolStripMenuItemCopySourceFilePath3.Click += ToolStripMenuItemCopySourceFilePath3_Click;
            // 
            // ToolStripMenuItemCopyDestinyPath3
            // 
            ToolStripMenuItemCopyDestinyPath3.Name = "ToolStripMenuItemCopyDestinyPath3";
            ToolStripMenuItemCopyDestinyPath3.Size = new Size(186, 22);
            ToolStripMenuItemCopyDestinyPath3.Text = "Copy destiny path";
            ToolStripMenuItemCopyDestinyPath3.Click += ToolStripMenuItemCopyDestinyPath3_Click;
            // 
            // tabPageNotTransfered
            // 
            tabPageNotTransfered.Controls.Add(listViewNotTransferedFiles);
            tabPageNotTransfered.Location = new Point(4, 24);
            tabPageNotTransfered.Name = "tabPageNotTransfered";
            tabPageNotTransfered.Padding = new Padding(3, 3, 3, 3);
            tabPageNotTransfered.Size = new Size(1102, 315);
            tabPageNotTransfered.TabIndex = 1;
            tabPageNotTransfered.Text = "Not Transfered";
            tabPageNotTransfered.UseVisualStyleBackColor = true;
            // 
            // listViewNotTransferedFiles
            // 
            listViewNotTransferedFiles.Columns.AddRange(new ColumnHeader[] { columnHeaderNotTransFile, columnHeaderNotTransDestiny, columnHeaderNotTransReason });
            listViewNotTransferedFiles.ContextMenuStrip = contextMenuStripNotTransferedFiles;
            listViewNotTransferedFiles.Dock = DockStyle.Fill;
            listViewNotTransferedFiles.FullRowSelect = true;
            listViewNotTransferedFiles.GridLines = true;
            listViewNotTransferedFiles.Location = new Point(3, 3);
            listViewNotTransferedFiles.Name = "listViewNotTransferedFiles";
            listViewNotTransferedFiles.ShowItemToolTips = true;
            listViewNotTransferedFiles.Size = new Size(1096, 309);
            listViewNotTransferedFiles.TabIndex = 1;
            listViewNotTransferedFiles.UseCompatibleStateImageBehavior = false;
            listViewNotTransferedFiles.View = View.Details;
            // 
            // columnHeaderNotTransFile
            // 
            columnHeaderNotTransFile.Text = "Source File";
            columnHeaderNotTransFile.Width = 537;
            // 
            // columnHeaderNotTransDestiny
            // 
            columnHeaderNotTransDestiny.Text = "Destiny Folder";
            columnHeaderNotTransDestiny.Width = 390;
            // 
            // columnHeaderNotTransReason
            // 
            columnHeaderNotTransReason.Text = "Reason";
            columnHeaderNotTransReason.Width = 269;
            // 
            // contextMenuStripNotTransferedFiles
            // 
            contextMenuStripNotTransferedFiles.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemCopySourceFilePath2, ToolStripMenuItemCopyDestinyPath2 });
            contextMenuStripNotTransferedFiles.Name = "contextMenuStripNotTransferedFiles";
            contextMenuStripNotTransferedFiles.Size = new Size(187, 48);
            contextMenuStripNotTransferedFiles.Opening += ContextMenuStripNotTransferedFiles_Opening;
            // 
            // ToolStripMenuItemCopySourceFilePath2
            // 
            ToolStripMenuItemCopySourceFilePath2.Name = "ToolStripMenuItemCopySourceFilePath2";
            ToolStripMenuItemCopySourceFilePath2.Size = new Size(186, 22);
            ToolStripMenuItemCopySourceFilePath2.Text = "Copy source file path";
            ToolStripMenuItemCopySourceFilePath2.Click += ToolStripMenuItemCopySourceFilePath2_Click;
            // 
            // ToolStripMenuItemCopyDestinyPath2
            // 
            ToolStripMenuItemCopyDestinyPath2.Name = "ToolStripMenuItemCopyDestinyPath2";
            ToolStripMenuItemCopyDestinyPath2.Size = new Size(186, 22);
            ToolStripMenuItemCopyDestinyPath2.Text = "Copy destiny path";
            ToolStripMenuItemCopyDestinyPath2.Click += ToolStripMenuItemCopyDestinyPath2_Click;
            // 
            // tabPageTransfered
            // 
            tabPageTransfered.Controls.Add(listViewTransferedFiles);
            tabPageTransfered.Location = new Point(4, 22);
            tabPageTransfered.Name = "tabPageTransfered";
            tabPageTransfered.Padding = new Padding(3, 3, 3, 3);
            tabPageTransfered.Size = new Size(1102, 317);
            tabPageTransfered.TabIndex = 0;
            tabPageTransfered.Text = "Transfered Files";
            tabPageTransfered.UseVisualStyleBackColor = true;
            // 
            // listViewTransferedFiles
            // 
            listViewTransferedFiles.Columns.AddRange(new ColumnHeader[] { columnHeaderTransFile, columnHeaderTransDestiny });
            listViewTransferedFiles.ContextMenuStrip = contextMenuStripTransferedFiles;
            listViewTransferedFiles.Dock = DockStyle.Fill;
            listViewTransferedFiles.FullRowSelect = true;
            listViewTransferedFiles.GridLines = true;
            listViewTransferedFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewTransferedFiles.Location = new Point(3, 3);
            listViewTransferedFiles.Name = "listViewTransferedFiles";
            listViewTransferedFiles.ShowItemToolTips = true;
            listViewTransferedFiles.Size = new Size(1096, 311);
            listViewTransferedFiles.TabIndex = 0;
            listViewTransferedFiles.UseCompatibleStateImageBehavior = false;
            listViewTransferedFiles.View = View.Details;
            // 
            // columnHeaderTransFile
            // 
            columnHeaderTransFile.Text = "Source File";
            columnHeaderTransFile.Width = 538;
            // 
            // columnHeaderTransDestiny
            // 
            columnHeaderTransDestiny.Text = "Destiny Folder";
            columnHeaderTransDestiny.Width = 550;
            // 
            // contextMenuStripTransferedFiles
            // 
            contextMenuStripTransferedFiles.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemCopySourceFilePath1, ToolStripMenuItemCopyDestinyPath1 });
            contextMenuStripTransferedFiles.Name = "contextMenuStrip1";
            contextMenuStripTransferedFiles.Size = new Size(187, 48);
            contextMenuStripTransferedFiles.Opening += ContextMenuStripTransferedFiles_Opening;
            // 
            // ToolStripMenuItemCopySourceFilePath1
            // 
            ToolStripMenuItemCopySourceFilePath1.Name = "ToolStripMenuItemCopySourceFilePath1";
            ToolStripMenuItemCopySourceFilePath1.Size = new Size(186, 22);
            ToolStripMenuItemCopySourceFilePath1.Text = "Copy source file path";
            ToolStripMenuItemCopySourceFilePath1.Click += ToolStripMenuItemCopySourceFilePath1_Click;
            // 
            // ToolStripMenuItemCopyDestinyPath1
            // 
            ToolStripMenuItemCopyDestinyPath1.Name = "ToolStripMenuItemCopyDestinyPath1";
            ToolStripMenuItemCopyDestinyPath1.Size = new Size(186, 22);
            ToolStripMenuItemCopyDestinyPath1.Text = "Copy destiny path";
            ToolStripMenuItemCopyDestinyPath1.Click += ToolStripMenuItemCopyDestinyPath1_Click;
            // 
            // tabControlReport
            // 
            tabControlReport.Controls.Add(tabPageTransfered);
            tabControlReport.Controls.Add(tabPageNotTransfered);
            tabControlReport.Controls.Add(tabPageReplacedFiles);
            tabControlReport.Controls.Add(tabPageRenamedFiles);
            tabControlReport.Controls.Add(tabPageCreatedDirectories);
            tabControlReport.Controls.Add(tabPageRemovedFilesAndDirectories);
            tabControlReport.Dock = DockStyle.Fill;
            tabControlReport.Location = new Point(0, 0);
            tabControlReport.Name = "tabControlReport";
            tabControlReport.SelectedIndex = 0;
            tabControlReport.ShowToolTips = true;
            tabControlReport.Size = new Size(1110, 343);
            tabControlReport.TabIndex = 1;
            // 
            // tabPageRemovedFilesAndDirectories
            // 
            tabPageRemovedFilesAndDirectories.Controls.Add(listViewRemovedFilesAndDirectories);
            tabPageRemovedFilesAndDirectories.Location = new Point(4, 24);
            tabPageRemovedFilesAndDirectories.Name = "tabPageRemovedFilesAndDirectories";
            tabPageRemovedFilesAndDirectories.Padding = new Padding(3, 3, 3, 3);
            tabPageRemovedFilesAndDirectories.Size = new Size(1102, 315);
            tabPageRemovedFilesAndDirectories.TabIndex = 6;
            tabPageRemovedFilesAndDirectories.Text = "Removed Files/Directories";
            tabPageRemovedFilesAndDirectories.UseVisualStyleBackColor = true;
            // 
            // listViewRemovedFilesAndDirectories
            // 
            listViewRemovedFilesAndDirectories.Columns.AddRange(new ColumnHeader[] { columnHeaderEntry, columnHeaderDescription });
            listViewRemovedFilesAndDirectories.ContextMenuStrip = contextMenuStripRemovedFilesAndDirectories;
            listViewRemovedFilesAndDirectories.Dock = DockStyle.Fill;
            listViewRemovedFilesAndDirectories.FullRowSelect = true;
            listViewRemovedFilesAndDirectories.GridLines = true;
            listViewRemovedFilesAndDirectories.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewRemovedFilesAndDirectories.Location = new Point(3, 3);
            listViewRemovedFilesAndDirectories.Name = "listViewRemovedFilesAndDirectories";
            listViewRemovedFilesAndDirectories.ShowItemToolTips = true;
            listViewRemovedFilesAndDirectories.Size = new Size(1096, 309);
            listViewRemovedFilesAndDirectories.TabIndex = 0;
            listViewRemovedFilesAndDirectories.UseCompatibleStateImageBehavior = false;
            listViewRemovedFilesAndDirectories.View = View.Details;
            // 
            // columnHeaderEntry
            // 
            columnHeaderEntry.Text = "Entry";
            columnHeaderEntry.Width = 555;
            // 
            // columnHeaderDescription
            // 
            columnHeaderDescription.Text = "Description";
            columnHeaderDescription.Width = 535;
            // 
            // contextMenuStripRemovedFilesAndDirectories
            // 
            contextMenuStripRemovedFilesAndDirectories.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCopyEntry });
            contextMenuStripRemovedFilesAndDirectories.Name = "contextMenuStripCreatedDirectories";
            contextMenuStripRemovedFilesAndDirectories.Size = new Size(133, 26);
            contextMenuStripRemovedFilesAndDirectories.Opening += ContextMenuStripRemovedFilesAndDirectories_Opening;
            // 
            // toolStripMenuItemCopyEntry
            // 
            toolStripMenuItemCopyEntry.Name = "toolStripMenuItemCopyEntry";
            toolStripMenuItemCopyEntry.Size = new Size(132, 22);
            toolStripMenuItemCopyEntry.Text = "Copy entry";
            toolStripMenuItemCopyEntry.Click += ToolStripMenuItemCopyEntry_Click;
            // 
            // FormReport
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 343);
            Controls.Add(tabControlReport);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report - Backup Helper";
            FormClosing += FormReport_FormClosing;
            tabPageCreatedDirectories.ResumeLayout(false);
            contextMenuStripCreatedDirectories.ResumeLayout(false);
            tabPageRenamedFiles.ResumeLayout(false);
            contextMenuStripRenamedFiles.ResumeLayout(false);
            tabPageReplacedFiles.ResumeLayout(false);
            contextMenuStripReplacedFiles.ResumeLayout(false);
            tabPageNotTransfered.ResumeLayout(false);
            contextMenuStripNotTransferedFiles.ResumeLayout(false);
            tabPageTransfered.ResumeLayout(false);
            contextMenuStripTransferedFiles.ResumeLayout(false);
            tabControlReport.ResumeLayout(false);
            tabPageRemovedFilesAndDirectories.ResumeLayout(false);
            contextMenuStripRemovedFilesAndDirectories.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabPage tabPageCreatedDirectories;
        private System.Windows.Forms.ListView listViewCreatedDirectories;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPageRenamedFiles;
        private System.Windows.Forms.ListView listViewRenamedFiles;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabPageReplacedFiles;
        private System.Windows.Forms.ListView listViewReplacedFiles;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tabPageNotTransfered;
        private System.Windows.Forms.ListView listViewNotTransferedFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderNotTransFile;
        private System.Windows.Forms.ColumnHeader columnHeaderNotTransDestiny;
        private System.Windows.Forms.ColumnHeader columnHeaderNotTransReason;
        private System.Windows.Forms.TabPage tabPageTransfered;
        private System.Windows.Forms.ListView listViewTransferedFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderTransFile;
        private System.Windows.Forms.ColumnHeader columnHeaderTransDestiny;
        private System.Windows.Forms.TabControl tabControlReport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTransferedFiles;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopySourceFilePath1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyDestinyPath1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotTransferedFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripReplacedFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRenamedFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCreatedDirectories;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopySourceFilePath2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyDestinyPath2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopySourceFilePath3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyDestinyPath3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopySourceFilePath4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyDestinyPath4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyDirectoryPath;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopyOriginPath;
        private System.Windows.Forms.TabPage tabPageRemovedFilesAndDirectories;
        private System.Windows.Forms.ListView listViewRemovedFilesAndDirectories;
        private System.Windows.Forms.ColumnHeader columnHeaderEntry;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRemovedFilesAndDirectories;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyEntry;
    }
}