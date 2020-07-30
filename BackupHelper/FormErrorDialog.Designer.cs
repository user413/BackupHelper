namespace BackupHelper
{
    partial class FormErrorDialog
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
            this.buttonErrorDialogIgnore = new System.Windows.Forms.Button();
            this.buttonErrorDialogCancel = new System.Windows.Forms.Button();
            this.textBoxErrorDialog = new System.Windows.Forms.TextBox();
            this.buttonTryAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonErrorDialogIgnore
            // 
            this.buttonErrorDialogIgnore.Location = new System.Drawing.Point(104, 96);
            this.buttonErrorDialogIgnore.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.buttonErrorDialogIgnore.Name = "buttonErrorDialogIgnore";
            this.buttonErrorDialogIgnore.Size = new System.Drawing.Size(111, 32);
            this.buttonErrorDialogIgnore.TabIndex = 2;
            this.buttonErrorDialogIgnore.Text = "Ignore and Continue";
            this.buttonErrorDialogIgnore.UseVisualStyleBackColor = true;
            this.buttonErrorDialogIgnore.Click += new System.EventHandler(this.ButtonErrorDialogIgnore_Click);
            // 
            // buttonErrorDialogCancel
            // 
            this.buttonErrorDialogCancel.Location = new System.Drawing.Point(230, 96);
            this.buttonErrorDialogCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.buttonErrorDialogCancel.Name = "buttonErrorDialogCancel";
            this.buttonErrorDialogCancel.Size = new System.Drawing.Size(98, 32);
            this.buttonErrorDialogCancel.TabIndex = 3;
            this.buttonErrorDialogCancel.Text = "Cancel Execution";
            this.buttonErrorDialogCancel.UseVisualStyleBackColor = true;
            this.buttonErrorDialogCancel.Click += new System.EventHandler(this.ButtonErrorDialogCancel_Click);
            // 
            // textBoxErrorDialog
            // 
            this.textBoxErrorDialog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxErrorDialog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxErrorDialog.Location = new System.Drawing.Point(11, 5);
            this.textBoxErrorDialog.Margin = new System.Windows.Forms.Padding(13, 13, 5, 13);
            this.textBoxErrorDialog.Multiline = true;
            this.textBoxErrorDialog.Name = "textBoxErrorDialog";
            this.textBoxErrorDialog.ReadOnly = true;
            this.textBoxErrorDialog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxErrorDialog.Size = new System.Drawing.Size(334, 78);
            this.textBoxErrorDialog.TabIndex = 0;
            // 
            // buttonTryAgain
            // 
            this.buttonTryAgain.Location = new System.Drawing.Point(22, 96);
            this.buttonTryAgain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.buttonTryAgain.Name = "buttonTryAgain";
            this.buttonTryAgain.Size = new System.Drawing.Size(67, 32);
            this.buttonTryAgain.TabIndex = 1;
            this.buttonTryAgain.Text = "Try Again";
            this.buttonTryAgain.UseVisualStyleBackColor = true;
            this.buttonTryAgain.Click += new System.EventHandler(this.ButtonTryAgain_Click);
            // 
            // FormErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(344, 143);
            this.ControlBox = false;
            this.Controls.Add(this.buttonTryAgain);
            this.Controls.Add(this.textBoxErrorDialog);
            this.Controls.Add(this.buttonErrorDialogCancel);
            this.Controls.Add(this.buttonErrorDialogIgnore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormErrorDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonErrorDialogIgnore;
        private System.Windows.Forms.Button buttonErrorDialogCancel;
        private System.Windows.Forms.TextBox textBoxErrorDialog;
        private System.Windows.Forms.Button buttonTryAgain;
    }
}