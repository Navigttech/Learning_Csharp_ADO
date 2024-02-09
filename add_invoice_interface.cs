//using InvoiceSystem;
//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace TestConsoleApp
//{
//    internal interface add_invoice_interface
//    {
//        public void getdata()
//        {
//            Console.WriteLine("Enter the Invoice Details:");
//            Console.WriteLine("Enter the client_name");
//            client_name = Console.ReadLine();
//            Console.WriteLine("Enter the client_address;");
//            client_address = Console.ReadLine();
//            Console.WriteLine("Enter the client_gstin");
//            client_gstin = Console.ReadLine();
//            Console.WriteLine("Enter the client_contact_details");
//            client_contact_details = Console.ReadLine();
//            Console.WriteLine("Enter the client_country");
//            client_country = Console.ReadLine();
//            Console.WriteLine("Enter the client_statecode");
//            client_statecode = Console.ReadLine();
//            Console.WriteLine("Enter the invoice_no");
//            invoice_no = Console.ReadLine();
//            Console.WriteLine("Enter the invoice_date ");
//            invoice_date = Console.ReadLine();
//            Console.WriteLine("Enter the service_accounting_code");
//            service_accounting_code = Console.ReadLine();
//            Console.WriteLine("Enter the description_of_service");
//            description_of_service = Console.ReadLine();
//            Console.WriteLine("Enter the hours_units");
//            hours_units = float.Parse(Console.ReadLine());
//            Console.WriteLine("Enter the value_usd");
//            value_usd = float.Parse(Console.ReadLine());
//            Console.WriteLine("Enter the taxable_value_inr");
//            taxable_value_inr = float.Parse(Console.ReadLine());
//            Console.WriteLine("Enter the tax");
//            tax = float.Parse(Console.ReadLine());

//            total_amount = taxable_value_inr + tax;
//            Console.WriteLine("Total Amount of Invoice is {0}", total_amount);

//        }
//        void add_invoice(string[] args)
//        {
//            Invoice invoice = new getdata();
//            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=Invoice_db";

//            try
//            {
//                NpgsqlConnection conn = new NpgsqlConnection(connectionString);

//                conn.Open();

//                // INSERT statement
//                string insertSql = "INSERT INTO my_table (column1, column2) VALUES (@value1, @value2)";

//                // Create a command with parameters
//                NpgsqlCommand cmd = new NpgsqlCommand(insertSql, conn);
//                cmd.Parameters.AddWithValue("@value1", "Value1"); // Example value for column1
//                cmd.Parameters.AddWithValue("@value2", "Value2"); // Example value for column2

//                // Execute the command
//                int rowsAffected = cmd.ExecuteNonQuery();

//                // Check if the insertion was successful
//                if (rowsAffected > 0)
//                {
//                    Console.WriteLine("Record inserted successfully.");
//                }
//                else
//                {
//                    Console.WriteLine("No record inserted.");
//                }

//                conn.Close();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("An error occurred: " + ex.Message);
//            }

//        }



//    }
//}
