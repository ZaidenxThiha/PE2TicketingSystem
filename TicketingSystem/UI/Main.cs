using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Main: ThemedForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnBuyTicket_Click(object sender, EventArgs e)
        {
            SelectLanguageForm selectLanguageForm = new SelectLanguageForm();
            selectLanguageForm.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }


    }
}
