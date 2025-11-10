using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TicketDAL
    {
        private readonly string connectionString;

        public TicketDAL()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["TicketVendorDB"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                throw new InvalidOperationException("Connection string 'TicketVendorDB' is missing or empty in App.config.");
            }

            connectionString = settings.ConnectionString;
            EnsureDatabaseReachable();
        }

        private void EnsureDatabaseReachable()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                }
            }
            catch (SqlException ex) when (ex.Number == 4060) // Cannot open database requested by the login
            {
                CreateDatabaseIfMissing();
            }
        }

        private void CreateDatabaseIfMissing()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string databaseName = builder.InitialCatalog;
            builder.InitialCatalog = "master";

            string script = BuildDatabaseBootstrapScript(databaseName);

            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(script, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }
        }

        private string BuildDatabaseBootstrapScript(string databaseName)
        {
            return $@"
IF DB_ID('{databaseName}') IS NULL
BEGIN
    EXEC('CREATE DATABASE [{databaseName}]');
END;

USE [{databaseName}];

IF OBJECT_ID('dbo.Destinations','U') IS NULL
BEGIN
    CREATE TABLE dbo.Destinations (
        DestinationID INT PRIMARY KEY IDENTITY(1,1),
        DestinationName NVARCHAR(100) NOT NULL,
        Price DECIMAL(18,2) NOT NULL
    );

    INSERT INTO dbo.Destinations (DestinationName, Price) VALUES 
    ('Ben Thanh Station', 15000.00),
    ('Opera House', 20000.00),
    ('Thu Duc', 20000.00);
END;

IF OBJECT_ID('dbo.Payments','U') IS NULL
BEGIN
    CREATE TABLE dbo.Payments (
        PaymentID INT PRIMARY KEY IDENTITY(1,1),
        PaymentMethod NVARCHAR(50) NOT NULL,
        Amount DECIMAL(18,2) NOT NULL,
        TransactionDate DATETIME NOT NULL,
        Status NVARCHAR(20) NOT NULL
    );
END;

IF OBJECT_ID('dbo.Tickets','U') IS NULL
BEGIN
    CREATE TABLE dbo.Tickets (
        TicketID INT PRIMARY KEY IDENTITY(1,1),
        DestinationID INT NOT NULL,
        IssueDate DATETIME NOT NULL,
        Barcode NVARCHAR(50) NOT NULL,
        PaymentID INT NOT NULL,
        FOREIGN KEY (DestinationID) REFERENCES dbo.Destinations(DestinationID),
        FOREIGN KEY (PaymentID) REFERENCES dbo.Payments(PaymentID)
    );
END;";
        }

        // Get available destinations
        public DataTable GetDestinations()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DestinationID, DestinationName, Price FROM Destinations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Save payment and return PaymentID
        public int SavePayment(string paymentMethod, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Payments (PaymentMethod, Amount, TransactionDate, Status) " +
                               "OUTPUT INSERTED.PaymentID " +
                               "VALUES (@Method, @Amount, @Date, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Method", paymentMethod);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Status", "Completed");
                return (int)cmd.ExecuteScalar();
            }
        }

        // Save ticket
        public void SaveTicket(int destinationID, int paymentID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string barcode = Guid.NewGuid().ToString().Substring(0, 10); // Simple barcode
                string query = "INSERT INTO Tickets (DestinationID, IssueDate, Barcode, PaymentID) " +
                               "VALUES (@DestID, @IssueDate, @Barcode, @PaymentID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DestID", destinationID);
                cmd.Parameters.AddWithValue("@IssueDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                cmd.ExecuteNonQuery();
            }
        }

        public decimal GetDestinationPrice(int destinationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Price FROM Destinations WHERE DestinationID = @DestinationID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DestinationID", destinationID);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    throw new InvalidOperationException("Destination not found.");
                }

                return Convert.ToDecimal(result);
            }
        }
    }
}
