using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class TicketBLL
    {
        private TicketDAL ticketDAL = new TicketDAL();

        // Get destinations for display
        public DataTable GetDestinations()
        {
            return ticketDAL.GetDestinations();
        }

        public decimal GetDestinationPrice(int destinationID)
        {
            return ticketDAL.GetDestinationPrice(destinationID);
        }

        // Process ticket purchase
        public string BuyTicket(int destinationID, string paymentMethod, decimal amount)
        {
            try
            {
                // Validate payment against the destination price from the database
                decimal destinationPrice = ticketDAL.GetDestinationPrice(destinationID);
                if (amount < destinationPrice)
                {
                    return "Insufficient amount for the selected destination.";
                }

                // Save payment
                int paymentID = ticketDAL.SavePayment(paymentMethod, amount);

                // Save ticket
                ticketDAL.SaveTicket(destinationID, paymentID);

                return "Ticket issued successfully! Barcode: " + GenerateBarcode();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private string GenerateBarcode()
        {
            return Guid.NewGuid().ToString().Substring(0, 10); // Simplified barcode
        }
    }
}
