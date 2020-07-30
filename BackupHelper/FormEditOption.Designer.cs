namespace BackupHelper
{
    partial class FormEditOption
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
            this.checkBoxKeepOriginFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxMoveSubfolders = new System.Windows.Forms.CheckBox();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.textBoxDestinyPath = new System.Windows.Forms.TextBox();
            this.textBoxSourcePath = new System.Windows.Forms.TextBox();
            this.labelMethod = new System.Windows.Forms.Label();
            this.labelDestinyPath = new System.Windows.Forms.Label();
            this.labelSourcePath = new System.Windows.Forms.Label();
            this.buttonAddSource = new System.Windows.Forms.Button();
            this.buttonAddDestiny = new System.Windows.Forms.Button();
            this.buttonDoneEdit = new System.Windows.Forms.Button();
            this.folderBrowserDialogEditOption = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxCleanDestinyDirectory = new System.Windows.Forms.CheckBox();
            this.buttonSwitchPaths = new System.Windows.Forms.Button();
            this.checkBoxManageFileExtensions = new System.Windows.Forms.CheckBox();
            this.listViewExtensions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelManageExtensions = new System.Windows.Forms.Panel();
            this.textBoxExtension = new System.Windows.Forms.TextBox();
            this.radioButtonIgnore = new System.Windows.Forms.RadioButton();
            this.radioButtonAllowOnly = new System.Windows.Forms.RadioButton();
            this.buttonRemoveExtension = new System.Windows.Forms.Button();
            this.buttonAddExtension = new System.Windows.Forms.Button();
            this.checkBoxDeleteUncommonFiles = new System.Windows.Forms.CheckBox();
            this.labelKeepOriginFilesHelp = new System.Windows.Forms.Label();
            this.labelCleanDestinyHelp = new System.Windows.Forms.Label();
            this.labelDeleteUncommonFilesHelp = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.panelManageExtensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxKeepOriginFiles
            // 
            this.checkBoxKeepOriginFiles.AutoSize = true;
            this.checkBoxKeepOriginFiles.Checked = true;
            this.checkBoxKeepOriginFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeepOriginFiles.Location = new System.Drawing.Point(227, 137);
            this.checkBoxKeepOriginFiles.Name = "checkBoxKeepOriginFiles";
            this.checkBoxKeepOriginFiles.Size = new System.Drawing.Size(172, 17);
            this.checkBoxKeepOriginFiles.TabIndex = 6;
            this.checkBoxKeepOriginFiles.Text = "Keep origin files and directories";
            this.checkBoxKeepOriginFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoveSubfolders
            // 
            this.checkBoxMoveSubfolders.AutoSize = true;
            this.checkBoxMoveSubfolders.Checked = true;
            this.checkBoxMoveSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMoveSubfolders.Location = new System.Drawing.Point(227, 119);
            this.checkBoxMoveSubfolders.Name = "checkBoxMoveSubfolders";
            this.checkBoxMoveSubfolders.Size = new System.Drawing.Size(112, 17);
            this.checkBoxMoveSubfolders.TabIndex = 5;
            this.checkBoxMoveSubfolders.Text = "Include subfolders";
            this.checkBoxMoveSubfolders.UseVisualStyleBackColor = true;
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Location = new System.Drawing.Point(227, 222);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(309, 21);
            this.comboBoxMethod.TabIndex = 9;
            this.comboBoxMethod.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxMethod_DrawItem);
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMethod_SelectedIndexChanged);
            // 
            // textBoxDestinyPath
            // 
            this.textBoxDestinyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxDestinyPath.Location = new System.Drawing.Point(15, 76);
            this.textBoxDestinyPath.Name = "textBoxDestinyPath";
            this.textBoxDestinyPath.Size = new System.Drawing.Size(486, 20);
            this.textBoxDestinyPath.TabIndex = 3;
            // 
            // textBoxSourcePath
            // 
            this.textBoxSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSourcePath.Location = new System.Drawing.Point(15, 29);
            this.textBoxSourcePath.Name = "textBoxSourcePath";
            this.textBoxSourcePath.Size = new System.Drawing.Size(486, 20);
            this.textBoxSourcePath.TabIndex = 1;
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(224, 206);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(290, 13);
            this.labelMethod.TabIndex = 14;
            this.labelMethod.Text = "In case there are repeated filenames in the destiny directory:";
            // 
            // labelDestinyPath
            // 
            this.labelDestinyPath.AutoSize = true;
            this.labelDestinyPath.Location = new System.Drawing.Point(12, 60);
            this.labelDestinyPath.Name = "labelDestinyPath";
            this.labelDestinyPath.Size = new System.Drawing.Size(90, 13);
            this.labelDestinyPath.TabIndex = 13;
            this.labelDestinyPath.Text = "Destiny Directory:";
            // 
            // labelSourcePath
            // 
            this.labelSourcePath.AutoSize = true;
            this.labelSourcePath.Location = new System.Drawing.Point(12, 13);
            this.labelSourcePath.Name = "labelSourcePath";
            this.labelSourcePath.Size = new System.Drawing.Size(89, 13);
            this.labelSourcePath.TabIndex = 12;
            this.labelSourcePath.Text = "Source Directory:";
            // 
            // buttonAddSource
            // 
            this.buttonAddSource.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAddSource.Cursor = System.Windows.Forms.Cursors.Cross;
            this.buttonAddSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSource.Location = new System.Drawing.Point(500, 26);
            this.buttonAddSource.Name = "buttonAddSource";
            this.buttonAddSource.Size = new System.Drawing.Size(42, 25);
            this.buttonAddSource.TabIndex = 2;
            this.buttonAddSource.Text = "Add";
            this.buttonAddSource.UseVisualStyleBackColor = false;
            this.buttonAddSource.Click += new System.EventHandler(this.ButtonAddSource_Click);
            // 
            // buttonAddDestiny
            // 
            this.buttonAddDestiny.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAddDestiny.Cursor = System.Windows.Forms.Cursors.Cross;
            this.buttonAddDestiny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddDestiny.Location = new System.Drawing.Point(500, 73);
            this.buttonAddDestiny.Name = "buttonAddDestiny";
            this.buttonAddDestiny.Size = new System.Drawing.Size(42, 25);
            this.buttonAddDestiny.TabIndex = 4;
            this.buttonAddDestiny.Text = "Add";
            this.buttonAddDestiny.UseVisualStyleBackColor = false;
            this.buttonAddDestiny.Click += new System.EventHandler(this.ButtonAddDestiny_Click);
            // 
            // buttonDoneEdit
            // 
            this.buttonDoneEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDoneEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDoneEdit.Location = new System.Drawing.Point(227, 260);
            this.buttonDoneEdit.Name = "buttonDoneEdit";
            this.buttonDoneEdit.Size = new System.Drawing.Size(121, 36);
            this.buttonDoneEdit.TabIndex = 10;
            this.buttonDoneEdit.Text = "Done";
            this.buttonDoneEdit.UseVisualStyleBackColor = true;
            this.buttonDoneEdit.Click += new System.EventHandler(this.ButtonDoneEdit_Click);
            // 
            // checkBoxCleanDestinyDirectory
            // 
            this.checkBoxCleanDestinyDirectory.AutoSize = true;
            this.checkBoxCleanDestinyDirectory.Location = new System.Drawing.Point(227, 155);
            this.checkBoxCleanDestinyDirectory.Name = "checkBoxCleanDestinyDirectory";
            this.checkBoxCleanDestinyDirectory.Size = new System.Drawing.Size(151, 17);
            this.checkBoxCleanDestinyDirectory.TabIndex = 7;
            this.checkBoxCleanDestinyDirectory.Text = "Clean destiny directory first";
            this.checkBoxCleanDestinyDirectory.UseVisualStyleBackColor = true;
            this.checkBoxCleanDestinyDirectory.CheckedChanged += new System.EventHandler(this.CheckBoxCleanDestinyDirectory_CheckedChanged);
            // 
            // buttonSwitchPaths
            // 
            this.buttonSwitchPaths.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSwitchPaths.Location = new System.Drawing.Point(367, 52);
            this.buttonSwitchPaths.Name = "buttonSwitchPaths";
            this.buttonSwitchPaths.Size = new System.Drawing.Size(101, 21);
            this.buttonSwitchPaths.TabIndex = 3;
            this.buttonSwitchPaths.Text = "Switch Paths";
            this.buttonSwitchPaths.UseVisualStyleBackColor = true;
            this.buttonSwitchPaths.Click += new System.EventHandler(this.ButtonSwitchPaths_Click);
            // 
            // checkBoxManageFileExtensions
            // 
            this.checkBoxManageFileExtensions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxManageFileExtensions.AutoSize = true;
            this.checkBoxManageFileExtensions.Location = new System.Drawing.Point(12, 10);
            this.checkBoxManageFileExtensions.Name = "checkBoxManageFileExtensions";
            this.checkBoxManageFileExtensions.Size = new System.Drawing.Size(138, 17);
            this.checkBoxManageFileExtensions.TabIndex = 11;
            this.checkBoxManageFileExtensions.Text = "Manage File Extensions";
            this.checkBoxManageFileExtensions.UseVisualStyleBackColor = true;
            this.checkBoxManageFileExtensions.CheckedChanged += new System.EventHandler(this.CheckBoxManageFileExtensions_CheckedChanged);
            // 
            // listViewExtensions
            // 
            this.listViewExtensions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listViewExtensions.BackColor = System.Drawing.SystemColors.Window;
            this.listViewExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewExtensions.Enabled = false;
            this.listViewExtensions.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.listViewExtensions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewExtensions.HideSelection = false;
            this.listViewExtensions.Location = new System.Drawing.Point(18, 58);
            this.listViewExtensions.MultiSelect = false;
            this.listViewExtensions.Name = "listViewExtensions";
            this.listViewExtensions.ShowItemToolTips = true;
            this.listViewExtensions.Size = new System.Drawing.Size(142, 84);
            this.listViewExtensions.TabIndex = 9;
            this.listViewExtensions.UseCompatibleStateImageBehavior = false;
            this.listViewExtensions.View = System.Windows.Forms.View.Details;
            this.listViewExtensions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewExtensions_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Extension Name";
            this.columnHeader1.Width = 137;
            // 
            // panelManageExtensions
            // 
            this.panelManageExtensions.Controls.Add(this.textBoxExtension);
            this.panelManageExtensions.Controls.Add(this.radioButtonIgnore);
            this.panelManageExtensions.Controls.Add(this.checkBoxManageFileExtensions);
            this.panelManageExtensions.Controls.Add(this.radioButtonAllowOnly);
            this.panelManageExtensions.Controls.Add(this.buttonRemoveExtension);
            this.panelManageExtensions.Controls.Add(this.buttonAddExtension);
            this.panelManageExtensions.Controls.Add(this.listViewExtensions);
            this.panelManageExtensions.Location = new System.Drawing.Point(16, 116);
            this.panelManageExtensions.Name = "panelManageExtensions";
            this.panelManageExtensions.Size = new System.Drawing.Size(181, 183);
            this.panelManageExtensions.TabIndex = 28;
            // 
            // textBoxExtension
            // 
            this.textBoxExtension.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxExtension.Enabled = false;
            this.textBoxExtension.Location = new System.Drawing.Point(18, 148);
            this.textBoxExtension.Name = "textBoxExtension";
            this.textBoxExtension.Size = new System.Drawing.Size(73, 20);
            this.textBoxExtension.TabIndex = 14;
            this.textBoxExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxExtension_KeyPress);
            // 
            // radioButtonIgnore
            // 
            this.radioButtonIgnore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonIgnore.AutoSize = true;
            this.radioButtonIgnore.Enabled = false;
            this.radioButtonIgnore.Location = new System.Drawing.Point(95, 33);
            this.radioButtonIgnore.Name = "radioButtonIgnore";
            this.radioButtonIgnore.Size = new System.Drawing.Size(55, 17);
            this.radioButtonIgnore.TabIndex = 13;
            this.radioButtonIgnore.Text = "Ignore";
            this.radioButtonIgnore.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllowOnly
            // 
            this.radioButtonAllowOnly.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.radioButtonAllowOnly.AutoSize = true;
            this.radioButtonAllowOnly.Checked = true;
            this.radioButtonAllowOnly.Enabled = false;
            this.radioButtonAllowOnly.Location = new System.Drawing.Point(17, 33);
            this.radioButtonAllowOnly.Name = "radioButtonAllowOnly";
            this.radioButtonAllowOnly.Size = new System.Drawing.Size(74, 17);
            this.radioButtonAllowOnly.TabIndex = 12;
            this.radioButtonAllowOnly.TabStop = true;
            this.radioButtonAllowOnly.Text = "Allow Only";
            this.radioButtonAllowOnly.UseVisualStyleBackColor = true;
            this.radioButtonAllowOnly.CheckedChanged += new System.EventHandler(this.RadioButtonAllowOnly_CheckedChanged);
            // 
            // buttonRemoveExtension
            // 
            this.buttonRemoveExtension.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRemoveExtension.Enabled = false;
            this.buttonRemoveExtension.Location = new System.Drawing.Point(130, 147);
            this.buttonRemoveExtension.Name = "buttonRemoveExtension";
            this.buttonRemoveExtension.Size = new System.Drawing.Size(38, 22);
            this.buttonRemoveExtension.TabIndex = 16;
            this.buttonRemoveExtension.Text = "Remove";
            this.buttonRemoveExtension.UseVisualStyleBackColor = true;
            this.buttonRemoveExtension.Click += new System.EventHandler(this.ButtonRemoveExtension_Click);
            // 
            // buttonAddExtension
            // 
            this.buttonAddExtension.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonAddExtension.Enabled = false;
            this.buttonAddExtension.Location = new System.Drawing.Point(92, 147);
            this.buttonAddExtension.Name = "buttonAddExtension";
            this.buttonAddExtension.Size = new System.Drawing.Size(38, 22);
            this.buttonAddExtension.TabIndex = 15;
            this.buttonAddExtension.Text = "Add";
            this.buttonAddExtension.UseVisualStyleBackColor = true;
            this.buttonAddExtension.Click += new System.EventHandler(this.ButtonAddExtension_Click);
            // 
            // checkBoxDeleteUncommonFiles
            // 
            this.checkBoxDeleteUncommonFiles.AutoSize = true;
            this.checkBoxDeleteUncommonFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxDeleteUncommonFiles.Location = new System.Drawing.Point(227, 173);
            this.checkBoxDeleteUncommonFiles.Name = "checkBoxDeleteUncommonFiles";
            this.checkBoxDeleteUncommonFiles.Size = new System.Drawing.Size(205, 17);
            this.checkBoxDeleteUncommonFiles.TabIndex = 8;
            this.checkBoxDeleteUncommonFiles.Text = "Delete uncommon files and directories";
            this.checkBoxDeleteUncommonFiles.UseVisualStyleBackColor = true;
            this.checkBoxDeleteUncommonFiles.CheckedChanged += new System.EventHandler(this.CheckBoxDeleteUncommonFiles_CheckedChanged);
            // 
            // labelKeepOriginFilesHelp
            // 
            this.labelKeepOriginFilesHelp.AutoSize = true;
            this.labelKeepOriginFilesHelp.BackColor = System.Drawing.Color.Green;
            this.labelKeepOriginFilesHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeepOriginFilesHelp.ForeColor = System.Drawing.Color.White;
            this.labelKeepOriginFilesHelp.Location = new System.Drawing.Point(398, 139);
            this.labelKeepOriginFilesHelp.Name = "labelKeepOriginFilesHelp";
            this.labelKeepOriginFilesHelp.Size = new System.Drawing.Size(11, 12);
            this.labelKeepOriginFilesHelp.TabIndex = 31;
            this.labelKeepOriginFilesHelp.Text = "?";
            this.toolTipHelp.SetToolTip(this.labelKeepOriginFilesHelp, "Origin files and directories will be copied instead of moved");
            // 
            // labelCleanDestinyHelp
            // 
            this.labelCleanDestinyHelp.AutoSize = true;
            this.labelCleanDestinyHelp.BackColor = System.Drawing.Color.Green;
            this.labelCleanDestinyHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCleanDestinyHelp.ForeColor = System.Drawing.Color.White;
            this.labelCleanDestinyHelp.Location = new System.Drawing.Point(377, 157);
            this.labelCleanDestinyHelp.Name = "labelCleanDestinyHelp";
            this.labelCleanDestinyHelp.Size = new System.Drawing.Size(11, 12);
            this.labelCleanDestinyHelp.TabIndex = 32;
            this.labelCleanDestinyHelp.Text = "?";
            this.toolTipHelp.SetToolTip(this.labelCleanDestinyHelp, "All destiny files and directories will be deleted before transfering");
            // 
            // labelDeleteUncommonFilesHelp
            // 
            this.labelDeleteUncommonFilesHelp.AutoSize = true;
            this.labelDeleteUncommonFilesHelp.BackColor = System.Drawing.Color.Green;
            this.labelDeleteUncommonFilesHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeleteUncommonFilesHelp.ForeColor = System.Drawing.Color.White;
            this.labelDeleteUncommonFilesHelp.Location = new System.Drawing.Point(431, 175);
            this.labelDeleteUncommonFilesHelp.Name = "labelDeleteUncommonFilesHelp";
            this.labelDeleteUncommonFilesHelp.Size = new System.Drawing.Size(11, 12);
            this.labelDeleteUncommonFilesHelp.TabIndex = 33;
            this.labelDeleteUncommonFilesHelp.Text = "?";
            this.toolTipHelp.SetToolTip(this.labelDeleteUncommonFilesHelp, "Delete files and directories present in the destiny directory that aren\'t present" +
        " in the origin directory");
            // 
            // toolTipHelp
            // 
            this.toolTipHelp.AutoPopDelay = 10000;
            this.toolTipHelp.InitialDelay = 500;
            this.toolTipHelp.ReshowDelay = 100;
            // 
            // FormEditOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 311);
            this.Controls.Add(this.labelDeleteUncommonFilesHelp);
            this.Controls.Add(this.labelCleanDestinyHelp);
            this.Controls.Add(this.labelKeepOriginFilesHelp);
            this.Controls.Add(this.checkBoxDeleteUncommonFiles);
            this.Controls.Add(this.panelManageExtensions);
            this.Controls.Add(this.buttonSwitchPaths);
            this.Controls.Add(this.checkBoxCleanDestinyDirectory);
            this.Controls.Add(this.buttonDoneEdit);
            this.Controls.Add(this.buttonAddDestiny);
            this.Controls.Add(this.buttonAddSource);
            this.Controls.Add(this.checkBoxKeepOriginFiles);
            this.Controls.Add(this.checkBoxMoveSubfolders);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.textBoxDestinyPath);
            this.Controls.Add(this.textBoxSourcePath);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.labelDestinyPath);
            this.Controls.Add(this.labelSourcePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormEditOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Option";
            this.panelManageExtensions.ResumeLayout(false);
            this.panelManageExtensions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxKeepOriginFiles;
        private System.Windows.Forms.CheckBox checkBoxMoveSubfolders;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.TextBox textBoxDestinyPath;
        private System.Windows.Forms.TextBox textBoxSourcePath;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Label labelDestinyPath;
        private System.Windows.Forms.Label labelSourcePath;
        private System.Windows.Forms.Button buttonAddSource;
        private System.Windows.Forms.Button buttonAddDestiny;
        private System.Windows.Forms.Button buttonDoneEdit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogEditOption;
        private System.Windows.Forms.CheckBox checkBoxCleanDestinyDirectory;
        private System.Windows.Forms.Button buttonSwitchPaths;
        private System.Windows.Forms.CheckBox checkBoxManageFileExtensions;
        private System.Windows.Forms.ListView listViewExtensions;
        private System.Windows.Forms.Panel panelManageExtensions;
        private System.Windows.Forms.RadioButton radioButtonIgnore;
        private System.Windows.Forms.RadioButton radioButtonAllowOnly;
        private System.Windows.Forms.Button buttonRemoveExtension;
        private System.Windows.Forms.Button buttonAddExtension;
        private System.Windows.Forms.TextBox textBoxExtension;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox checkBoxDeleteUncommonFiles;
        private System.Windows.Forms.Label labelKeepOriginFilesHelp;
        private System.Windows.Forms.Label labelCleanDestinyHelp;
        private System.Windows.Forms.Label labelDeleteUncommonFilesHelp;
        private System.Windows.Forms.ToolTip toolTipHelp;
    }
}