using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormEditOption : Form
    {
        private readonly FormOptionsMenu OptionsMenu;
        public Option Option;
        private readonly Option OptionClone;

        public FormEditOption(FormOptionsMenu menu, Option opt)
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEditOption_KeyDown);
            this.KeyPreview = true;
            this.OptionsMenu = menu;
            this.Option = opt;

            try
            {
                this.OptionClone = (Option)opt.Clone();

                TransferMethodAccess tma = new TransferMethodAccess();
                foreach (TransferMethod tm in tma.ListMethods())
                    comboBoxMethod.Items.Insert(tm.Id - 1, tm.MethodName);

                textBoxSourcePath.Text = opt.SourcePath;
                textBoxDestinyPath.Text = opt.DestinyPath;
                comboBoxMethod.SelectedIndex = opt.TransferMethod.Id - 1;
                checkBoxMoveSubfolders.Checked = opt.MoveSubFolders;
                checkBoxKeepOriginFiles.Checked = opt.KeepOriginFiles;
                checkBoxCleanDestinyDirectory.Checked = opt.CleanDestinyDirectory;
                checkBoxDeleteUncommonFiles.Checked = opt.DeleteUncommonFiles;
                checkBoxManageFileExtensions.Checked = opt.AllowIgnoreFileExt;

                if (opt.IgnoredFileExtensions.Count > 0)
                {
                    radioButtonIgnore.Checked = true; //-- WILL ACTIVATE THE CHECKED CHANGED METHOD
                    //foreach (FileExtension ext in opt.IgnoredFileExtensions)
                    //{
                    //    ListViewItem item = new ListViewItem(ext.ExtensionName);
                    //    item.Tag = ext.Id;
                    //    listViewExtensions.Items.Add(item);
                    //}
                }
                else
                {
                    foreach (FileExtension ext in opt.AllowOnlyFileExtensions)
                    {
                        ListViewItem item = new ListViewItem(ext.ExtensionName);
                        item.Tag = ext.Id;
                        listViewExtensions.Items.Add(item);
                    }
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
        }

        private void SubmitChanges()
        {
            try
            {
                TransferMethodAccess tma = new TransferMethodAccess();
                this.Option.SourcePath = textBoxSourcePath.Text;
                this.Option.DestinyPath = textBoxDestinyPath.Text;
                this.Option.TransferMethod = tma.GetTransferMethod(int.Parse(comboBoxMethod.SelectedIndex.ToString()) + 1);
                this.Option.MoveSubFolders = checkBoxMoveSubfolders.Checked;
                this.Option.KeepOriginFiles = checkBoxKeepOriginFiles.Checked;
                this.Option.CleanDestinyDirectory = checkBoxCleanDestinyDirectory.Checked;
                this.Option.DeleteUncommonFiles = checkBoxDeleteUncommonFiles.Checked;
                this.Option.AllowIgnoreFileExt = checkBoxManageFileExtensions.Checked;
                if (radioButtonAllowOnly.Checked) this.Option.IgnoredFileExtensions.Clear();
                else this.Option.AllowOnlyFileExtensions.Clear();
                if (OptionsMenu.Options.Find(x => x.Id == Option.Id) != null)
                
                {
                    if (!OptionsAreEqual(this.Option, OptionClone))
                        OptionsMenu.EditOption(Option);
                }
                else
                {
                    OptionsMenu.AddOption(Option);
                }
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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


        //-- ################ EXTENSIONS METHODS ################

        private void CheckBoxManageFileExtensions_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxManageFileExtensions.Checked == true)
            {
                radioButtonAllowOnly.Enabled = true;
                radioButtonIgnore.Enabled = true;
                listViewExtensions.Enabled = true;
                listViewExtensions.ForeColor = System.Drawing.SystemColors.WindowText;
                textBoxExtension.Enabled = true;
                buttonAddExtension.Enabled = true;
                buttonRemoveExtension.Enabled = true;
            }
            else
            {
                radioButtonAllowOnly.Enabled = false;
                radioButtonIgnore.Enabled = false;
                listViewExtensions.Enabled = false;
                listViewExtensions.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                textBoxExtension.Enabled = false;
                buttonAddExtension.Enabled = false;
                buttonRemoveExtension.Enabled = false;
            }
        }

        private void RadioButtonAllowOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadListViewExtensions();
        }

        private void ButtonAddExtension_Click(object sender, EventArgs e)
        {
            AddExtension();
        }

        private bool ExtensionStringIsValid()
        {
            int length = textBoxExtension.Text.Length;
            if (textBoxExtension.Text == "" || textBoxExtension.Text.Substring(0, 1) != "."
               || textBoxExtension.Text.Substring(length - 1) == "."
               || textBoxExtension.Text.Substring(1, 1) == ".") return false;

            return true;
        }
        private void ButtonRemoveExtension_Click(object sender, EventArgs e)
        {
            RemoveListViewExtension();
        }

        private void RemoveListViewExtension()
        {
            //-- REMOVE SELECTED
            if (listViewExtensions.SelectedItems.Count > 0)
            {
                if (radioButtonAllowOnly.Checked)
                    this.Option.AllowOnlyFileExtensions.Remove(this.Option.AllowOnlyFileExtensions.Find(x => x.ExtensionName == listViewExtensions.SelectedItems[0].Text));
                else
                    this.Option.IgnoredFileExtensions.Remove(this.Option.IgnoredFileExtensions.Find(x => x.ExtensionName == listViewExtensions.SelectedItems[0].Text));
                listViewExtensions.SelectedItems[0].Remove();
                return;
            }
            //-- REMOVE TYPED
            else if (ExtensionStringIsValid())
            {
                FileExtension allowedFileExtension = this.Option.AllowOnlyFileExtensions.Find(x => x.ExtensionName == textBoxExtension.Text);
                FileExtension ignoredFileExtension = this.Option.IgnoredFileExtensions.Find(x => x.ExtensionName == textBoxExtension.Text);

                if (radioButtonAllowOnly.Checked && allowedFileExtension != null)
                {
                    this.Option.AllowOnlyFileExtensions.Remove(allowedFileExtension);
                    LoadListViewExtensions();
                    return;
                }
                else if (radioButtonIgnore.Checked && ignoredFileExtension != null)
                {
                    this.Option.IgnoredFileExtensions.Remove(ignoredFileExtension);
                    LoadListViewExtensions();
                    return;
                }
            }
            MessageBox.Show("Select or type an existing extension to be removed.");
        }

        private void LoadListViewExtensions()
        {
            foreach (ListViewItem item in listViewExtensions.Items) listViewExtensions.Items.Remove(item);

            if (radioButtonIgnore.Checked)
            {
                foreach (FileExtension ext in Option.IgnoredFileExtensions)
                {
                    ListViewItem lvi = new ListViewItem(ext.ExtensionName);
                    lvi.Tag = ext.Id;
                    listViewExtensions.Items.Add(lvi);
                }
            }
            else
            {
                foreach (FileExtension ext in Option.AllowOnlyFileExtensions)
                {
                    ListViewItem lvi = new ListViewItem(ext.ExtensionName);
                    lvi.Tag = ext.Id;
                    listViewExtensions.Items.Add(lvi);
                }
            }
        }

        private void AddExtension()
        {
            if (!ExtensionStringIsValid())
            {
                MessageBox.Show("Enter a valid extension name,e.g.,'.txt'.");
                return;
            }

            if (radioButtonAllowOnly.Checked == true)
            {
                if (this.Option.AllowOnlyFileExtensions.Find(x => x.ExtensionName == textBoxExtension.Text) != null)
                {
                    MessageBox.Show("Extension name already entered.");
                    return;
                }
                this.Option.AddAllowOnlyFileExtension(new FileExtension()
                {
                    ExtensionName = textBoxExtension.Text,
                    Option = this.Option
                });
                listViewExtensions.Items.Add(new ListViewItem(textBoxExtension.Text));
            }
            else
            {
                if (this.Option.IgnoredFileExtensions.Find(x => x.ExtensionName == textBoxExtension.Text) != null)
                {
                    MessageBox.Show("Extension name already entered.");
                    return;
                }
                this.Option.AddIgnoredFileExtensions(new FileExtension()
                {
                    ExtensionName = textBoxExtension.Text,
                    Option = this.Option
                });
                listViewExtensions.Items.Add(new ListViewItem(textBoxExtension.Text));
            }
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
            if (e.KeyCode == Keys.Delete && listViewExtensions.SelectedItems.Count > 0)
                RemoveListViewExtension();
        }

        private void TextBoxExtension_KeyPress(object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AddExtension();
            }
        }

        private void FormEditOption_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.Control && args.KeyCode == Keys.S)
                SubmitChanges();
        }

        private bool OptionsAreEqual(Option previousOption,Option currentOption)
        {
            return
                previousOption.Id == currentOption.Id &&
                previousOption.ListViewIndex == currentOption.ListViewIndex &&
                previousOption.SourcePath == currentOption.SourcePath &&
                previousOption.DestinyPath == currentOption.DestinyPath &&
                previousOption.MoveSubFolders == currentOption.MoveSubFolders &&
                previousOption.KeepOriginFiles == currentOption.KeepOriginFiles &&
                previousOption.CleanDestinyDirectory == currentOption.CleanDestinyDirectory &&
                previousOption.DeleteUncommonFiles == currentOption.DeleteUncommonFiles &&
                previousOption.AllowIgnoreFileExt == currentOption.AllowIgnoreFileExt &&
                previousOption.TransferMethod.Id == currentOption.TransferMethod.Id &&

                //AllowOnlyFileExtensions.All(option.AllowOnlyFileExtensions.Contains) && AllowOnlyFileExtensions.Count == option.AllowOnlyFileExtensions.Count &&
                //IgnoredFileExtensions.All(option.IgnoredFileExtensions.Contains) && IgnoredFileExtensions.Count == option.IgnoredFileExtensions.Count;

                ExtensionListsAreTheSame(previousOption.AllowOnlyFileExtensions, currentOption.AllowOnlyFileExtensions) &&
                ExtensionListsAreTheSame(previousOption.IgnoredFileExtensions, currentOption.IgnoredFileExtensions);
        }

        private bool ExtensionListsAreTheSame(List<FileExtension> list1, List<FileExtension> list2)
        {
            if (list2.Count != list1.Count) return false;
            foreach (FileExtension ext in list1)
            {
                if (list2.Find(x => x.ExtensionName == ext.ExtensionName) == null) return false;
            }
            return true;
        }
    }
}
