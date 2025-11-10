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
    public partial class SelectDestinationForm: ThemedForm
    {
        
     
        public SelectDestinationForm()
        {
            InitializeComponent();
            
        }

  

        private void SelectDestinationFormEng_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelTransactionForm cancelForm = new CancelTransactionForm();
            cancelForm.Show();
            this.Hide();
        }

        private void btnBenThanh_Click(object sender, EventArgs e)
        {
            int destId = 1;
            SelectOption so = new SelectOption(destId);
            so.Show();
            this.Hide();
        }

        private void btnOperaHouse_Click(object sender, EventArgs e)
        {
            int destId = 2;
            SelectOption so = new SelectOption(destId);
            so.Show();
            this.Hide();
        }

        private void btnThuDuc_Click(object sender, EventArgs e)
        {
            int destId = 3;
            SelectOption so = new SelectOption(destId);
            so.Show();
            this.Hide();
        }
    }
}
