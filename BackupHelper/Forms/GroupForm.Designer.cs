
namespace BinanceAutoTrader
{
    partial class GroupForm
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
            labelSelected = new Label();
            comboBoxSelectGroup = new ComboBox();
            buttonDone = new Button();
            radioButtonSelectGroup = new RadioButton();
            radioButtonNewGroup = new RadioButton();
            textBoxNewGroup = new TextBox();
            SuspendLayout();
            // 
            // labelSelected
            // 
            labelSelected.AutoSize = true;
            labelSelected.Location = new Point(52, 10);
            labelSelected.Name = "labelSelected";
            labelSelected.Size = new Size(55, 13);
            labelSelected.TabIndex = 0;
            labelSelected.Text = "Selected: ";
            // 
            // comboBoxSelectGroup
            // 
            comboBoxSelectGroup.FormattingEnabled = true;
            comboBoxSelectGroup.Location = new Point(111, 39);
            comboBoxSelectGroup.Name = "comboBoxSelectGroup";
            comboBoxSelectGroup.Size = new Size(129, 21);
            comboBoxSelectGroup.TabIndex = 1;
            // 
            // buttonDone
            // 
            buttonDone.Location = new Point(95, 97);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(75, 23);
            buttonDone.TabIndex = 4;
            buttonDone.Text = "Done";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += ButtonDone_Click;
            // 
            // radioButtonSelectGroup
            // 
            radioButtonSelectGroup.AutoSize = true;
            radioButtonSelectGroup.Checked = true;
            radioButtonSelectGroup.Location = new Point(20, 39);
            radioButtonSelectGroup.Name = "radioButtonSelectGroup";
            radioButtonSelectGroup.Size = new Size(88, 17);
            radioButtonSelectGroup.TabIndex = 0;
            radioButtonSelectGroup.TabStop = true;
            radioButtonSelectGroup.Text = "Select group:";
            radioButtonSelectGroup.UseVisualStyleBackColor = true;
            radioButtonSelectGroup.CheckedChanged += RadioButtonSelectGroup_CheckedChanged;
            // 
            // radioButtonNewGroup
            // 
            radioButtonNewGroup.AutoSize = true;
            radioButtonNewGroup.Location = new Point(20, 64);
            radioButtonNewGroup.Name = "radioButtonNewGroup";
            radioButtonNewGroup.Size = new Size(80, 17);
            radioButtonNewGroup.TabIndex = 2;
            radioButtonNewGroup.Text = "New group:";
            radioButtonNewGroup.UseVisualStyleBackColor = true;
            // 
            // textBoxNewGroup
            // 
            textBoxNewGroup.Enabled = false;
            textBoxNewGroup.Location = new Point(111, 64);
            textBoxNewGroup.Name = "textBoxNewGroup";
            textBoxNewGroup.Size = new Size(129, 20);
            textBoxNewGroup.TabIndex = 3;
            // 
            // GroupForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 128);
            Controls.Add(textBoxNewGroup);
            Controls.Add(radioButtonNewGroup);
            Controls.Add(radioButtonSelectGroup);
            Controls.Add(buttonDone);
            Controls.Add(comboBoxSelectGroup);
            Controls.Add(labelSelected);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "GroupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Set group";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.ComboBox comboBoxSelectGroup;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.RadioButton radioButtonSelectGroup;
        private System.Windows.Forms.RadioButton radioButtonNewGroup;
        private System.Windows.Forms.TextBox textBoxNewGroup;
    }
}