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
    public partial class CancelTransactionForm: ThemedForm
    {
        public CancelTransactionForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            SelectLanguageForm selectLanguageForm = new SelectLanguageForm();
            selectLanguageForm.Show();
            this.Hide();
        }
    }
}
