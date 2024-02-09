using InvoiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TestConsoleApp
{
    interface ClientsViewer
    {
        void view_clients();
    }
    internal class view_all_client: ClientsViewer
    {
        public void view_clients()
        {
            //Invoice invoice = new getdata();
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=Invoice_db";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);

                conn.Open();

                string sql = "SELECT * FROM invoices_invoice";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0)); // Assuming the first column is a string
                }

                reader.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }



    }
}
