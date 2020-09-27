using System.Windows.Forms;

namespace BackupHelper
{
    public partial class FormCancelExecution : Form
    {
        public FormCancelExecution()
        {
            InitializeComponent();
            for (int c = 0; c < 500; c++)
                progressBarCanceling.PerformStep();
        }
    }
}
