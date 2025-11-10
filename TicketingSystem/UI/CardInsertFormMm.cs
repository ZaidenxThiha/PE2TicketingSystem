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
    public partial class CardInsertFormMm: ThemedForm
    {
        private readonly TicketBLL service;
        private System.Windows.Forms.Timer timer = new Timer();
        private string paymentMethod = "";
        private int destId;
        private decimal amount;
        private string res;

        public CardInsertFormMm()
        {
            service = new TicketBLL();
            InitializeComponent();
        }

        public CardInsertFormMm(string paymentMethod, int destId): this()
        {
            this.paymentMethod = paymentMethod;
            this.destId = destId;
        }

        private void CardInsertFormMm_Load(object sender, EventArgs e)
        {
            try
            {
                amount = service.GetDestinationPrice(destId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ရထားလက်မှတ်စျေးနှုန်းကို မရရှိနိုင်ပါ။ " + ex.Message, "ပြသာနာ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            PaymentSuccessfulFormMm psf = new PaymentSuccessfulFormMm();
            psf.Show();
            timer.Stop();
            this.Hide();
        }

        private void showError(object o, EventArgs e)
        {
            ErrorFormMm ef = new ErrorFormMm();
            ef.Show();
            timer.Stop();
            this.Hide();
        }
    }
}
