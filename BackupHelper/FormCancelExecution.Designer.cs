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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelCancel = new System.Windows.Forms.Label();
            this.progressBarCanceling = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelCancel
            // 
            this.labelCancel.AutoSize = true;
            this.labelCancel.Location = new System.Drawing.Point(79, 9);
            this.labelCancel.Name = "labelCancel";
            this.labelCancel.Size = new System.Drawing.Size(63, 13);
            this.labelCancel.TabIndex = 0;
            this.labelCancel.Text = "Canceling...";
            // 
            // progressBarCanceling
            // 
            this.progressBarCanceling.Location = new System.Drawing.Point(12, 41);
            this.progressBarCanceling.Name = "progressBarCanceling";
            this.progressBarCanceling.Size = new System.Drawing.Size(210, 23);
            this.progressBarCanceling.Step = 1;
            this.progressBarCanceling.TabIndex = 1;
            // 
            // FormCancelExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(234, 73);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarCanceling);
            this.Controls.Add(this.labelCancel);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCancelExecution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelCancel;
        private System.Windows.Forms.ProgressBar progressBarCanceling;
    }
}