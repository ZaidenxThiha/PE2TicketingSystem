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
    public partial class SelectOptionFormV: ThemedForm
    {
        private readonly TicketBLL ticketService;
        private int destId;

        public SelectOptionFormV()
        {
            ticketService = new TicketBLL();
            InitializeComponent();
        }

        public SelectOptionFormV(int destId): this()
        {
            this.destId = destId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string paymentMethod = "CreditCard";
            CardInsertFormV civ = new CardInsertFormV(paymentMethod,destId);
            civ.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string paymentMethod = "QR";
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
        private void SelectOptionFormV_Load(object sender, EventArgs e)
        {
            LoadTicketPrice();
        }

        private void LoadTicketPrice()
        {
            if (destId == 0)
            {
                lblTicketPrice.Text = "Giá vé: --";
                return;
            }

            try
            {
                decimal price = ticketService.GetDestinationPrice(destId);
                lblTicketPrice.Text = $"Giá vé: {price:N0} VND";
            }
            catch (Exception ex)
            {
                lblTicketPrice.Text = "Không thể tải giá vé";
                MessageBox.Show("Không thể tải giá vé. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
