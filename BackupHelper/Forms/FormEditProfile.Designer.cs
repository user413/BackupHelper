namespace BackupHelper
{
    partial class FormEditProfile
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
            buttonSaveProfile = new Button();
            textBoxProfileName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonSaveProfile
            // 
            buttonSaveProfile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSaveProfile.Location = new Point(103, 67);
            buttonSaveProfile.Name = "buttonSaveProfile";
            buttonSaveProfile.Size = new Size(71, 29);
            buttonSaveProfile.TabIndex = 1;
            buttonSaveProfile.Text = "Save";
            buttonSaveProfile.UseVisualStyleBackColor = true;
            buttonSaveProfile.Click += ButtonSaveProfile_Click;
            // 
            // textBoxProfileName
            // 
            textBoxProfileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxProfileName.Location = new Point(12, 39);
            textBoxProfileName.Name = "textBoxProfileName";
            textBoxProfileName.Size = new Size(253, 20);
            textBoxProfileName.TabIndex = 0;
            textBoxProfileName.KeyDown += TextBoxProfileName_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 16);
            label1.Name = "label1";
            label1.Size = new Size(95, 13);
            label1.TabIndex = 2;
            label1.Text = "Enter profile name:";
            // 
            // FormEditProfile
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 107);
            Controls.Add(label1);
            Controls.Add(textBoxProfileName);
            Controls.Add(buttonSaveProfile);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonSaveProfile;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.Label label1;
    }
}