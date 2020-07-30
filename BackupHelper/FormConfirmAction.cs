using System;
using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormConfirmAction : Form
    {
        //private Object Form;
        public bool ActionIsConfirmed = false;

        public FormConfirmAction(string header)
        {
            InitializeComponent();
            //Form = form;
            this.Text = header;
            this.KeyPreview = true;
        }

        private void ButtonConfirm_Click(object sender, EventArgs args)
        {
            ConfirmClick();
        }

        //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormConfirmAction_KeyDown);
        private void FormConfirmAction_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Enter) ConfirmClick();
            else if (args.KeyCode == Keys.Escape) this.Hide();
        }

        private void ConfirmClick()
        {
            this.ActionIsConfirmed = true;
            this.Hide();

            //if (o.GetType().Equals(typeof(FormProfileMenu)))
            //{
            //    FormProfileMenu menu = (FormProfileMenu)o;
            //    if (action == "delete")
            //    {
            //        menu.DeleteProfile();
            //    }
            //}
            //else
            //{
            //    FormOptionsMenu menu = (FormOptionsMenu)o;
            //    if (action == "delete")
            //    {
            //        menu.DeleteOption();
            //    }
            //}
            //this.Close();
        }

        private void FormConfirmAction_FormClosing(object sender, FormClosingEventArgs args)
        {
            args.Cancel = true;
            this.Hide();
        }
    }
}
