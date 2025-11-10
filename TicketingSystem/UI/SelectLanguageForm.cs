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
    public partial class SelectLanguageForm: ThemedForm
    {
        public SelectLanguageForm()
        {
            InitializeComponent();
        }

     
        private void btnEnglish_Click(object sender, EventArgs e)
        {
            SelectDestinationForm selectDestinationForm = new SelectDestinationForm();
            selectDestinationForm.Show();
            this.Hide();
        }

        private void btnMyanmar_Click(object sender, EventArgs e)
        {
            SelectDestinationFormMm selectDestinationForm = new SelectDestinationFormMm();
            selectDestinationForm.Show();
            this.Hide();
        }

        private void btnVietnamese_Click(object sender, EventArgs e)
        {
            SelectDestinationFormV selectDestinationForm = new SelectDestinationFormV();
            selectDestinationForm.Show();
            this.Hide();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelTransactionForm cancelForm = new CancelTransactionForm();
            cancelForm.Show();
            this.Hide();
        }
    }
}
