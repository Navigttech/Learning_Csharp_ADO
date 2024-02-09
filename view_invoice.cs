using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    internal class view_invoice
    {
        public void view_invoices()
        {
            //Invoice invoice = new getdata();
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=Invoice_db";
            Console.WriteLine("Enter The invoice number");
            string invoiceNumber=Console.ReadLine();

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);

                conn.Open();

                string searchSql = "SELECT * FROM invoices_invoice where invoice_no = @InvoiceNumber";
                // Create a command with parameters
                using (NpgsqlCommand cmd = new NpgsqlCommand(searchSql, conn))
                {
                    cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Invoice No: {reader.GetString(10)}, Client Name: {reader.GetString(0)}, Amount: {reader.GetString(12)}"); // Assuming the columns in the database table
                    }

                    reader.Close();
                }


               
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }
    }
}
