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
            buttonErrorDialogIgnore = new Button();
            buttonErrorDialogCancel = new Button();
            textBoxErrorDialog = new TextBox();
            buttonTryAgain = new Button();
            SuspendLayout();
            // 
            // buttonErrorDialogIgnore
            // 
            buttonErrorDialogIgnore.Location = new Point(104, 96);
            buttonErrorDialogIgnore.Margin = new Padding(3, 3, 3, 5);
            buttonErrorDialogIgnore.Name = "buttonErrorDialogIgnore";
            buttonErrorDialogIgnore.Size = new Size(111, 32);
            buttonErrorDialogIgnore.TabIndex = 2;
            buttonErrorDialogIgnore.Text = "Ignore and Continue";
            buttonErrorDialogIgnore.UseVisualStyleBackColor = true;
            buttonErrorDialogIgnore.Click += ButtonErrorDialogIgnore_Click;
            // 
            // buttonErrorDialogCancel
            // 
            buttonErrorDialogCancel.Location = new Point(230, 96);
            buttonErrorDialogCancel.Margin = new Padding(3, 3, 3, 5);
            buttonErrorDialogCancel.Name = "buttonErrorDialogCancel";
            buttonErrorDialogCancel.Size = new Size(98, 32);
            buttonErrorDialogCancel.TabIndex = 3;
            buttonErrorDialogCancel.Text = "Cancel Execution";
            buttonErrorDialogCancel.UseVisualStyleBackColor = true;
            buttonErrorDialogCancel.Click += ButtonErrorDialogCancel_Click;
            // 
            // textBoxErrorDialog
            // 
            textBoxErrorDialog.BorderStyle = BorderStyle.None;
            textBoxErrorDialog.ImeMode = ImeMode.NoControl;
            textBoxErrorDialog.Location = new Point(11, 5);
            textBoxErrorDialog.Margin = new Padding(13, 13, 5, 13);
            textBoxErrorDialog.Multiline = true;
            textBoxErrorDialog.Name = "textBoxErrorDialog";
            textBoxErrorDialog.ReadOnly = true;
            textBoxErrorDialog.ScrollBars = ScrollBars.Vertical;
            textBoxErrorDialog.Size = new Size(334, 78);
            textBoxErrorDialog.TabIndex = 0;
            // 
            // buttonTryAgain
            // 
            buttonTryAgain.Location = new Point(22, 96);
            buttonTryAgain.Margin = new Padding(3, 3, 3, 5);
            buttonTryAgain.Name = "buttonTryAgain";
            buttonTryAgain.Size = new Size(67, 32);
            buttonTryAgain.TabIndex = 1;
            buttonTryAgain.Text = "Try Again";
            buttonTryAgain.UseVisualStyleBackColor = true;
            buttonTryAgain.Click += ButtonTryAgain_Click;
            // 
            // FormErrorDialog
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(344, 143);
            ControlBox = false;
            Controls.Add(buttonTryAgain);
            Controls.Add(textBoxErrorDialog);
            Controls.Add(buttonErrorDialogCancel);
            Controls.Add(buttonErrorDialogIgnore);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormErrorDialog";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Error";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonErrorDialogIgnore;
        private System.Windows.Forms.Button buttonErrorDialogCancel;
        private System.Windows.Forms.TextBox textBoxErrorDialog;
        private System.Windows.Forms.Button buttonTryAgain;
    }
}