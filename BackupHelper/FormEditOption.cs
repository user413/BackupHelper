using BackupHelper.model;
using FileControlUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BackupHelper
{
    public enum FormAction
    {
        EDIT, CREATE
    }

    public partial class FormEditOption : Form
    {
        private readonly FormOptionsMenu OptionsMenu;
        public Option Option;
        private readonly FormAction FormAction = FormAction.CREATE;

        public FormEditOption(FormOptionsMenu optionsMenu, Option option = null)
        {
            InitializeComponent();

            OptionsMenu = optionsMenu;

            if (option != null)
            {
                FormAction = FormAction.EDIT;
                this.Option = option;
                FillCamps(option);
            }
            else
            {
                this.Text = "Add option";

                FillCamps(new Option {
                    SourcePath = "C:\\origin...",
                    DestinyPath = "C:\\destiny...",
                    FileNameConflictMethod = FileNameConflictMethod.DO_NOT_MOVE,
                    MoveSubFolders = true,
                    KeepOriginFiles = true,
                    CleanDestinyDirectory = false,
                    AllowIgnoreFileExt = false,
                    DeleteUncommonFiles = false,
                    SpecifiedFileNamesAndExtensions = new List<string>()
                });
            }

            this.KeyDown += new KeyEventHandler(this.FormEditOption_KeyDown);
            this.KeyPreview = true;
        }

        private void FillCamps(Option option)
        {
            try
            {
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.DO_NOT_MOVE, option.GetTransferMethodDescription(FileNameConflictMethod.DO_NOT_MOVE));
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.REPLACE_ALL, option.GetTransferMethodDescription(FileNameConflictMethod.REPLACE_ALL));
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.REPLACE_DIFFERENT, option.GetTransferMethodDescription(FileNameConflictMethod.REPLACE_DIFFERENT));
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.RENAME_DIFFERENT, option.GetTransferMethodDescription(FileNameConflictMethod.RENAME_DIFFERENT));

                comboBoxMethod.SelectedIndex = (int)option.FileNameConflictMethod;

                textBoxSourcePath.Text = option.SourcePath;
                textBoxDestinyPath.Text = option.DestinyPath;
                checkBoxMoveSubfolders.Checked = option.MoveSubFolders;
                checkBoxKeepOriginFiles.Checked = option.KeepOriginFiles;
                checkBoxCleanDestinyDirectory.Checked = option.CleanDestinyDirectory;
                checkBoxDeleteUncommonFiles.Checked = option.DeleteUncommonFiles;
                checkBoxManageFileNamesAndExtensions.Checked = option.AllowIgnoreFileExt;

                if (option.SpecifiedFileNamesOrExtensionsMode == SpecifiedFileNamesAndExtensionsMode.IGNORE)
                    radioButtonIgnore.Checked = true;

                foreach (string txt in option.SpecifiedFileNamesAndExtensions)
                {
                    ListViewItem item = new ListViewItem(txt);
                    listViewFileNamesAndExtensions.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }
        }

        private void ButtonDoneEdit_Click(object sender, EventArgs e)
        {
            SubmitChanges();

            if (DialogResult != DialogResult.None)
                Close();
        }

        private void SubmitChanges()
        {
            try
            {
                Option editedOption = new Option();
                SaveCampsToObject(editedOption);
                if (!InputsAreValid(editedOption)) return;

                if (FormAction == FormAction.CREATE)
                {
                    editedOption.Profile = OptionsMenu.Profile;
                    editedOption.ListViewIndex = OptionsMenu.listViewOptions.Items.Count;
                    DBAccess.AddOption(editedOption);
                    OptionsMenu.Options.Add(editedOption);
                    Program.UpdateLastTimeModified(editedOption.Profile);
                    ListViewItem item = new ListViewItem();
                    OptionsMenu.EditListViewItem(editedOption,item);
                    OptionsMenu.listViewOptions.Items.Add(item);
                    OptionsMenu.ResizeForm();
                }
                else
                {
                    if (
                        !(
                            Option.SourcePath == editedOption.SourcePath &&
                            Option.DestinyPath == editedOption.DestinyPath &&
                            Option.FileNameConflictMethod == editedOption.FileNameConflictMethod &&
                            Option.SpecifiedFileNamesOrExtensionsMode == editedOption.SpecifiedFileNamesOrExtensionsMode &&
                            Option.MoveSubFolders == editedOption.MoveSubFolders &&
                            Option.KeepOriginFiles == editedOption.KeepOriginFiles &&
                            Option.CleanDestinyDirectory == editedOption.CleanDestinyDirectory &&
                            Option.DeleteUncommonFiles == editedOption.DeleteUncommonFiles &&
                            Option.AllowIgnoreFileExt == editedOption.AllowIgnoreFileExt &&
                            ExtensionsAreTheSame(Option.SpecifiedFileNamesAndExtensions, editedOption.SpecifiedFileNamesAndExtensions)
                        )
                    )
                    {
                        Option.SourcePath = editedOption.SourcePath;
                        Option.DestinyPath = editedOption.DestinyPath;
                        Option.FileNameConflictMethod = editedOption.FileNameConflictMethod;
                        Option.SpecifiedFileNamesOrExtensionsMode = editedOption.SpecifiedFileNamesOrExtensionsMode;
                        Option.MoveSubFolders = editedOption.MoveSubFolders;
                        Option.KeepOriginFiles = editedOption.KeepOriginFiles;
                        Option.CleanDestinyDirectory = editedOption.CleanDestinyDirectory;
                        Option.DeleteUncommonFiles = editedOption.DeleteUncommonFiles;
                        Option.AllowIgnoreFileExt = editedOption.AllowIgnoreFileExt;
                        Option.SpecifiedFileNamesAndExtensions = editedOption.SpecifiedFileNamesAndExtensions;

                        DBAccess.UpdateOption(Option);
                        Program.UpdateLastTimeModified(Option.Profile);
                        OptionsMenu.EditListViewItem(Option);
                    }
                }
                
                DialogResult = DialogResult.Cancel;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool InputsAreValid(Option editedOption)
        {
            if(editedOption.SourcePath == "")
            {
                MessageBox.Show("Invalid source path.");
                return false;
            }

            if (editedOption.DestinyPath == "")
            {
                MessageBox.Show("Invalid destiny path.");
                return false;
            }

            return true;
        }

        private bool ExtensionsAreTheSame(List<string> fileExtensions1, List<string> fileExtensions2)
        {
            if (fileExtensions1.Count != fileExtensions2.Count) return false;

            foreach(string extension in fileExtensions1)
                if (!fileExtensions2.Contains(extension)) return false;

            return true;
        }

        private void SaveCampsToObject(Option editedOption)
        {
            editedOption.SourcePath = textBoxSourcePath.Text;
            editedOption.DestinyPath = textBoxDestinyPath.Text;
            editedOption.FileNameConflictMethod = (FileNameConflictMethod)comboBoxMethod.SelectedIndex;
            editedOption.SpecifiedFileNamesOrExtensionsMode = radioButtonIgnore.Checked ? SpecifiedFileNamesAndExtensionsMode.IGNORE :
                SpecifiedFileNamesAndExtensionsMode.ALLOW_ONLY;
            editedOption.MoveSubFolders = checkBoxMoveSubfolders.Checked;
            editedOption.KeepOriginFiles = checkBoxKeepOriginFiles.Checked;
            editedOption.CleanDestinyDirectory = checkBoxCleanDestinyDirectory.Checked;
            editedOption.DeleteUncommonFiles = checkBoxDeleteUncommonFiles.Checked;
            editedOption.AllowIgnoreFileExt = checkBoxManageFileNamesAndExtensions.Checked;
            editedOption.SpecifiedFileNamesAndExtensions = ListViewFileExtensionsToList();
        }

        private List<string> ListViewFileExtensionsToList()
        {
            List<string> extensions = new List<string>();

            foreach(ListViewItem item in listViewFileNamesAndExtensions.Items)
                extensions.Add(item.Text);

            return extensions;
        }

        private void ButtonAddSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialogEditOption.SelectedPath = textBoxSourcePath.Text;
            folderBrowserDialogEditOption.Description = "Select source directory path";
            folderBrowserDialogEditOption.ShowDialog(this);
            textBoxSourcePath.Text = folderBrowserDialogEditOption.SelectedPath;
        }

        private void ButtonAddDestiny_Click(object sender, EventArgs e)
        {
            folderBrowserDialogEditOption.SelectedPath = textBoxDestinyPath.Text;
            folderBrowserDialogEditOption.Description = "Select destiny directory path";
            folderBrowserDialogEditOption.ShowDialog(this);
            textBoxDestinyPath.Text = folderBrowserDialogEditOption.SelectedPath;
        }

        private void CheckBoxCleanDestinyDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCleanDestinyDirectory.Checked == true)
            {
                comboBoxMethod.Enabled = false;
                labelMethod.Enabled = false;
                checkBoxDeleteUncommonFiles.Enabled = false;
            }
            else
            {
                comboBoxMethod.Enabled = true;
                labelMethod.Enabled = true;
                checkBoxDeleteUncommonFiles.Enabled = true;
            }
        }

        private void CheckBoxDeleteUncommonFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDeleteUncommonFiles.Checked)
            {
                if(comboBoxMethod.SelectedIndex == 3)
                    comboBoxMethod.SelectedIndex = 0;
            }
        }

        private void ComboBoxMethod_DrawItem(object sender,DrawItemEventArgs args)
        {
            if (checkBoxDeleteUncommonFiles.Checked && args.Index == 3)
            {
                args.Graphics.DrawString(comboBoxMethod.Items[args.Index].ToString(), args.Font, Brushes.LightGray, args.Bounds);
            }
            else
            {
                args.DrawBackground();
                args.Graphics.DrawString(comboBoxMethod.Items[args.Index].ToString(), args.Font, Brushes.Black, args.Bounds);
                args.DrawFocusRectangle();
            }
        }

        private void ComboBoxMethod_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (checkBoxDeleteUncommonFiles.Checked && comboBoxMethod.SelectedIndex == 3)
                comboBoxMethod.SelectedIndex = 0;
        }

        private void ButtonSwitchPaths_Click(object sender, EventArgs e)
        {
            string sourcePath = textBoxSourcePath.Text;
            string destinyPath = textBoxDestinyPath.Text;
            textBoxSourcePath.Text = destinyPath;
            textBoxDestinyPath.Text = sourcePath;
        }


        //-- ################ FILENAMES AND EXTENSIONS METHODS ################

        private void CheckBoxManageFileExtensions_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxManageFileNamesAndExtensions.Checked == true)
            {
                radioButtonAllowOnly.Enabled = true;
                radioButtonIgnore.Enabled = true;
                listViewFileNamesAndExtensions.Enabled = true;
                listViewFileNamesAndExtensions.ForeColor = System.Drawing.SystemColors.WindowText;
                textBoxFileNameOrExtension.Enabled = true;
                buttonAddFileOrExtension.Enabled = true;
                buttonRemoveFileOrExtension.Enabled = true;
            }
            else
            {
                radioButtonAllowOnly.Enabled = false;
                radioButtonIgnore.Enabled = false;
                listViewFileNamesAndExtensions.Enabled = false;
                listViewFileNamesAndExtensions.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                textBoxFileNameOrExtension.Enabled = false;
                buttonAddFileOrExtension.Enabled = false;
                buttonRemoveFileOrExtension.Enabled = false;
            }
        }

        private void ButtonAddExtension_Click(object sender, EventArgs e)
        {
            AddListViewExtension();
        }

        private bool FileNameOrExtensionIsValid(string text)
        {
            int length = textBoxFileNameOrExtension.Text.Length;
            if (text == "" || text.Substring(length - 1) == ".") return false;

            foreach (char s in Path.GetInvalidFileNameChars())
                if (text.Contains(s.ToString())) return false;

            //|| text.Substring(0, 1) != "." || text.Substring(1, 1) == "."
            return true;
        }

        private void ButtonRemoveExtension_Click(object sender, EventArgs e)
        {
            RemoveListViewExtension();
        }

        private void RemoveListViewExtension()
        {
            //-- REMOVE SELECTED
            if (listViewFileNamesAndExtensions.SelectedItems.Count > 0)
            {
                listViewFileNamesAndExtensions.SelectedItems[0].Remove();
                return;
            }
            //-- REMOVE TYPED
            else if (textBoxFileNameOrExtension.Text != "") //ExtensionStringIsValid()
            {
                if (listViewFileNamesAndExtensions.Items.Count == 0) return;

                ListViewItem listViewItem = FindListViewExtensionsItem(textBoxFileNameOrExtension.Text);

                if (listViewItem != null)
                    listViewFileNamesAndExtensions.Items.Remove(listViewItem);
                //else
                //    MessageBox.Show($"No extension named \"{textBoxExtension.Text}\".");

                return;
            }

            MessageBox.Show("Select or type an existing extension to be removed.");
        }

        private ListViewItem FindListViewExtensionsItem(string text)
        {
            foreach (ListViewItem item in listViewFileNamesAndExtensions.Items)
            {
                if (item.Text == text)
                    return item;
            }
            
            return null;
        }

        private void AddListViewExtension()
        {
            if (!FileNameOrExtensionIsValid(textBoxFileNameOrExtension.Text))
            {
                MessageBox.Show("Enter a valid filename or extension name,e.g.,\".txt\",\"myfile.exe\".");
                return;
            }

            if(FindListViewExtensionsItem(textBoxFileNameOrExtension.Text) != null)
            {
                MessageBox.Show("Extension name already entered.");
                return;
            }

            listViewFileNamesAndExtensions.Items.Add(new ListViewItem(textBoxFileNameOrExtension.Text));
        }

        //this.textBoxExtension.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxExtension_KeyDown);
        //private void TextBoxExtension_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        AddExtension();
        //    }
        //}

        private void ListViewExtensions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewFileNamesAndExtensions.SelectedItems.Count > 0)
                RemoveListViewExtension();
        }

        private void TextBoxExtension_KeyPress(object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AddListViewExtension();
            }
        }

        private void FormEditOption_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.Control && args.KeyCode == Keys.S)
            {
                args.Handled = true;
                SubmitChanges();

                if (DialogResult != DialogResult.None)
                    Close();
            }
        }
    }
}
