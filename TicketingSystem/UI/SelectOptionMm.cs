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
    public partial class SelectOptionMm: ThemedForm
    {
        private readonly TicketBLL ticketService;
        private int destId;

        public SelectOptionMm()
        {
            ticketService = new TicketBLL();
            InitializeComponent();
        }

        public SelectOptionMm(int destId): this()
        {
            this.destId = destId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string paymentMethod = "CreditCard";
            CardInsertFormMm ci = new CardInsertFormMm(paymentMethod,destId);
            ci.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string paymentMethod = "CreditCard";
            QRPayment qr = new QRPayment(paymentMethod,destId);
            qr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CancelTransactionForm cf = new CancelTransactionForm();
            cf.Show();
            this.Hide();
        }
        private void SelectOptionMm_Load(object sender, EventArgs e)
        {
            LoadTicketPrice();
        }

        private void LoadTicketPrice()
        {
            if (destId == 0)
            {
                lblTicketPrice.Text = "လက်မှတ်စျေးနှုန်း: --";
                return;
            }

            try
            {
                decimal price = ticketService.GetDestinationPrice(destId);
                lblTicketPrice.Text = $"လက်မှတ်စျေးနှုန်း: {price:N0} VND";
            }
            catch (Exception ex)
            {
                lblTicketPrice.Text = "စျေးနှုန်းမရရှိနိုင်ပါ";
                MessageBox.Show("လက်မှတ်စျေးနှုန်းကို မရရှိနိုင်ပါ။ " + ex.Message, "ပြသာနာ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
