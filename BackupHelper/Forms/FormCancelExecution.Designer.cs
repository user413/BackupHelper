namespace BackupHelper
{
    partial class FormCancelExecution
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            labelCancel = new Label();
            progressBarCanceling = new ProgressBar();
            SuspendLayout();
            // 
            // labelCancel
            // 
            labelCancel.AutoSize = true;
            labelCancel.Location = new Point(79, 9);
            labelCancel.Name = "labelCancel";
            labelCancel.Size = new Size(63, 13);
            labelCancel.TabIndex = 0;
            labelCancel.Text = "Canceling...";
            // 
            // progressBarCanceling
            // 
            progressBarCanceling.Location = new Point(12, 41);
            progressBarCanceling.Name = "progressBarCanceling";
            progressBarCanceling.Size = new Size(210, 23);
            progressBarCanceling.Step = 1;
            progressBarCanceling.TabIndex = 1;
            // 
            // FormCancelExecution
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(234, 73);
            ControlBox = false;
            Controls.Add(progressBarCanceling);
            Controls.Add(labelCancel);
            Cursor = Cursors.WaitCursor;
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormCancelExecution";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelCancel;
        private System.Windows.Forms.ProgressBar progressBarCanceling;
    }
}