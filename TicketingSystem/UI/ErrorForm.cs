using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ErrorForm: ThemedForm
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public ErrorForm(string res)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelTransactionForm ctf = new CancelTransactionForm();
            ctf.Show();
            this.Hide();
        }

        private void RetryBtn_Click(object sender, EventArgs e)
        {
            SelectDestinationForm sdf = new SelectDestinationForm();
            sdf.Show();
            this.Hide();
        }
    }
}
