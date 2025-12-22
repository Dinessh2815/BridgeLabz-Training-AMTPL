using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class PracticeExample
    {
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=DINESSH;Database=BillingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection with SQL Successfull");

                using SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    Console.WriteLine("Available Products");
                    Console.WriteLine("ID\tName\tStock\tPrice");
                    string readAllItems = "SELECT ProductId, ProductName, StockQty, Price FROM Inventory";

                    using (SqlCommand cmd = new SqlCommand(readAllItems, connection, transaction))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"{reader["ProductId"]}\t{reader["ProductName"]}\t\t{reader["StockQty"]}\t{reader["Price"]}");
                        }
                    }

                    string updateInvantory = "Update Inventory Set Price = 150 WHERE ProductName = 'Notebook'";
                    using (SqlCommand cmd = new SqlCommand(updateInvantory, connection, transaction))
                    {
                        Console.WriteLine("Update the Inventory for NoteBook Price");
                        cmd.ExecuteNonQuery();

                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed successfully.");


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction rolled back.");
                    Console.WriteLine(ex.Message);

                }
            }
        }
    }
}
