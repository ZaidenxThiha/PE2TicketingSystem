using BLL;
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
    public partial class CardInsertForm: ThemedForm
    {
        private readonly TicketBLL service;
        private System.Windows.Forms.Timer timer = new Timer();
        private string paymentMethod = "";
        private int destId;
        private decimal amount;
        private string res;

        public CardInsertForm()
        {
            service = new TicketBLL();
            InitializeComponent();
        }

        public CardInsertForm(string paymentMethod, int destId): this()
        {
            this.paymentMethod = paymentMethod;
            this.destId = destId;
        }

        private void CardInsertForm_Load(object sender, EventArgs e)
        {
            try
            {
                amount = service.GetDestinationPrice(destId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load ticket price. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            res = service.BuyTicket(destId, paymentMethod, amount);
            timer.Interval = 7000;
            if (res.Contains("Insufficient"))
            {
                timer.Tick += new EventHandler(showError);
            }
            else
            {
                timer.Tick += new EventHandler(changeForms);
            }
                
            timer.Start();
        }

        private void changeForms(object o, EventArgs e)
        {
            PaymentSuccessfulForm psf = new PaymentSuccessfulForm();
            psf.Show();
            timer.Stop();
            this.Hide();
        }

        private void showError(object o, EventArgs e)
        {
            ErrorForm ef = new ErrorForm();
            ef.Show();
            timer.Stop();
            this.Hide();
        }
    }
}
