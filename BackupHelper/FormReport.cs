using FileControlUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormReport : Form
    {
        private readonly FormOptionsMenu OptionsMenu;
        private readonly List<TransferedFilesReport> TransferedFilesReports;
        private readonly List<NotTransferedFilesReport> NotTransferedFilesReports;
        private readonly List<RenamedFilesReport> RenamedFilesReports;
        private readonly List<CreatedDirectoriesReport> CreatedDirectoriesReports;
        private readonly List<ReplacedFilesReport> ReplacedFilesReports;
        private readonly List<RemovedFilesAndDirectoriesReport> RemovedFilesAndDirectoriesReports;

        public FormReport(FormOptionsMenu menu, List<TransferedFilesReport> transferedFiles,
            List<NotTransferedFilesReport> notTransferedFiles, List<RenamedFilesReport> renamedFiles,
            List<CreatedDirectoriesReport> createdDirectories, List<ReplacedFilesReport> replacedFiles,
            List<RemovedFilesAndDirectoriesReport> removedFilesAndDirectories)
        {
            InitializeComponent();
            this.OptionsMenu = menu;
            this.TransferedFilesReports = transferedFiles;
            this.NotTransferedFilesReports = notTransferedFiles;
            this.RenamedFilesReports = renamedFiles;
            this.CreatedDirectoriesReports = createdDirectories;
            this.ReplacedFilesReports = replacedFiles;
            this.RemovedFilesAndDirectoriesReports = removedFilesAndDirectories;

            foreach (TransferedFilesReport report in TransferedFilesReports)
            {
                ListViewItem item = new ListViewItem(report.File);
                item.SubItems.Add(report.Destiny);
                listViewTransferedFiles.Items.Add(item);
            }
            foreach (NotTransferedFilesReport report in NotTransferedFilesReports)
            {
                ListViewItem item = new ListViewItem(report.File);
                item.SubItems.Add(report.Destiny);
                item.SubItems.Add(report.Reason);
                listViewNotTransferedFiles.Items.Add(item);
            }
            foreach (RenamedFilesReport report in RenamedFilesReports)
            {
                ListViewItem item = new ListViewItem(report.File);
                item.SubItems.Add(report.Destiny);
                listViewRenamedFiles.Items.Add(item);
            }
            foreach (CreatedDirectoriesReport report in CreatedDirectoriesReports)
            {
                ListViewItem item = new ListViewItem(report.Directory);
                item.SubItems.Add(report.Origin);
                listViewCreatedDirectories.Items.Add(item);
            }
            foreach (ReplacedFilesReport report in ReplacedFilesReports)
            {
                ListViewItem item = new ListViewItem(report.File);
                item.SubItems.Add(report.Destiny);
                listViewReplacedFiles.Items.Add(item);
            }
            foreach (RemovedFilesAndDirectoriesReport report in RemovedFilesAndDirectoriesReports)
            {
                ListViewItem item = new ListViewItem(report.Entry);
                item.SubItems.Add(report.Description);
                listViewRemovedFilesAndDirectories.Items.Add(item);
            }

            if (transferedFiles.Count != 0)
                tabControlReport.SelectedTab = tabPageTransfered;
            else if (notTransferedFiles.Count != 0)
                tabControlReport.SelectedTab = tabPageNotTransfered;
            else if (replacedFiles.Count != 0)
                tabControlReport.SelectedTab = tabPageReplacedFiles;
            else if (renamedFiles.Count != 0)
                tabControlReport.SelectedTab = tabPageRenamedFiles;
            else if (createdDirectories.Count != 0)
                tabControlReport.SelectedTab = tabPageCreatedDirectories;
            else if (removedFilesAndDirectories.Count != 0)
                tabControlReport.SelectedTab = tabPageRemovedFilesAndDirectories;
        }

        //-- LISTVIEWS CLICK

        private void ContextMenuStripNotTransferedFiles_Opening(object sender, CancelEventArgs e)
        {
            if (listViewNotTransferedFiles.SelectedItems.Count <= 0) e.Cancel = true;
        }

        private void ContextMenuStripTransferedFiles_Opening(object sender, CancelEventArgs e)
        {
            if (listViewTransferedFiles.SelectedItems.Count <= 0) e.Cancel = true;
        }

        private void ContextMenuStripReplacedFiles_Opening(object sender, CancelEventArgs e)
        {
            if (listViewReplacedFiles.SelectedItems.Count <= 0) e.Cancel = true;
        }

        private void ContextMenuStripCreatedDirectories_Opening(object sender, CancelEventArgs e)
        {
            if (listViewCreatedDirectories.SelectedItems.Count <= 0) e.Cancel = true;
        }

        private void ContextMenuStripRemovedFilesAndDirectories_Opening(object sender, CancelEventArgs e)
        {
            if (listViewRemovedFilesAndDirectories.SelectedItems.Count <= 0) e.Cancel = true;
        }

        private void ContextMenuStripRenamedFiles_Opening(object sender, CancelEventArgs e)
        {
            if (listViewRenamedFiles.SelectedItems.Count <= 0) e.Cancel = true;
        }

        //-- TOOLSTRIPS BUTTON CLICKS

        //-- TRANSFERED FILES CONTEXT MENU STRIP BUTTON CLICK
        private void ToolStripMenuItemCopySourceFilePath1_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewTransferedFiles.SelectedItems[0].Text);
        }
        private void ToolStripMenuItemCopyDestinyPath1_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewTransferedFiles.SelectedItems[0].SubItems[1].Text);
        }
        //-- NOT TRANSFERED FILES CONTEXT MENU STRIP BUTTON CLICK
        private void ToolStripMenuItemCopySourceFilePath2_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewNotTransferedFiles.SelectedItems[0].Text);
        }
        private void ToolStripMenuItemCopyDestinyPath2_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewNotTransferedFiles.SelectedItems[0].SubItems[1].Text);
        }
        //-- REPLACED FILES CONTEXT MENU STRIP BUTTON CLICK
        private void ToolStripMenuItemCopySourceFilePath3_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewReplacedFiles.SelectedItems[0].Text);
        }
        private void ToolStripMenuItemCopyDestinyPath3_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewReplacedFiles.SelectedItems[0].SubItems[1].Text);
        }
        //-- RENAMED FILES CONTEXT MENU STRIP BUTTON CLICK
        private void ToolStripMenuItemCopySourceFilePath4_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewRenamedFiles.SelectedItems[0].Text);
        }
        private void ToolStripMenuItemCopyDestinyPath4_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewRenamedFiles.SelectedItems[0].SubItems[1].Text);
        }
        //-- CREATED DIRECTORIES FILES CONTEXT MENU STRIP BUTTON CLICK
        private void ToolStripMenuItemCopyDirectoryPath_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewCreatedDirectories.SelectedItems[0].Text);
        }
        private void ToolStripMenuItemCopyOriginPath_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewCreatedDirectories.SelectedItems[0].SubItems[1].Text);
        }
        //-- REMOVED FILES/DIRECTORIES CONTEXT MENU STRIP BUTTON CLICK
        private void ToolStripMenuItemCopyEntry_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listViewRemovedFilesAndDirectories.SelectedItems[0].Text);
        }

        private void CopyToClipboard(string text)
        {
            try
            {
                Clipboard.SetDataObject(text, false, 5, 200);
            }
            catch (Exception e) {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs args)
        {
            args.Cancel = true;
            this.Hide();
        }
    }
}
