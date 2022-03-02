
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
            this.labelSelected = new System.Windows.Forms.Label();
            this.comboBoxSelectGroup = new System.Windows.Forms.ComboBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.radioButtonSelectGroup = new System.Windows.Forms.RadioButton();
            this.radioButtonNewGroup = new System.Windows.Forms.RadioButton();
            this.textBoxNewGroup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Location = new System.Drawing.Point(52, 10);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(55, 13);
            this.labelSelected.TabIndex = 0;
            this.labelSelected.Text = "Selected: ";
            // 
            // comboBoxSelectGroup
            // 
            this.comboBoxSelectGroup.FormattingEnabled = true;
            this.comboBoxSelectGroup.Location = new System.Drawing.Point(111, 39);
            this.comboBoxSelectGroup.Name = "comboBoxSelectGroup";
            this.comboBoxSelectGroup.Size = new System.Drawing.Size(129, 21);
            this.comboBoxSelectGroup.TabIndex = 1;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(95, 97);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 4;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // radioButtonSelectGroup
            // 
            this.radioButtonSelectGroup.AutoSize = true;
            this.radioButtonSelectGroup.Checked = true;
            this.radioButtonSelectGroup.Location = new System.Drawing.Point(20, 39);
            this.radioButtonSelectGroup.Name = "radioButtonSelectGroup";
            this.radioButtonSelectGroup.Size = new System.Drawing.Size(88, 17);
            this.radioButtonSelectGroup.TabIndex = 0;
            this.radioButtonSelectGroup.TabStop = true;
            this.radioButtonSelectGroup.Text = "Select group:";
            this.radioButtonSelectGroup.UseVisualStyleBackColor = true;
            this.radioButtonSelectGroup.CheckedChanged += new System.EventHandler(this.RadioButtonSelectGroup_CheckedChanged);
            // 
            // radioButtonNewGroup
            // 
            this.radioButtonNewGroup.AutoSize = true;
            this.radioButtonNewGroup.Location = new System.Drawing.Point(20, 64);
            this.radioButtonNewGroup.Name = "radioButtonNewGroup";
            this.radioButtonNewGroup.Size = new System.Drawing.Size(80, 17);
            this.radioButtonNewGroup.TabIndex = 2;
            this.radioButtonNewGroup.Text = "New group:";
            this.radioButtonNewGroup.UseVisualStyleBackColor = true;
            // 
            // textBoxNewGroup
            // 
            this.textBoxNewGroup.Enabled = false;
            this.textBoxNewGroup.Location = new System.Drawing.Point(111, 64);
            this.textBoxNewGroup.Name = "textBoxNewGroup";
            this.textBoxNewGroup.Size = new System.Drawing.Size(129, 20);
            this.textBoxNewGroup.TabIndex = 3;
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 128);
            this.Controls.Add(this.textBoxNewGroup);
            this.Controls.Add(this.radioButtonNewGroup);
            this.Controls.Add(this.radioButtonSelectGroup);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.comboBoxSelectGroup);
            this.Controls.Add(this.labelSelected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set group";
            this.ResumeLayout(false);
            this.PerformLayout();

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