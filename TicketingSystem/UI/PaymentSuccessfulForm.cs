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
    public partial class PaymentSuccessfulForm: ThemedForm
    {
        private System.Windows.Forms.Timer timer = new Timer();

        public PaymentSuccessfulForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void PaymentSuccessfulForm_Load(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Tick += new EventHandler(goToMain);
            timer.Start();
        }

        private void goToMain(object o, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            timer.Stop();
            this.Hide();
        }
    }
}
