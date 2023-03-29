namespace BackupHelper
{
    partial class FormEditOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditOptions));
            checkBoxKeepOriginFiles = new CheckBox();
            checkBoxMoveSubfolders = new CheckBox();
            comboBoxMethod = new ComboBox();
            textBoxDestinyPath = new TextBox();
            textBoxSourcePath = new TextBox();
            labelMethod = new Label();
            labelDestinyPath = new Label();
            labelSourcePath = new Label();
            buttonAddSource = new Button();
            buttonAddDestiny = new Button();
            buttonDoneEdit = new Button();
            folderBrowserDialogEditOption = new FolderBrowserDialog();
            checkBoxCleanDestinyDirectory = new CheckBox();
            buttonSwitchPaths = new Button();
            listViewFilesAndExts = new ListView();
            columnHeaderFileOrExt = new ColumnHeader();
            textBoxFilesAndExts = new TextBox();
            radioButtonIgnore1 = new RadioButton();
            radioButtonTransferOnly1 = new RadioButton();
            buttonRemFileOrExt = new Button();
            buttonAddFileOrExt = new Button();
            checkBoxDeleteUncommonFiles = new CheckBox();
            labelKeepOriginFilesHelp = new Label();
            labelCleanDestinyHelp = new Label();
            labelDeleteUncommonFilesHelp = new Label();
            toolTipHelp = new ToolTip(components);
            labelReenumerateHelp = new Label();
            labelFilterDirsHelp = new Label();
            labelFilterFilesHelp = new Label();
            checkBoxReenumerate = new CheckBox();
            numericUpDownMaxKeptRenamedFileCount = new NumericUpDown();
            labelMaxKeptRenamedFileCount = new Label();
            tabControlFilter = new TabControl();
            tabPageFilterFilesAndExts = new TabPage();
            panel2 = new Panel();
            checkBoxActive1 = new CheckBox();
            tabPageFilterDirs = new TabPage();
            panel1 = new Panel();
            listViewDirs = new ListView();
            columnHeaderDir = new ColumnHeader();
            checkBoxActive2 = new CheckBox();
            buttonRemDir = new Button();
            textBoxDirs = new TextBox();
            radioButtonTransferOnly2 = new RadioButton();
            radioButtonIgnore2 = new RadioButton();
            buttonAddDir = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxKeptRenamedFileCount).BeginInit();
            tabControlFilter.SuspendLayout();
            tabPageFilterFilesAndExts.SuspendLayout();
            panel2.SuspendLayout();
            tabPageFilterDirs.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxKeepOriginFiles
            // 
            checkBoxKeepOriginFiles.Anchor = AnchorStyles.Right;
            checkBoxKeepOriginFiles.AutoSize = true;
            checkBoxKeepOriginFiles.Checked = true;
            checkBoxKeepOriginFiles.CheckState = CheckState.Checked;
            checkBoxKeepOriginFiles.Location = new Point(260, 137);
            checkBoxKeepOriginFiles.Name = "checkBoxKeepOriginFiles";
            checkBoxKeepOriginFiles.Size = new Size(172, 17);
            checkBoxKeepOriginFiles.TabIndex = 6;
            checkBoxKeepOriginFiles.Text = "Keep origin files and directories";
            checkBoxKeepOriginFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoveSubfolders
            // 
            checkBoxMoveSubfolders.Anchor = AnchorStyles.Right;
            checkBoxMoveSubfolders.AutoSize = true;
            checkBoxMoveSubfolders.Checked = true;
            checkBoxMoveSubfolders.CheckState = CheckState.Checked;
            checkBoxMoveSubfolders.Location = new Point(260, 119);
            checkBoxMoveSubfolders.Name = "checkBoxMoveSubfolders";
            checkBoxMoveSubfolders.Size = new Size(112, 17);
            checkBoxMoveSubfolders.TabIndex = 5;
            checkBoxMoveSubfolders.Text = "Include subfolders";
            checkBoxMoveSubfolders.UseVisualStyleBackColor = true;
            // 
            // comboBoxMethod
            // 
            comboBoxMethod.Anchor = AnchorStyles.Right;
            comboBoxMethod.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMethod.FormattingEnabled = true;
            comboBoxMethod.Location = new Point(260, 222);
            comboBoxMethod.Name = "comboBoxMethod";
            comboBoxMethod.Size = new Size(369, 21);
            comboBoxMethod.TabIndex = 9;
            comboBoxMethod.DrawItem += ComboBoxMethod_DrawItem;
            comboBoxMethod.SelectedIndexChanged += ComboBoxMethod_SelectedIndexChanged;
            // 
            // textBoxDestinyPath
            // 
            textBoxDestinyPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDestinyPath.Location = new Point(15, 76);
            textBoxDestinyPath.Name = "textBoxDestinyPath";
            textBoxDestinyPath.Size = new Size(577, 20);
            textBoxDestinyPath.TabIndex = 3;
            // 
            // textBoxSourcePath
            // 
            textBoxSourcePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSourcePath.Location = new Point(15, 29);
            textBoxSourcePath.Name = "textBoxSourcePath";
            textBoxSourcePath.Size = new Size(577, 20);
            textBoxSourcePath.TabIndex = 1;
            // 
            // labelMethod
            // 
            labelMethod.Anchor = AnchorStyles.Right;
            labelMethod.AutoSize = true;
            labelMethod.Location = new Point(257, 206);
            labelMethod.Name = "labelMethod";
            labelMethod.Size = new Size(225, 13);
            labelMethod.TabIndex = 14;
            labelMethod.Text = "For repeated filenames in the destiny directory:";
            // 
            // labelDestinyPath
            // 
            labelDestinyPath.AutoSize = true;
            labelDestinyPath.Location = new Point(12, 60);
            labelDestinyPath.Name = "labelDestinyPath";
            labelDestinyPath.Size = new Size(90, 13);
            labelDestinyPath.TabIndex = 13;
            labelDestinyPath.Text = "Destiny Directory:";
            // 
            // labelSourcePath
            // 
            labelSourcePath.AutoSize = true;
            labelSourcePath.Location = new Point(12, 13);
            labelSourcePath.Name = "labelSourcePath";
            labelSourcePath.Size = new Size(89, 13);
            labelSourcePath.TabIndex = 12;
            labelSourcePath.Text = "Source Directory:";
            // 
            // buttonAddSource
            // 
            buttonAddSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddSource.BackColor = SystemColors.ControlLight;
            buttonAddSource.Cursor = Cursors.Cross;
            buttonAddSource.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddSource.Location = new Point(591, 26);
            buttonAddSource.Name = "buttonAddSource";
            buttonAddSource.Size = new Size(42, 25);
            buttonAddSource.TabIndex = 2;
            buttonAddSource.Text = "Add";
            buttonAddSource.UseVisualStyleBackColor = false;
            buttonAddSource.Click += ButtonAddSource_Click;
            // 
            // buttonAddDestiny
            // 
            buttonAddDestiny.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddDestiny.BackColor = SystemColors.ControlLight;
            buttonAddDestiny.Cursor = Cursors.Cross;
            buttonAddDestiny.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddDestiny.Location = new Point(591, 73);
            buttonAddDestiny.Name = "buttonAddDestiny";
            buttonAddDestiny.Size = new Size(42, 25);
            buttonAddDestiny.TabIndex = 4;
            buttonAddDestiny.Text = "Add";
            buttonAddDestiny.UseVisualStyleBackColor = false;
            buttonAddDestiny.Click += ButtonAddDestiny_Click;
            // 
            // buttonDoneEdit
            // 
            buttonDoneEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDoneEdit.FlatAppearance.BorderColor = Color.Black;
            buttonDoneEdit.Location = new Point(527, 269);
            buttonDoneEdit.Name = "buttonDoneEdit";
            buttonDoneEdit.Size = new Size(103, 36);
            buttonDoneEdit.TabIndex = 10;
            buttonDoneEdit.Text = "Done";
            buttonDoneEdit.UseVisualStyleBackColor = true;
            buttonDoneEdit.Click += ButtonDoneEdit_Click;
            // 
            // checkBoxCleanDestinyDirectory
            // 
            checkBoxCleanDestinyDirectory.Anchor = AnchorStyles.Right;
            checkBoxCleanDestinyDirectory.AutoSize = true;
            checkBoxCleanDestinyDirectory.Location = new Point(260, 155);
            checkBoxCleanDestinyDirectory.Name = "checkBoxCleanDestinyDirectory";
            checkBoxCleanDestinyDirectory.Size = new Size(151, 17);
            checkBoxCleanDestinyDirectory.TabIndex = 7;
            checkBoxCleanDestinyDirectory.Text = "Clean destiny directory first";
            checkBoxCleanDestinyDirectory.UseVisualStyleBackColor = true;
            checkBoxCleanDestinyDirectory.CheckedChanged += CheckBoxCleanDestinyDirectory_CheckedChanged;
            // 
            // buttonSwitchPaths
            // 
            buttonSwitchPaths.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSwitchPaths.ForeColor = SystemColors.ControlDarkDark;
            buttonSwitchPaths.Location = new Point(458, 52);
            buttonSwitchPaths.Name = "buttonSwitchPaths";
            buttonSwitchPaths.Size = new Size(101, 21);
            buttonSwitchPaths.TabIndex = 3;
            buttonSwitchPaths.Text = "Switch Paths";
            buttonSwitchPaths.UseVisualStyleBackColor = true;
            buttonSwitchPaths.Click += ButtonSwitchPaths_Click;
            // 
            // listViewFilesAndExts
            // 
            listViewFilesAndExts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewFilesAndExts.BackColor = SystemColors.Window;
            listViewFilesAndExts.Columns.AddRange(new ColumnHeader[] { columnHeaderFileOrExt });
            listViewFilesAndExts.Enabled = false;
            listViewFilesAndExts.ForeColor = SystemColors.InactiveCaption;
            listViewFilesAndExts.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewFilesAndExts.Location = new Point(4, 26);
            listViewFilesAndExts.MultiSelect = false;
            listViewFilesAndExts.Name = "listViewFilesAndExts";
            listViewFilesAndExts.ShowItemToolTips = true;
            listViewFilesAndExts.Size = new Size(223, 131);
            listViewFilesAndExts.TabIndex = 9;
            listViewFilesAndExts.UseCompatibleStateImageBehavior = false;
            listViewFilesAndExts.View = View.Details;
            listViewFilesAndExts.KeyDown += ListViewFilesAndExts_KeyDown;
            // 
            // columnHeaderFileOrExt
            // 
            columnHeaderFileOrExt.Text = "File or extension";
            columnHeaderFileOrExt.Width = 205;
            // 
            // textBoxFilesAndExts
            // 
            textBoxFilesAndExts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilesAndExts.Enabled = false;
            textBoxFilesAndExts.Location = new Point(4, 160);
            textBoxFilesAndExts.Name = "textBoxFilesAndExts";
            textBoxFilesAndExts.Size = new Size(144, 20);
            textBoxFilesAndExts.TabIndex = 14;
            textBoxFilesAndExts.KeyPress += TextBoxFilesAndExts_KeyPress;
            // 
            // radioButtonIgnore1
            // 
            radioButtonIgnore1.AutoSize = true;
            radioButtonIgnore1.Enabled = false;
            radioButtonIgnore1.Location = new Point(152, 3);
            radioButtonIgnore1.Name = "radioButtonIgnore1";
            radioButtonIgnore1.Size = new Size(55, 17);
            radioButtonIgnore1.TabIndex = 13;
            radioButtonIgnore1.Text = "Ignore";
            radioButtonIgnore1.UseVisualStyleBackColor = true;
            // 
            // radioButtonTransferOnly1
            // 
            radioButtonTransferOnly1.AutoSize = true;
            radioButtonTransferOnly1.Checked = true;
            radioButtonTransferOnly1.Enabled = false;
            radioButtonTransferOnly1.Location = new Point(65, 3);
            radioButtonTransferOnly1.Name = "radioButtonTransferOnly1";
            radioButtonTransferOnly1.Size = new Size(86, 17);
            radioButtonTransferOnly1.TabIndex = 12;
            radioButtonTransferOnly1.TabStop = true;
            radioButtonTransferOnly1.Text = "Transfer only";
            radioButtonTransferOnly1.UseVisualStyleBackColor = true;
            // 
            // buttonRemFileOrExt
            // 
            buttonRemFileOrExt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRemFileOrExt.Enabled = false;
            buttonRemFileOrExt.Location = new Point(190, 159);
            buttonRemFileOrExt.Name = "buttonRemFileOrExt";
            buttonRemFileOrExt.Size = new Size(38, 22);
            buttonRemFileOrExt.TabIndex = 16;
            buttonRemFileOrExt.Text = "Remove";
            buttonRemFileOrExt.UseVisualStyleBackColor = true;
            buttonRemFileOrExt.Click += ButtonRemoveFileOrExt_Click;
            // 
            // buttonAddFileOrExt
            // 
            buttonAddFileOrExt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddFileOrExt.Enabled = false;
            buttonAddFileOrExt.Location = new Point(151, 159);
            buttonAddFileOrExt.Name = "buttonAddFileOrExt";
            buttonAddFileOrExt.Size = new Size(38, 22);
            buttonAddFileOrExt.TabIndex = 15;
            buttonAddFileOrExt.Text = "Add";
            buttonAddFileOrExt.UseVisualStyleBackColor = true;
            buttonAddFileOrExt.Click += ButtonAddFileOrExt_Click;
            // 
            // checkBoxDeleteUncommonFiles
            // 
            checkBoxDeleteUncommonFiles.Anchor = AnchorStyles.Right;
            checkBoxDeleteUncommonFiles.AutoSize = true;
            checkBoxDeleteUncommonFiles.ForeColor = SystemColors.ControlText;
            checkBoxDeleteUncommonFiles.Location = new Point(260, 173);
            checkBoxDeleteUncommonFiles.Name = "checkBoxDeleteUncommonFiles";
            checkBoxDeleteUncommonFiles.Size = new Size(205, 17);
            checkBoxDeleteUncommonFiles.TabIndex = 8;
            checkBoxDeleteUncommonFiles.Text = "Delete uncommon files and directories";
            checkBoxDeleteUncommonFiles.UseVisualStyleBackColor = true;
            checkBoxDeleteUncommonFiles.CheckedChanged += CheckBoxDeleteUncommonFiles_CheckedChanged;
            // 
            // labelKeepOriginFilesHelp
            // 
            labelKeepOriginFilesHelp.Anchor = AnchorStyles.Right;
            labelKeepOriginFilesHelp.AutoSize = true;
            labelKeepOriginFilesHelp.BackColor = Color.Green;
            labelKeepOriginFilesHelp.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelKeepOriginFilesHelp.ForeColor = Color.White;
            labelKeepOriginFilesHelp.Location = new Point(429, 139);
            labelKeepOriginFilesHelp.Name = "labelKeepOriginFilesHelp";
            labelKeepOriginFilesHelp.Size = new Size(11, 12);
            labelKeepOriginFilesHelp.TabIndex = 31;
            labelKeepOriginFilesHelp.Text = "?";
            toolTipHelp.SetToolTip(labelKeepOriginFilesHelp, "Origin files and directories will be copied instead of moved.");
            // 
            // labelCleanDestinyHelp
            // 
            labelCleanDestinyHelp.Anchor = AnchorStyles.Right;
            labelCleanDestinyHelp.AutoSize = true;
            labelCleanDestinyHelp.BackColor = Color.Green;
            labelCleanDestinyHelp.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelCleanDestinyHelp.ForeColor = Color.White;
            labelCleanDestinyHelp.Location = new Point(408, 157);
            labelCleanDestinyHelp.Name = "labelCleanDestinyHelp";
            labelCleanDestinyHelp.Size = new Size(11, 12);
            labelCleanDestinyHelp.TabIndex = 32;
            labelCleanDestinyHelp.Text = "?";
            toolTipHelp.SetToolTip(labelCleanDestinyHelp, "All destiny files and directories will be deleted before transfering.");
            // 
            // labelDeleteUncommonFilesHelp
            // 
            labelDeleteUncommonFilesHelp.Anchor = AnchorStyles.Right;
            labelDeleteUncommonFilesHelp.AutoSize = true;
            labelDeleteUncommonFilesHelp.BackColor = Color.Green;
            labelDeleteUncommonFilesHelp.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelDeleteUncommonFilesHelp.ForeColor = Color.White;
            labelDeleteUncommonFilesHelp.Location = new Point(462, 175);
            labelDeleteUncommonFilesHelp.Name = "labelDeleteUncommonFilesHelp";
            labelDeleteUncommonFilesHelp.Size = new Size(11, 12);
            labelDeleteUncommonFilesHelp.TabIndex = 33;
            labelDeleteUncommonFilesHelp.Text = "?";
            toolTipHelp.SetToolTip(labelDeleteUncommonFilesHelp, "Delete files and directories present in the destiny directory that aren't present in the origin directory.");
            // 
            // toolTipHelp
            // 
            toolTipHelp.AutomaticDelay = 40000;
            toolTipHelp.AutoPopDelay = 30000;
            toolTipHelp.InitialDelay = 500;
            toolTipHelp.ReshowDelay = 100;
            // 
            // labelReenumerateHelp
            // 
            labelReenumerateHelp.Anchor = AnchorStyles.Right;
            labelReenumerateHelp.AutoSize = true;
            labelReenumerateHelp.BackColor = Color.Green;
            labelReenumerateHelp.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelReenumerateHelp.ForeColor = Color.White;
            labelReenumerateHelp.Location = new Point(427, 264);
            labelReenumerateHelp.Name = "labelReenumerateHelp";
            labelReenumerateHelp.Size = new Size(11, 12);
            labelReenumerateHelp.TabIndex = 37;
            labelReenumerateHelp.Text = "?";
            toolTipHelp.SetToolTip(labelReenumerateHelp, resources.GetString("labelReenumerateHelp.ToolTip"));
            // 
            // labelFilterDirsHelp
            // 
            labelFilterDirsHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFilterDirsHelp.AutoSize = true;
            labelFilterDirsHelp.BackColor = Color.Green;
            labelFilterDirsHelp.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelFilterDirsHelp.ForeColor = Color.White;
            labelFilterDirsHelp.Location = new Point(216, 7);
            labelFilterDirsHelp.Name = "labelFilterDirsHelp";
            labelFilterDirsHelp.Size = new Size(11, 12);
            labelFilterDirsHelp.TabIndex = 38;
            labelFilterDirsHelp.Text = "?";
            toolTipHelp.SetToolTip(labelFilterDirsHelp, "Full and relative paths can be used. Relative paths strings are required to start with a directory separator.");
            // 
            // labelFilterFilesHelp
            // 
            labelFilterFilesHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFilterFilesHelp.AutoSize = true;
            labelFilterFilesHelp.BackColor = Color.Green;
            labelFilterFilesHelp.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelFilterFilesHelp.ForeColor = Color.White;
            labelFilterFilesHelp.Location = new Point(216, 7);
            labelFilterFilesHelp.Name = "labelFilterFilesHelp";
            labelFilterFilesHelp.Size = new Size(11, 12);
            labelFilterFilesHelp.TabIndex = 39;
            labelFilterFilesHelp.Text = "?";
            toolTipHelp.SetToolTip(labelFilterFilesHelp, "Filnames can be used normally or with full path.  Extensions are required to start with \".\".");
            // 
            // checkBoxReenumerate
            // 
            checkBoxReenumerate.Anchor = AnchorStyles.Right;
            checkBoxReenumerate.AutoSize = true;
            checkBoxReenumerate.Enabled = false;
            checkBoxReenumerate.ForeColor = SystemColors.ControlText;
            checkBoxReenumerate.Location = new Point(271, 262);
            checkBoxReenumerate.Name = "checkBoxReenumerate";
            checkBoxReenumerate.Size = new Size(158, 17);
            checkBoxReenumerate.TabIndex = 34;
            checkBoxReenumerate.Text = "Re-enumerate renamed files";
            checkBoxReenumerate.UseVisualStyleBackColor = true;
            checkBoxReenumerate.CheckedChanged += CheckBoxReenumerate_CheckedChanged;
            // 
            // numericUpDownMaxKeptRenamedFileCount
            // 
            numericUpDownMaxKeptRenamedFileCount.Anchor = AnchorStyles.Right;
            numericUpDownMaxKeptRenamedFileCount.Enabled = false;
            numericUpDownMaxKeptRenamedFileCount.Location = new Point(407, 283);
            numericUpDownMaxKeptRenamedFileCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownMaxKeptRenamedFileCount.Name = "numericUpDownMaxKeptRenamedFileCount";
            numericUpDownMaxKeptRenamedFileCount.Size = new Size(75, 20);
            numericUpDownMaxKeptRenamedFileCount.TabIndex = 35;
            // 
            // labelMaxKeptRenamedFileCount
            // 
            labelMaxKeptRenamedFileCount.Anchor = AnchorStyles.Right;
            labelMaxKeptRenamedFileCount.AutoSize = true;
            labelMaxKeptRenamedFileCount.Enabled = false;
            labelMaxKeptRenamedFileCount.Location = new Point(269, 285);
            labelMaxKeptRenamedFileCount.Name = "labelMaxKeptRenamedFileCount";
            labelMaxKeptRenamedFileCount.Size = new Size(137, 13);
            labelMaxKeptRenamedFileCount.TabIndex = 36;
            labelMaxKeptRenamedFileCount.Text = "Max. enumerated files kept:";
            // 
            // tabControlFilter
            // 
            tabControlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlFilter.Controls.Add(tabPageFilterFilesAndExts);
            tabControlFilter.Controls.Add(tabPageFilterDirs);
            tabControlFilter.Location = new Point(5, 105);
            tabControlFilter.Name = "tabControlFilter";
            tabControlFilter.SelectedIndex = 0;
            tabControlFilter.Size = new Size(248, 212);
            tabControlFilter.TabIndex = 38;
            // 
            // tabPageFilterFilesAndExts
            // 
            tabPageFilterFilesAndExts.Controls.Add(panel2);
            tabPageFilterFilesAndExts.Location = new Point(4, 22);
            tabPageFilterFilesAndExts.Name = "tabPageFilterFilesAndExts";
            tabPageFilterFilesAndExts.Padding = new Padding(3);
            tabPageFilterFilesAndExts.Size = new Size(240, 186);
            tabPageFilterFilesAndExts.TabIndex = 0;
            tabPageFilterFilesAndExts.Text = "Filter filenames/extensions";
            tabPageFilterFilesAndExts.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelFilterFilesHelp);
            panel2.Controls.Add(listViewFilesAndExts);
            panel2.Controls.Add(checkBoxActive1);
            panel2.Controls.Add(buttonRemFileOrExt);
            panel2.Controls.Add(textBoxFilesAndExts);
            panel2.Controls.Add(radioButtonTransferOnly1);
            panel2.Controls.Add(radioButtonIgnore1);
            panel2.Controls.Add(buttonAddFileOrExt);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 180);
            panel2.TabIndex = 39;
            // 
            // checkBoxActive1
            // 
            checkBoxActive1.AutoSize = true;
            checkBoxActive1.Location = new Point(7, 3);
            checkBoxActive1.Name = "checkBoxActive1";
            checkBoxActive1.Size = new Size(56, 17);
            checkBoxActive1.TabIndex = 17;
            checkBoxActive1.Text = "Active";
            checkBoxActive1.UseVisualStyleBackColor = true;
            checkBoxActive1.CheckedChanged += CheckBoxActive1_CheckedChanged;
            // 
            // tabPageFilterDirs
            // 
            tabPageFilterDirs.Controls.Add(panel1);
            tabPageFilterDirs.Location = new Point(4, 22);
            tabPageFilterDirs.Name = "tabPageFilterDirs";
            tabPageFilterDirs.Padding = new Padding(3);
            tabPageFilterDirs.Size = new Size(240, 186);
            tabPageFilterDirs.TabIndex = 1;
            tabPageFilterDirs.Text = "Filter directories";
            tabPageFilterDirs.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelFilterDirsHelp);
            panel1.Controls.Add(listViewDirs);
            panel1.Controls.Add(checkBoxActive2);
            panel1.Controls.Add(buttonRemDir);
            panel1.Controls.Add(textBoxDirs);
            panel1.Controls.Add(radioButtonTransferOnly2);
            panel1.Controls.Add(radioButtonIgnore2);
            panel1.Controls.Add(buttonAddDir);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 180);
            panel1.TabIndex = 39;
            // 
            // listViewDirs
            // 
            listViewDirs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewDirs.BackColor = SystemColors.Window;
            listViewDirs.Columns.AddRange(new ColumnHeader[] { columnHeaderDir });
            listViewDirs.Enabled = false;
            listViewDirs.ForeColor = SystemColors.InactiveCaption;
            listViewDirs.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewDirs.Location = new Point(4, 26);
            listViewDirs.MultiSelect = false;
            listViewDirs.Name = "listViewDirs";
            listViewDirs.ShowItemToolTips = true;
            listViewDirs.Size = new Size(223, 131);
            listViewDirs.TabIndex = 18;
            listViewDirs.UseCompatibleStateImageBehavior = false;
            listViewDirs.View = View.Details;
            listViewDirs.KeyDown += ListViewDirs_KeyDown;
            // 
            // columnHeaderDir
            // 
            columnHeaderDir.Text = "Directory";
            columnHeaderDir.Width = 205;
            // 
            // checkBoxActive2
            // 
            checkBoxActive2.AutoSize = true;
            checkBoxActive2.Location = new Point(7, 3);
            checkBoxActive2.Name = "checkBoxActive2";
            checkBoxActive2.Size = new Size(56, 17);
            checkBoxActive2.TabIndex = 24;
            checkBoxActive2.Text = "Active";
            checkBoxActive2.UseVisualStyleBackColor = true;
            checkBoxActive2.CheckedChanged += CheckBoxActive2_CheckedChanged;
            // 
            // buttonRemDir
            // 
            buttonRemDir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRemDir.Enabled = false;
            buttonRemDir.Location = new Point(190, 159);
            buttonRemDir.Name = "buttonRemDir";
            buttonRemDir.Size = new Size(38, 22);
            buttonRemDir.TabIndex = 23;
            buttonRemDir.Text = "Remove";
            buttonRemDir.UseVisualStyleBackColor = true;
            buttonRemDir.Click += ButtonRemDir_Click;
            // 
            // textBoxDirs
            // 
            textBoxDirs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDirs.Enabled = false;
            textBoxDirs.Location = new Point(4, 160);
            textBoxDirs.Name = "textBoxDirs";
            textBoxDirs.Size = new Size(144, 20);
            textBoxDirs.TabIndex = 21;
            textBoxDirs.KeyPress += TextBoxDirs_KeyPress;
            // 
            // radioButtonTransferOnly2
            // 
            radioButtonTransferOnly2.AutoSize = true;
            radioButtonTransferOnly2.Checked = true;
            radioButtonTransferOnly2.Enabled = false;
            radioButtonTransferOnly2.Location = new Point(65, 3);
            radioButtonTransferOnly2.Name = "radioButtonTransferOnly2";
            radioButtonTransferOnly2.Size = new Size(86, 17);
            radioButtonTransferOnly2.TabIndex = 19;
            radioButtonTransferOnly2.TabStop = true;
            radioButtonTransferOnly2.Text = "Transfer only";
            radioButtonTransferOnly2.UseVisualStyleBackColor = true;
            // 
            // radioButtonIgnore2
            // 
            radioButtonIgnore2.AutoSize = true;
            radioButtonIgnore2.Enabled = false;
            radioButtonIgnore2.Location = new Point(152, 3);
            radioButtonIgnore2.Name = "radioButtonIgnore2";
            radioButtonIgnore2.Size = new Size(55, 17);
            radioButtonIgnore2.TabIndex = 20;
            radioButtonIgnore2.Text = "Ignore";
            radioButtonIgnore2.UseVisualStyleBackColor = true;
            // 
            // buttonAddDir
            // 
            buttonAddDir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddDir.Enabled = false;
            buttonAddDir.Location = new Point(151, 159);
            buttonAddDir.Name = "buttonAddDir";
            buttonAddDir.Size = new Size(38, 22);
            buttonAddDir.TabIndex = 22;
            buttonAddDir.Text = "Add";
            buttonAddDir.UseVisualStyleBackColor = true;
            buttonAddDir.Click += ButtonAddDir_Click;
            // 
            // FormEditOptions
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(650, 320);
            Controls.Add(tabControlFilter);
            Controls.Add(labelReenumerateHelp);
            Controls.Add(labelMaxKeptRenamedFileCount);
            Controls.Add(numericUpDownMaxKeptRenamedFileCount);
            Controls.Add(checkBoxReenumerate);
            Controls.Add(labelDeleteUncommonFilesHelp);
            Controls.Add(labelCleanDestinyHelp);
            Controls.Add(labelKeepOriginFilesHelp);
            Controls.Add(checkBoxDeleteUncommonFiles);
            Controls.Add(buttonSwitchPaths);
            Controls.Add(checkBoxCleanDestinyDirectory);
            Controls.Add(buttonDoneEdit);
            Controls.Add(buttonAddDestiny);
            Controls.Add(buttonAddSource);
            Controls.Add(checkBoxKeepOriginFiles);
            Controls.Add(checkBoxMoveSubfolders);
            Controls.Add(comboBoxMethod);
            Controls.Add(textBoxDestinyPath);
            Controls.Add(textBoxSourcePath);
            Controls.Add(labelMethod);
            Controls.Add(labelDestinyPath);
            Controls.Add(labelSourcePath);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(666, 359);
            Name = "FormEditOptions";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Options";
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxKeptRenamedFileCount).EndInit();
            tabControlFilter.ResumeLayout(false);
            tabPageFilterFilesAndExts.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPageFilterDirs.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ListView listViewFilesAndExts;
        private System.Windows.Forms.RadioButton radioButtonIgnore1;
        private System.Windows.Forms.RadioButton radioButtonTransferOnly1;
        private System.Windows.Forms.Button buttonRemFileOrExt;
        private System.Windows.Forms.Button buttonAddFileOrExt;
        private System.Windows.Forms.TextBox textBoxFilesAndExts;
        private System.Windows.Forms.ColumnHeader columnHeaderFileOrExt;
        private System.Windows.Forms.CheckBox checkBoxDeleteUncommonFiles;
        private System.Windows.Forms.Label labelKeepOriginFilesHelp;
        private System.Windows.Forms.Label labelCleanDestinyHelp;
        private System.Windows.Forms.Label labelDeleteUncommonFilesHelp;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.CheckBox checkBoxReenumerate;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxKeptRenamedFileCount;
        private System.Windows.Forms.Label labelMaxKeptRenamedFileCount;
        private System.Windows.Forms.Label labelReenumerateHelp;
        private TabControl tabControlFilter;
        private TabPage tabPageFilterFilesAndExts;
        private CheckBox checkBoxActive1;
        private TabPage tabPageFilterDirs;
        private CheckBox checkBoxActive2;
        private TextBox textBoxDirs;
        private RadioButton radioButtonIgnore2;
        private ListView listViewDirs;
        private ColumnHeader columnHeaderDir;
        private Button buttonAddDir;
        private RadioButton radioButtonTransferOnly2;
        private Button buttonRemDir;
        private Label labelFilterDirsHelp;
        private Label labelFilterFilesHelp;
        private Panel panel1;
        private Panel panel2;
    }
}