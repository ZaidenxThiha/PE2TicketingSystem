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
    public partial class SelectOption: ThemedForm
    {
        private readonly TicketBLL ticketService;
        private int destId;

        public SelectOption()
        {
            ticketService = new TicketBLL();
            InitializeComponent();
        }

        public SelectOption(int destId): this()
        {
            this.destId = destId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string paymentMethod = "CreditCard";
            CardInsertForm ci = new CardInsertForm(paymentMethod,destId);
            ci.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string paymentMethod = "QR";
            QRPayment qr = new QRPayment(paymentMethod, destId);
            qr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CancelTransactionForm cf = new CancelTransactionForm();
            cf.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SelectOption_Load(object sender, EventArgs e)
        {
            LoadTicketPrice();
        }

        private void LoadTicketPrice()
        {
            if (destId == 0)
            {
                lblTicketPrice.Text = "Ticket price: destination not selected.";
                return;
            }

            try
            {
                decimal price = ticketService.GetDestinationPrice(destId);
                lblTicketPrice.Text = $"Ticket price: {price:N0} VND";
            }
            catch (Exception ex)
            {
                lblTicketPrice.Text = "Ticket price: unavailable";
                MessageBox.Show("Unable to load ticket price. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
