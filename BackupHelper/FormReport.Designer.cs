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
            this.components = new System.ComponentModel.Container();
            this.tabPageCreatedDirectories = new System.Windows.Forms.TabPage();
            this.listViewCreatedDirectories = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRenamedFiles = new System.Windows.Forms.TabPage();
            this.listViewRenamedFiles = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageReplacedFiles = new System.Windows.Forms.TabPage();
            this.listViewReplacedFiles = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageNotTransfered = new System.Windows.Forms.TabPage();
            this.listViewNotTransferedFiles = new System.Windows.Forms.ListView();
            this.columnHeaderNotTransFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNotTransDestiny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNotTransReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripNotTransferedFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCopySourceFilePath2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyDestinyPath2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageTransfered = new System.Windows.Forms.TabPage();
            this.listViewTransferedFiles = new System.Windows.Forms.ListView();
            this.columnHeaderTransFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTransDestiny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabPageRemovedFilesAndDirectories = new System.Windows.Forms.TabPage();
            this.listViewRemovedFilesAndDirectories = new System.Windows.Forms.ListView();
            this.columnHeaderEntry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripTransferedFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCopySourceFilePath1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyDestinyPath1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripReplacedFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCopySourceFilePath3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyDestinyPath3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRenamedFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCopySourceFilePath4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyDestinyPath4 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCreatedDirectories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemCopyDirectoryPath = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCopyOriginPath = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRemovedFilesAndDirectories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCopyEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageCreatedDirectories.SuspendLayout();
            this.tabPageRenamedFiles.SuspendLayout();
            this.tabPageReplacedFiles.SuspendLayout();
            this.tabPageNotTransfered.SuspendLayout();
            this.contextMenuStripNotTransferedFiles.SuspendLayout();
            this.tabPageTransfered.SuspendLayout();
            this.tabControlReport.SuspendLayout();
            this.tabPageRemovedFilesAndDirectories.SuspendLayout();
            this.contextMenuStripTransferedFiles.SuspendLayout();
            this.contextMenuStripReplacedFiles.SuspendLayout();
            this.contextMenuStripRenamedFiles.SuspendLayout();
            this.contextMenuStripCreatedDirectories.SuspendLayout();
            this.contextMenuStripRemovedFilesAndDirectories.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageCreatedDirectories
            // 
            this.tabPageCreatedDirectories.Controls.Add(this.listViewCreatedDirectories);
            this.tabPageCreatedDirectories.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreatedDirectories.Name = "tabPageCreatedDirectories";
            this.tabPageCreatedDirectories.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreatedDirectories.Size = new System.Drawing.Size(1102, 317);
            this.tabPageCreatedDirectories.TabIndex = 5;
            this.tabPageCreatedDirectories.Text = "Created Directories";
            this.tabPageCreatedDirectories.UseVisualStyleBackColor = true;
            // 
            // listViewCreatedDirectories
            // 
            this.listViewCreatedDirectories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewCreatedDirectories.ContextMenuStrip = this.contextMenuStripCreatedDirectories;
            this.listViewCreatedDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCreatedDirectories.FullRowSelect = true;
            this.listViewCreatedDirectories.GridLines = true;
            this.listViewCreatedDirectories.HideSelection = false;
            this.listViewCreatedDirectories.Location = new System.Drawing.Point(3, 3);
            this.listViewCreatedDirectories.Name = "listViewCreatedDirectories";
            this.listViewCreatedDirectories.ShowItemToolTips = true;
            this.listViewCreatedDirectories.Size = new System.Drawing.Size(1096, 311);
            this.listViewCreatedDirectories.TabIndex = 2;
            this.listViewCreatedDirectories.UseCompatibleStateImageBehavior = false;
            this.listViewCreatedDirectories.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Directory";
            this.columnHeader1.Width = 555;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Origin";
            this.columnHeader2.Width = 535;
            // 
            // tabPageRenamedFiles
            // 
            this.tabPageRenamedFiles.Controls.Add(this.listViewRenamedFiles);
            this.tabPageRenamedFiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageRenamedFiles.Name = "tabPageRenamedFiles";
            this.tabPageRenamedFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRenamedFiles.Size = new System.Drawing.Size(1102, 317);
            this.tabPageRenamedFiles.TabIndex = 3;
            this.tabPageRenamedFiles.Text = "Renamed Files";
            this.tabPageRenamedFiles.UseVisualStyleBackColor = true;
            // 
            // listViewRenamedFiles
            // 
            this.listViewRenamedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewRenamedFiles.ContextMenuStrip = this.contextMenuStripRenamedFiles;
            this.listViewRenamedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRenamedFiles.FullRowSelect = true;
            this.listViewRenamedFiles.GridLines = true;
            this.listViewRenamedFiles.HideSelection = false;
            this.listViewRenamedFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewRenamedFiles.Name = "listViewRenamedFiles";
            this.listViewRenamedFiles.ShowItemToolTips = true;
            this.listViewRenamedFiles.Size = new System.Drawing.Size(1096, 311);
            this.listViewRenamedFiles.TabIndex = 2;
            this.listViewRenamedFiles.UseCompatibleStateImageBehavior = false;
            this.listViewRenamedFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Source File";
            this.columnHeader3.Width = 579;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Destiny File";
            this.columnHeader4.Width = 512;
            // 
            // tabPageReplacedFiles
            // 
            this.tabPageReplacedFiles.Controls.Add(this.listViewReplacedFiles);
            this.tabPageReplacedFiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageReplacedFiles.Name = "tabPageReplacedFiles";
            this.tabPageReplacedFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReplacedFiles.Size = new System.Drawing.Size(1102, 317);
            this.tabPageReplacedFiles.TabIndex = 2;
            this.tabPageReplacedFiles.Text = "Replaced Files";
            this.tabPageReplacedFiles.UseVisualStyleBackColor = true;
            // 
            // listViewReplacedFiles
            // 
            this.listViewReplacedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewReplacedFiles.ContextMenuStrip = this.contextMenuStripReplacedFiles;
            this.listViewReplacedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReplacedFiles.FullRowSelect = true;
            this.listViewReplacedFiles.GridLines = true;
            this.listViewReplacedFiles.HideSelection = false;
            this.listViewReplacedFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewReplacedFiles.Name = "listViewReplacedFiles";
            this.listViewReplacedFiles.ShowItemToolTips = true;
            this.listViewReplacedFiles.Size = new System.Drawing.Size(1096, 311);
            this.listViewReplacedFiles.TabIndex = 3;
            this.listViewReplacedFiles.UseCompatibleStateImageBehavior = false;
            this.listViewReplacedFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Source File";
            this.columnHeader5.Width = 550;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Destiny";
            this.columnHeader6.Width = 538;
            // 
            // tabPageNotTransfered
            // 
            this.tabPageNotTransfered.Controls.Add(this.listViewNotTransferedFiles);
            this.tabPageNotTransfered.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotTransfered.Name = "tabPageNotTransfered";
            this.tabPageNotTransfered.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotTransfered.Size = new System.Drawing.Size(1102, 317);
            this.tabPageNotTransfered.TabIndex = 1;
            this.tabPageNotTransfered.Text = "Not Transfered";
            this.tabPageNotTransfered.UseVisualStyleBackColor = true;
            // 
            // listViewNotTransferedFiles
            // 
            this.listViewNotTransferedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNotTransFile,
            this.columnHeaderNotTransDestiny,
            this.columnHeaderNotTransReason});
            this.listViewNotTransferedFiles.ContextMenuStrip = this.contextMenuStripNotTransferedFiles;
            this.listViewNotTransferedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNotTransferedFiles.FullRowSelect = true;
            this.listViewNotTransferedFiles.GridLines = true;
            this.listViewNotTransferedFiles.HideSelection = false;
            this.listViewNotTransferedFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewNotTransferedFiles.Name = "listViewNotTransferedFiles";
            this.listViewNotTransferedFiles.ShowItemToolTips = true;
            this.listViewNotTransferedFiles.Size = new System.Drawing.Size(1096, 311);
            this.listViewNotTransferedFiles.TabIndex = 1;
            this.listViewNotTransferedFiles.UseCompatibleStateImageBehavior = false;
            this.listViewNotTransferedFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNotTransFile
            // 
            this.columnHeaderNotTransFile.Text = "Source File";
            this.columnHeaderNotTransFile.Width = 537;
            // 
            // columnHeaderNotTransDestiny
            // 
            this.columnHeaderNotTransDestiny.Text = "Destiny Folder";
            this.columnHeaderNotTransDestiny.Width = 390;
            // 
            // columnHeaderNotTransReason
            // 
            this.columnHeaderNotTransReason.Text = "Reason";
            this.columnHeaderNotTransReason.Width = 269;
            // 
            // contextMenuStripNotTransferedFiles
            // 
            this.contextMenuStripNotTransferedFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopySourceFilePath2,
            this.ToolStripMenuItemCopyDestinyPath2});
            this.contextMenuStripNotTransferedFiles.Name = "contextMenuStripNotTransferedFiles";
            this.contextMenuStripNotTransferedFiles.Size = new System.Drawing.Size(187, 48);
            this.contextMenuStripNotTransferedFiles.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStripNotTransferedFiles_Opening);
            // 
            // ToolStripMenuItemCopySourceFilePath2
            // 
            this.ToolStripMenuItemCopySourceFilePath2.Name = "ToolStripMenuItemCopySourceFilePath2";
            this.ToolStripMenuItemCopySourceFilePath2.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopySourceFilePath2.Text = "Copy source file path";
            this.ToolStripMenuItemCopySourceFilePath2.Click += new System.EventHandler(this.ToolStripMenuItemCopySourceFilePath2_Click);
            // 
            // ToolStripMenuItemCopyDestinyPath2
            // 
            this.ToolStripMenuItemCopyDestinyPath2.Name = "ToolStripMenuItemCopyDestinyPath2";
            this.ToolStripMenuItemCopyDestinyPath2.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopyDestinyPath2.Text = "Copy destiny path";
            this.ToolStripMenuItemCopyDestinyPath2.Click += new System.EventHandler(this.ToolStripMenuItemCopyDestinyPath2_Click);
            // 
            // tabPageTransfered
            // 
            this.tabPageTransfered.Controls.Add(this.listViewTransferedFiles);
            this.tabPageTransfered.Location = new System.Drawing.Point(4, 22);
            this.tabPageTransfered.Name = "tabPageTransfered";
            this.tabPageTransfered.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransfered.Size = new System.Drawing.Size(1102, 317);
            this.tabPageTransfered.TabIndex = 0;
            this.tabPageTransfered.Text = "Transfered Files";
            this.tabPageTransfered.UseVisualStyleBackColor = true;
            // 
            // listViewTransferedFiles
            // 
            this.listViewTransferedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTransFile,
            this.columnHeaderTransDestiny});
            this.listViewTransferedFiles.ContextMenuStrip = this.contextMenuStripTransferedFiles;
            this.listViewTransferedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTransferedFiles.FullRowSelect = true;
            this.listViewTransferedFiles.GridLines = true;
            this.listViewTransferedFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTransferedFiles.HideSelection = false;
            this.listViewTransferedFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewTransferedFiles.Name = "listViewTransferedFiles";
            this.listViewTransferedFiles.ShowItemToolTips = true;
            this.listViewTransferedFiles.Size = new System.Drawing.Size(1096, 311);
            this.listViewTransferedFiles.TabIndex = 0;
            this.listViewTransferedFiles.UseCompatibleStateImageBehavior = false;
            this.listViewTransferedFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTransFile
            // 
            this.columnHeaderTransFile.Text = "Source File";
            this.columnHeaderTransFile.Width = 538;
            // 
            // columnHeaderTransDestiny
            // 
            this.columnHeaderTransDestiny.Text = "Destiny Folder";
            this.columnHeaderTransDestiny.Width = 550;
            // 
            // tabControlReport
            // 
            this.tabControlReport.Controls.Add(this.tabPageTransfered);
            this.tabControlReport.Controls.Add(this.tabPageNotTransfered);
            this.tabControlReport.Controls.Add(this.tabPageReplacedFiles);
            this.tabControlReport.Controls.Add(this.tabPageRenamedFiles);
            this.tabControlReport.Controls.Add(this.tabPageCreatedDirectories);
            this.tabControlReport.Controls.Add(this.tabPageRemovedFilesAndDirectories);
            this.tabControlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReport.Location = new System.Drawing.Point(0, 0);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.ShowToolTips = true;
            this.tabControlReport.Size = new System.Drawing.Size(1110, 343);
            this.tabControlReport.TabIndex = 1;
            // 
            // tabPageRemovedFilesAndDirectories
            // 
            this.tabPageRemovedFilesAndDirectories.Controls.Add(this.listViewRemovedFilesAndDirectories);
            this.tabPageRemovedFilesAndDirectories.Location = new System.Drawing.Point(4, 22);
            this.tabPageRemovedFilesAndDirectories.Name = "tabPageRemovedFilesAndDirectories";
            this.tabPageRemovedFilesAndDirectories.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRemovedFilesAndDirectories.Size = new System.Drawing.Size(1102, 317);
            this.tabPageRemovedFilesAndDirectories.TabIndex = 6;
            this.tabPageRemovedFilesAndDirectories.Text = "Removed Files/Directories";
            this.tabPageRemovedFilesAndDirectories.UseVisualStyleBackColor = true;
            // 
            // listViewRemovedFilesAndDirectories
            // 
            this.listViewRemovedFilesAndDirectories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEntry,
            this.columnHeaderDescription});
            this.listViewRemovedFilesAndDirectories.ContextMenuStrip = this.contextMenuStripRemovedFilesAndDirectories;
            this.listViewRemovedFilesAndDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRemovedFilesAndDirectories.FullRowSelect = true;
            this.listViewRemovedFilesAndDirectories.GridLines = true;
            this.listViewRemovedFilesAndDirectories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRemovedFilesAndDirectories.HideSelection = false;
            this.listViewRemovedFilesAndDirectories.Location = new System.Drawing.Point(3, 3);
            this.listViewRemovedFilesAndDirectories.Name = "listViewRemovedFilesAndDirectories";
            this.listViewRemovedFilesAndDirectories.ShowItemToolTips = true;
            this.listViewRemovedFilesAndDirectories.Size = new System.Drawing.Size(1096, 311);
            this.listViewRemovedFilesAndDirectories.TabIndex = 0;
            this.listViewRemovedFilesAndDirectories.UseCompatibleStateImageBehavior = false;
            this.listViewRemovedFilesAndDirectories.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderEntry
            // 
            this.columnHeaderEntry.Text = "Entry";
            this.columnHeaderEntry.Width = 555;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 535;
            // 
            // contextMenuStripTransferedFiles
            // 
            this.contextMenuStripTransferedFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopySourceFilePath1,
            this.ToolStripMenuItemCopyDestinyPath1});
            this.contextMenuStripTransferedFiles.Name = "contextMenuStrip1";
            this.contextMenuStripTransferedFiles.Size = new System.Drawing.Size(187, 48);
            this.contextMenuStripTransferedFiles.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStripTransferedFiles_Opening);
            // 
            // ToolStripMenuItemCopySourceFilePath1
            // 
            this.ToolStripMenuItemCopySourceFilePath1.Name = "ToolStripMenuItemCopySourceFilePath1";
            this.ToolStripMenuItemCopySourceFilePath1.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopySourceFilePath1.Text = "Copy source file path";
            this.ToolStripMenuItemCopySourceFilePath1.Click += new System.EventHandler(this.ToolStripMenuItemCopySourceFilePath1_Click);
            // 
            // ToolStripMenuItemCopyDestinyPath1
            // 
            this.ToolStripMenuItemCopyDestinyPath1.Name = "ToolStripMenuItemCopyDestinyPath1";
            this.ToolStripMenuItemCopyDestinyPath1.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopyDestinyPath1.Text = "Copy destiny path";
            this.ToolStripMenuItemCopyDestinyPath1.Click += new System.EventHandler(this.ToolStripMenuItemCopyDestinyPath1_Click);
            // 
            // contextMenuStripReplacedFiles
            // 
            this.contextMenuStripReplacedFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopySourceFilePath3,
            this.ToolStripMenuItemCopyDestinyPath3});
            this.contextMenuStripReplacedFiles.Name = "contextMenuStripReplacedFiles";
            this.contextMenuStripReplacedFiles.Size = new System.Drawing.Size(187, 48);
            this.contextMenuStripReplacedFiles.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStripReplacedFiles_Opening);
            // 
            // ToolStripMenuItemCopySourceFilePath3
            // 
            this.ToolStripMenuItemCopySourceFilePath3.Name = "ToolStripMenuItemCopySourceFilePath3";
            this.ToolStripMenuItemCopySourceFilePath3.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopySourceFilePath3.Text = "Copy source file path";
            this.ToolStripMenuItemCopySourceFilePath3.Click += new System.EventHandler(this.ToolStripMenuItemCopySourceFilePath3_Click);
            // 
            // ToolStripMenuItemCopyDestinyPath3
            // 
            this.ToolStripMenuItemCopyDestinyPath3.Name = "ToolStripMenuItemCopyDestinyPath3";
            this.ToolStripMenuItemCopyDestinyPath3.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopyDestinyPath3.Text = "Copy destiny path";
            this.ToolStripMenuItemCopyDestinyPath3.Click += new System.EventHandler(this.ToolStripMenuItemCopyDestinyPath3_Click);
            // 
            // contextMenuStripRenamedFiles
            // 
            this.contextMenuStripRenamedFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopySourceFilePath4,
            this.ToolStripMenuItemCopyDestinyPath4});
            this.contextMenuStripRenamedFiles.Name = "contextMenuStripRenamedFiles";
            this.contextMenuStripRenamedFiles.Size = new System.Drawing.Size(187, 48);
            this.contextMenuStripRenamedFiles.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStripRenamedFiles_Opening);
            // 
            // ToolStripMenuItemCopySourceFilePath4
            // 
            this.ToolStripMenuItemCopySourceFilePath4.Name = "ToolStripMenuItemCopySourceFilePath4";
            this.ToolStripMenuItemCopySourceFilePath4.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopySourceFilePath4.Text = "Copy source file path";
            this.ToolStripMenuItemCopySourceFilePath4.Click += new System.EventHandler(this.ToolStripMenuItemCopySourceFilePath4_Click);
            // 
            // ToolStripMenuItemCopyDestinyPath4
            // 
            this.ToolStripMenuItemCopyDestinyPath4.Name = "ToolStripMenuItemCopyDestinyPath4";
            this.ToolStripMenuItemCopyDestinyPath4.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemCopyDestinyPath4.Text = "Copy destiny path";
            this.ToolStripMenuItemCopyDestinyPath4.Click += new System.EventHandler(this.ToolStripMenuItemCopyDestinyPath4_Click);
            // 
            // contextMenuStripCreatedDirectories
            // 
            this.contextMenuStripCreatedDirectories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCopyDirectoryPath,
            this.ToolStripMenuItemCopyOriginPath});
            this.contextMenuStripCreatedDirectories.Name = "contextMenuStripCreatedDirectories";
            this.contextMenuStripCreatedDirectories.Size = new System.Drawing.Size(214, 48);
            this.contextMenuStripCreatedDirectories.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStripCreatedDirectories_Opening);
            // 
            // ToolStripMenuItemCopyDirectoryPath
            // 
            this.ToolStripMenuItemCopyDirectoryPath.Name = "ToolStripMenuItemCopyDirectoryPath";
            this.ToolStripMenuItemCopyDirectoryPath.Size = new System.Drawing.Size(213, 22);
            this.ToolStripMenuItemCopyDirectoryPath.Text = "Copy directory path";
            this.ToolStripMenuItemCopyDirectoryPath.Click += new System.EventHandler(this.ToolStripMenuItemCopyDirectoryPath_Click);
            // 
            // ToolStripMenuItemCopyOriginPath
            // 
            this.ToolStripMenuItemCopyOriginPath.Name = "ToolStripMenuItemCopyOriginPath";
            this.ToolStripMenuItemCopyOriginPath.Size = new System.Drawing.Size(213, 22);
            this.ToolStripMenuItemCopyOriginPath.Text = "Copy directory origin path";
            this.ToolStripMenuItemCopyOriginPath.Click += new System.EventHandler(this.ToolStripMenuItemCopyOriginPath_Click);
            // 
            // contextMenuStripRemovedFilesAndDirectories
            // 
            this.contextMenuStripRemovedFilesAndDirectories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopyEntry});
            this.contextMenuStripRemovedFilesAndDirectories.Name = "contextMenuStripCreatedDirectories";
            this.contextMenuStripRemovedFilesAndDirectories.Size = new System.Drawing.Size(133, 26);
            this.contextMenuStripRemovedFilesAndDirectories.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStripRemovedFilesAndDirectories_Opening);
            // 
            // toolStripMenuItemCopyEntry
            // 
            this.toolStripMenuItemCopyEntry.Name = "toolStripMenuItemCopyEntry";
            this.toolStripMenuItemCopyEntry.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItemCopyEntry.Text = "Copy entry";
            this.toolStripMenuItemCopyEntry.Click += new System.EventHandler(this.ToolStripMenuItemCopyEntry_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 343);
            this.Controls.Add(this.tabControlReport);
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report - Backup Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReport_FormClosing);
            this.tabPageCreatedDirectories.ResumeLayout(false);
            this.tabPageRenamedFiles.ResumeLayout(false);
            this.tabPageReplacedFiles.ResumeLayout(false);
            this.tabPageNotTransfered.ResumeLayout(false);
            this.contextMenuStripNotTransferedFiles.ResumeLayout(false);
            this.tabPageTransfered.ResumeLayout(false);
            this.tabControlReport.ResumeLayout(false);
            this.tabPageRemovedFilesAndDirectories.ResumeLayout(false);
            this.contextMenuStripTransferedFiles.ResumeLayout(false);
            this.contextMenuStripReplacedFiles.ResumeLayout(false);
            this.contextMenuStripRenamedFiles.ResumeLayout(false);
            this.contextMenuStripCreatedDirectories.ResumeLayout(false);
            this.contextMenuStripRemovedFilesAndDirectories.ResumeLayout(false);
            this.ResumeLayout(false);

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