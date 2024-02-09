using Npgsql;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp;

namespace InvoiceSystem
{


    class Invoice
    {
        string client_name;
        string client_address;
        string client_gstin;
        string client_contact_details;
        string client_country;
        string client_statecode;
        string invoice_no;
        string invoice_date;
        DateTime parsed_invoice_date;
        string service_accounting_code;
        string description_of_service;
        float hours_units;
        float value_usd;
        float taxable_value_inr;
        float tax;
        float total_amount;
        public void getdata()
        {
            Console.WriteLine("Enter the Invoice Details:");
            Console.WriteLine("Enter the client_name");
            client_name = Console.ReadLine();
            Console.WriteLine("Enter the client_address;");
            client_address = Console.ReadLine();
            Console.WriteLine("Enter the client_gstin");
            client_gstin = Console.ReadLine();
            Console.WriteLine("Enter the client_contact_details");
            client_contact_details = Console.ReadLine();
            Console.WriteLine("Enter the client_country");
            client_country = Console.ReadLine();
            Console.WriteLine("Enter the client_statecode");
            client_statecode = Console.ReadLine();
            Console.WriteLine("Enter the invoice_no");
            invoice_no = Console.ReadLine();
            Console.WriteLine("Enter the invoice_date  (YYYY-MM-DD): ");
            invoice_date = Console.ReadLine();
            try
            {
                // Parse the user input to a DateTime object with the specified format
                DateTime parsed_invoice_date = DateTime.ParseExact(invoice_date, "yyyy-MM-dd", null);

                // Successfully parsed the input to a DateTime object
                // Now you can use the invoiceDate object in your SQL query
            }
            catch (FormatException)
            {
                // Failed to parse the input to a DateTime object
                Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
            }
            Console.WriteLine("Enter the service_accounting_code");
            service_accounting_code = Console.ReadLine();
            Console.WriteLine("Enter the description_of_service");
            description_of_service = Console.ReadLine();
            Console.WriteLine("Enter the hours_units");
            hours_units = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value_usd");
            value_usd = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the taxable_value_inr");
            taxable_value_inr = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the tax");
            tax = float.Parse(Console.ReadLine());

            total_amount = taxable_value_inr + tax;
            Console.WriteLine("Total Amount of Invoice is {0}", total_amount);

        }

        void add_invoice()
        {   //Invoice invoice = new Invoice();
            this.getdata();
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=Invoice_db";

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connectionString);

                conn.Open();

                // INSERT statement
                string insertSql = "INSERT INTO invoices_invoice (client_name,client_address,client_gstin,client_contact_details,client_country,client_statecode,invoice_no,invoice_date,service_accounting_code,description_of_service,hours_units,value_usd,taxable_value_inr,tax,total_amount) VALUES (@client_name,@client_address,@client_gstin,@client_contact_details,@client_country,@client_statecode,@invoice_no,@invoice_date,@service_accounting_code,@description_of_service,@hours_units,@value_usd,@taxable_value_inr,@tax,@total_amount)";

                // Create a command with parameters
                using (NpgsqlCommand cmd = new NpgsqlCommand(insertSql, conn))
                {


                    //NpgsqlCommand cmd = new NpgsqlCommand(insertSql, conn);
                    cmd.Parameters.AddWithValue("@client_name", client_name);
                    cmd.Parameters.AddWithValue("@client_address", client_address);
                    cmd.Parameters.AddWithValue("@client_gstin", client_gstin);
                    cmd.Parameters.AddWithValue("@client_contact_details", client_contact_details);
                    cmd.Parameters.AddWithValue("@client_country", client_country);
                    cmd.Parameters.AddWithValue("@client_statecode", client_statecode);
                    cmd.Parameters.AddWithValue("@invoice_no", invoice_no);
                    cmd.Parameters.AddWithValue("@invoice_date", parsed_invoice_date);
                    cmd.Parameters.AddWithValue("@service_accounting_code", service_accounting_code);
                    cmd.Parameters.AddWithValue("@description_of_service", description_of_service);
                    cmd.Parameters.AddWithValue("@hours_units", hours_units);
                    cmd.Parameters.AddWithValue("@value_usd", value_usd);
                    cmd.Parameters.AddWithValue("@taxable_value_inr", taxable_value_inr);
                    cmd.Parameters.AddWithValue("@tax", tax);
                    cmd.Parameters.AddWithValue("@total_amount", total_amount);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine(rowsAffected + "  Invoice saved successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record inserted.");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Invoice Portal");
            while (true)
            {
                int choice;
                Console.WriteLine("Choose any following option");
                Console.WriteLine("1. Create a new Invoice");
                Console.WriteLine("2. View all the previous account");
                Console.WriteLine("3. view an invoice");
                Console.WriteLine("4. Exit");

                choice = int.Parse(Console.ReadLine());

                // Switch statement to handle user choice
                switch (choice)
                {
                    case 1:
                        // Code to handle option 1: Create a new Invoice
                        Invoice inv = new Invoice();
                        inv.add_invoice();
                        break;
                    case 2:
                        // Code to handle option 2: View all the previous accounts
                        view_all_client clientViewer = new view_all_client();

                        // Call the view_clients method
                        clientViewer.view_clients();
                        break;
                    case 3:
                        // Code to handle option 3: View an invoice
                        view_invoice temp = new view_invoice();
                        temp.view_invoices();
                        break;
                    case 4:
                        // Exit the program
                        Console.WriteLine("Exiting the Invoice Portal. Goodbye!");
                        return;
                    default:
                        // Code to handle invalid choice
                        Console.WriteLine("Invalid choice! Please choose a valid option.");
                        break;
                }
                //Invoice inv = new Invoice();
                //inv.add_invoice();
                //console.writeline(" completed the work ");

            }
        }

    }
}