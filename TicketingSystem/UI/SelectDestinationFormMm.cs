using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SelectDestinationFormMm: ThemedForm
    {
        public SelectDestinationFormMm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelTransactionForm cancelForm = new CancelTransactionForm();
            cancelForm.Show();
            this.Hide();
        }

        private void btnBenThanhMm_Click(object sender, EventArgs e)
        {
            int destId = 1;
            SelectOptionMm so = new SelectOptionMm(destId);
            so.Show();
            this.Hide();
        }

        private void btnOperaHouseMm_Click(object sender, EventArgs e)
        {
            int destId = 2;
            SelectOptionMm so = new SelectOptionMm(destId);
            so.Show();
            this.Hide();
        }

        private void btnThuDucMm_Click(object sender, EventArgs e)
        {
            int destId = 3;
            SelectOptionMm so = new SelectOptionMm(destId);
            so.Show();
            this.Hide();
        }
    }
}
