using BackupHelper.model;
using FileControlUtility;
using Nain;

namespace BackupHelper
{
    public enum FormAction { EDIT, CREATE }

    public partial class FormEditOptions : Form
    {
        private readonly FormOptionsMenu OptionsMenu;
        public Options Option;
        private readonly FormAction FormAction = FormAction.CREATE;
        private static FormEditOptions Instance = null;

        public static FormEditOptions GetInstance(FormOptionsMenu optionsMenu, Options option = null)
        {
            if (Instance != null && Instance.IsHandleCreated && option != Instance.Option) Instance.Close();

            if (Instance == null || !Instance.IsHandleCreated)
                Instance = new FormEditOptions(optionsMenu, option);

            return Instance;
        }

        private FormEditOptions(FormOptionsMenu optionsMenu, Options option = null)
        {
            InitializeComponent();

            OptionsMenu = optionsMenu;

            if (option != null)
            {
                FormAction = FormAction.EDIT;
                Option = option;
                FillFields(option);
            }
            else
            {
                Text = "New Options";

                FillFields(new Options
                {
                    SourcePath = "C:\\origin...",
                    DestinyPath = "C:\\destiny...",
                    IncludeSubFolders = true
                });
            }

            KeyDown += new KeyEventHandler(FormEditOption_KeyDown);
            KeyPreview = true;
        }

        private void FillFields(Options option)
        {
            try
            {
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.SKIP, option.GetTransferMethodDescription(FileNameConflictMethod.SKIP));
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.REPLACE_ALL, option.GetTransferMethodDescription(FileNameConflictMethod.REPLACE_ALL));
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.REPLACE_DIFFERENT, option.GetTransferMethodDescription(FileNameConflictMethod.REPLACE_DIFFERENT));
                comboBoxMethod.Items.Insert((int)FileNameConflictMethod.RENAME_DIFFERENT, option.GetTransferMethodDescription(FileNameConflictMethod.RENAME_DIFFERENT));

                comboBoxMethod.SelectedIndex = (int)option.FileNameConflictMethod;

                textBoxSourcePath.Text = option.SourcePath;
                textBoxDestinyPath.Text = option.DestinyPath;
                checkBoxMoveSubfolders.Checked = option.IncludeSubFolders;
                checkBoxKeepOriginFiles.Checked = option.KeepOriginFiles;
                checkBoxCleanDestinyDirectory.Checked = option.CleanDestinyDirectory;
                checkBoxDeleteUncommonFiles.Checked = option.DeleteUncommonFiles;
                checkBoxActive1.Checked = option.FilterFilesAndExts;
                checkBoxActive2.Checked = option.FilterDirectories;
                radioButtonIgnore1.Checked = option.FilteredFileNamesOrExtensionsMode == FilterMode.IGNORE;
                radioButtonIgnore2.Checked = option.FilteredDirectoriesMode == FilterMode.IGNORE;
                checkBoxReenumerate.Checked = option.ReenumerateRenamedFiles;
                numericUpDownMaxKeptRenamedFileCount.Value = option.MaxKeptRenamedFileCount;

                foreach (string txt in option.FilteredFileNamesAndExtensions)
                    listViewFilesAndExts.Items.Add(new ListViewItem(txt));

                FormsUtility.ResizeListViewColumns(listViewFilesAndExts);

                foreach (string txt in option.FilteredDirectories)
                    listViewDirs.Items.Add(new ListViewItem(txt));

                FormsUtility.ResizeListViewColumns(listViewDirs);

                if (option.FilteredFileNamesAndExtensions.Count > 0 && option.FilterFilesAndExts)
                    tabControlFilter.SelectedTab = tabPageFilterFilesAndExts;
                else if (option.FilteredDirectories.Count > 0 && option.FilterDirectories)
                    tabControlFilter.SelectedTab = tabPageFilterDirs;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Close();
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
                Options editedOption = new Options();
                SaveFieldsToObject(editedOption);
                if (!InputsAreValid(editedOption)) return;

                if (FormAction == FormAction.CREATE)
                {
                    editedOption.Profile = OptionsMenu.Profile;
                    editedOption.ListViewIndex = OptionsMenu.listViewOptions.Items.Count;
                    DBAccess.CreateOption(editedOption);
                    OptionsMenu.Options.Add(editedOption);
                    Program.UpdateLastTimeModified(editedOption.Profile);
                    ListViewItem item = new ListViewItem();
                    OptionsMenu.EditListViewItem(editedOption, item);
                    OptionsMenu.listViewOptions.Items.Add(item);
                    //OptionsMenu.ResizeForm();
                }
                else
                {
                    if (
                        !(
                            Option.SourcePath == editedOption.SourcePath &&
                            Option.DestinyPath == editedOption.DestinyPath &&
                            Option.FileNameConflictMethod == editedOption.FileNameConflictMethod &&
                            Option.IncludeSubFolders == editedOption.IncludeSubFolders &&
                            Option.KeepOriginFiles == editedOption.KeepOriginFiles &&
                            Option.CleanDestinyDirectory == editedOption.CleanDestinyDirectory &&
                            Option.DeleteUncommonFiles == editedOption.DeleteUncommonFiles &&
                            Option.FilteredFileNamesOrExtensionsMode == editedOption.FilteredFileNamesOrExtensionsMode &&
                            Option.FilteredDirectoriesMode == editedOption.FilteredDirectoriesMode &&
                            Option.FilterFilesAndExts == editedOption.FilterFilesAndExts &&
                            Option.FilterDirectories == editedOption.FilterDirectories &&
                            ExtensionsAreTheSame(Option.FilteredFileNamesAndExtensions, editedOption.FilteredFileNamesAndExtensions) &&
                            ExtensionsAreTheSame(Option.FilteredDirectories, editedOption.FilteredDirectories) &&
                            Option.ReenumerateRenamedFiles == editedOption.ReenumerateRenamedFiles &&
                            Option.MaxKeptRenamedFileCount == editedOption.MaxKeptRenamedFileCount
                        )
                    )
                    {
                        Option.SourcePath = editedOption.SourcePath;
                        Option.DestinyPath = editedOption.DestinyPath;
                        Option.FileNameConflictMethod = editedOption.FileNameConflictMethod;
                        Option.IncludeSubFolders = editedOption.IncludeSubFolders;
                        Option.KeepOriginFiles = editedOption.KeepOriginFiles;
                        Option.CleanDestinyDirectory = editedOption.CleanDestinyDirectory;
                        Option.DeleteUncommonFiles = editedOption.DeleteUncommonFiles;
                        Option.FilteredFileNamesOrExtensionsMode = editedOption.FilteredFileNamesOrExtensionsMode;
                        Option.FilteredDirectoriesMode = editedOption.FilteredDirectoriesMode;
                        Option.FilterFilesAndExts = editedOption.FilterFilesAndExts;
                        Option.FilterDirectories = editedOption.FilterDirectories;
                        Option.FilteredFileNamesAndExtensions = editedOption.FilteredFileNamesAndExtensions;
                        Option.FilteredDirectories = editedOption.FilteredDirectories;
                        Option.ReenumerateRenamedFiles = editedOption.ReenumerateRenamedFiles;
                        Option.MaxKeptRenamedFileCount = editedOption.MaxKeptRenamedFileCount;

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

        private bool InputsAreValid(Options editedOption)
        {
            if (editedOption.SourcePath == "")
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

            foreach (string extension in fileExtensions1)
                if (!fileExtensions2.Contains(extension)) return false;

            return true;
        }

        private void SaveFieldsToObject(Options editedOption)
        {
            editedOption.SourcePath = textBoxSourcePath.Text;
            editedOption.DestinyPath = textBoxDestinyPath.Text;
            editedOption.FileNameConflictMethod = (FileNameConflictMethod)comboBoxMethod.SelectedIndex;
            editedOption.IncludeSubFolders = checkBoxMoveSubfolders.Checked;
            editedOption.KeepOriginFiles = checkBoxKeepOriginFiles.Checked;
            editedOption.CleanDestinyDirectory = checkBoxCleanDestinyDirectory.Checked;
            editedOption.DeleteUncommonFiles = checkBoxDeleteUncommonFiles.Checked;
            editedOption.FilteredFileNamesOrExtensionsMode = radioButtonIgnore1.Checked ? FilterMode.IGNORE : FilterMode.TRANSFER_ONLY;
            editedOption.FilteredDirectoriesMode = radioButtonIgnore2.Checked ? FilterMode.IGNORE : FilterMode.TRANSFER_ONLY;
            editedOption.FilterFilesAndExts = checkBoxActive1.Checked;
            editedOption.FilterDirectories = checkBoxActive2.Checked;
            editedOption.FilteredFileNamesAndExtensions = listViewFilesAndExts.Items.Cast<ListViewItem>().Select(i => i.Text).ToList();
            editedOption.FilteredDirectories = listViewDirs.Items.Cast<ListViewItem>().Select(i => i.Text).ToList();
            editedOption.ReenumerateRenamedFiles = checkBoxReenumerate.Checked;
            editedOption.MaxKeptRenamedFileCount = (int)numericUpDownMaxKeptRenamedFileCount.Value;
        }

        //private List<string> ListViewFileExtensionsToList()
        //{
        //    List<string> extensions = new List<string>();

        //    foreach(ListViewItem item in listViewFileNamesAndExtensions.Items)
        //        extensions.Add(item.Text);

        //    return extensions;
        //}

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
                checkBoxReenumerate.Enabled = false;
                checkBoxReenumerate.Checked = false;
            }
            else
            {
                comboBoxMethod.Enabled = true;
                labelMethod.Enabled = true;
                checkBoxDeleteUncommonFiles.Enabled = true;
                checkBoxReenumerate.Enabled = true;
            }
        }

        private void CheckBoxDeleteUncommonFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDeleteUncommonFiles.Checked && comboBoxMethod.SelectedIndex == 3)
                comboBoxMethod.SelectedIndex = 0;
        }

        private void ComboBoxMethod_DrawItem(object sender, DrawItemEventArgs args)
        {
            //if (checkBoxDeleteUncommonFiles.Checked && args.Index == 3)
            //    args.Graphics.DrawString(comboBoxMethod.Items[args.Index].ToString(), args.Font, Brushes.LightGray, args.Bounds);
            //else
            //{
            //    args.DrawBackground();
            //    args.Graphics.DrawString(comboBoxMethod.Items[args.Index].ToString(), args.Font, Brushes.Black, args.Bounds);
            //    args.DrawFocusRectangle();
            //}

            FormsUtility.DrawItem(comboBoxMethod, args, checkBoxDeleteUncommonFiles.Checked && args.Index == 3);
        }

        private void ComboBoxMethod_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (comboBoxMethod.SelectedIndex == 3)
            {
                if (checkBoxDeleteUncommonFiles.Checked)
                    comboBoxMethod.SelectedIndex = 0;
                else
                    checkBoxReenumerate.Enabled = true;
            }
            else
            {
                checkBoxReenumerate.Checked = false;
                checkBoxReenumerate.Enabled = false;
            }
        }

        private void ButtonSwitchPaths_Click(object sender, EventArgs e)
        {
            string sourcePath = textBoxSourcePath.Text;
            string destinyPath = textBoxDestinyPath.Text;
            textBoxSourcePath.Text = destinyPath;
            textBoxDestinyPath.Text = sourcePath;
        }

        private void FormEditOption_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.Control && args.KeyCode == Keys.S)
            {
                args.Handled = true;
                SubmitChanges();

                if (DialogResult != DialogResult.None) Close();
            }
        }

        //-- ################ FILENAMES AND EXTENSIONS METHODS ################

        private bool FilenameIsValid(string text)
        {
            int length = text.Length;

            if (text == "" || text.Substring(length - 1) == ".") return false;
            if (text[0] == Path.DirectorySeparatorChar && text[1] != Path.DirectorySeparatorChar) return false;

            bool filenameHasDir = text.Contains(Path.DirectorySeparatorChar); // || text.Contains(Path.AltDirectorySeparatorChar);

            string name;

            if (filenameHasDir)
            {
                //string dir = Path.GetDirectoryName(text);
                //name = Path.GetFileName(text);
                string dir = text[..text.LastIndexOf(Path.DirectorySeparatorChar)];
                name = text[(text.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];

                foreach (char s in Path.GetInvalidPathChars())
                    if (dir.Contains(s.ToString())) return false;
            }
            else
                name = text;

            foreach (char s in Path.GetInvalidFileNameChars())
                if (name.Contains(s.ToString())) return false;

            return true;
        }

        private bool PathIsValid(string text)
        {
            int length = text.Length;

            if (text == "" || text.Substring(length - 1) == ".") return false;

            foreach (char s in Path.GetInvalidPathChars())
                if (text.Contains(s.ToString())) return false;

            return true;
        }

        private void AddFilterFilesListViewItem()
        {
            try
            {
                string fileOrExt = FileControl.AdjustPath(textBoxFilesAndExts.Text);

                if (!FilenameIsValid(fileOrExt))
                {
                    MessageBox.Show("Enter a valid filename or extension name,e.g.,\".txt\",\"myfile.exe\",\"C:\\pathto\\myfile.exe\".");
                    return;
                }

                if (FindListViewItem(listViewFilesAndExts, fileOrExt) != null)
                {
                    MessageBox.Show("Entry is already in the list.");
                    return;
                }

                listViewFilesAndExts.Items.Add(new ListViewItem(fileOrExt));
                FormsUtility.ResizeListViewColumns(listViewFilesAndExts);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddFilterDirsListViewItem()
        {
            try
            {
                string dir = FileControl.AdjustPath(textBoxDirs.Text);

                if (!PathIsValid(dir))
                {
                    MessageBox.Show("Enter a valid directory,e.g.,\"\\relative\\path\",\"C:\\full\\path\",\"\\\\server\\path\"");
                    return;
                }

                if (FindListViewItem(listViewDirs, dir) != null)
                {
                    MessageBox.Show("Entry is already in the list.");
                    return;
                }

                listViewDirs.Items.Add(new ListViewItem(dir));
                FormsUtility.ResizeListViewColumns(listViewDirs);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void RemoveFilterListViewItem(ListView listView, string text)
        {
            //-- REMOVE SELECTED
            if (listView.SelectedItems.Count > 0)
                listView.SelectedItems[0].Remove();

            //-- REMOVE TYPED
            else if (text != "") //ExtensionStringIsValid()
            {
                if (listView.Items.Count == 0) return;

                ListViewItem listViewItem = FindListViewItem(listView, text);

                if (listViewItem != null)
                    listView.Items.Remove(listViewItem);
                //else
                //    MessageBox.Show($"No extension named \"{textBoxExtension.Text}\".");
            }
            else
            {
                MessageBox.Show("Select or type an existing entry to be removed.");
                return;
            }

            FormsUtility.ResizeListViewColumns(listView);
        }

        private ListViewItem FindListViewItem(ListView listView, string text)
        {
            foreach (ListViewItem item in listView.Items)
                if (item.Text == text) return item;

            return null;
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

        private void ButtonAddFileOrExt_Click(object sender, EventArgs e)
        {
            AddFilterFilesListViewItem();
        }

        private void ButtonRemoveFileOrExt_Click(object sender, EventArgs e)
        {
            RemoveFilterListViewItem(listViewFilesAndExts, textBoxFilesAndExts.Text);
        }

        private void ListViewFilesAndExts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewFilesAndExts.SelectedItems.Count > 0)
                RemoveFilterListViewItem(listViewFilesAndExts, textBoxFilesAndExts.Text);
        }

        private void TextBoxFilesAndExts_KeyPress(object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AddFilterFilesListViewItem();
            }
        }

        private void CheckBoxReenumerate_CheckedChanged(object sender, EventArgs e)
        {
            labelMaxKeptRenamedFileCount.Enabled = checkBoxReenumerate.Checked;
            numericUpDownMaxKeptRenamedFileCount.Enabled = checkBoxReenumerate.Checked;
        }

        private void ButtonAddDir_Click(object sender, EventArgs e)
        {
            AddFilterDirsListViewItem();
        }

        private void ButtonRemDir_Click(object sender, EventArgs e)
        {
            RemoveFilterListViewItem(listViewDirs, textBoxDirs.Text);
        }

        private void ListViewDirs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewDirs.SelectedItems.Count > 0)
                RemoveFilterListViewItem(listViewDirs, textBoxDirs.Text);
        }

        private void TextBoxDirs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AddFilterDirsListViewItem();
            }
        }

        private void CheckBoxActive1_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonTransferOnly1.Enabled = checkBoxActive1.Checked;
            radioButtonIgnore1.Enabled = checkBoxActive1.Checked;
            listViewFilesAndExts.Enabled = checkBoxActive1.Checked;
            listViewFilesAndExts.ForeColor = checkBoxActive1.Checked ? SystemColors.WindowText : SystemColors.InactiveCaption;
            textBoxFilesAndExts.Enabled = checkBoxActive1.Checked;
            buttonAddFileOrExt.Enabled = checkBoxActive1.Checked;
            buttonRemFileOrExt.Enabled = checkBoxActive1.Checked;
        }

        private void CheckBoxActive2_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonTransferOnly2.Enabled = checkBoxActive2.Checked;
            radioButtonIgnore2.Enabled = checkBoxActive2.Checked;
            listViewDirs.Enabled = checkBoxActive2.Checked;
            listViewDirs.ForeColor = checkBoxActive2.Checked ? SystemColors.WindowText : SystemColors.InactiveCaption;
            textBoxDirs.Enabled = checkBoxActive2.Checked;
            buttonAddDir.Enabled = checkBoxActive2.Checked;
            buttonRemDir.Enabled = checkBoxActive2.Checked;
        }
    }
}
