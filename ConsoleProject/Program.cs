using System;
using Microsoft.Data.SqlClient;

namespace ConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Data Source=DINESSH;Database=BillingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected to SQL Server successfully!");

                using SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // STEP 1: Show available products
                    Console.WriteLine("Available Products:");
                    Console.WriteLine("ID\tName\t\tStock\tPrice");

                    string getProductsQuery =
                        "SELECT ProductId, ProductName, StockQty, Price FROM Inventory";

                    using (SqlCommand cmd = new SqlCommand(getProductsQuery, connection, transaction))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"{reader["ProductId"]}\t{reader["ProductName"]}\t\t{reader["StockQty"]}\t{reader["Price"]}");
                        }
                    }

                    Console.WriteLine();

                    // STEP 2: User input
                    Console.Write("Enter Product ID you want to buy: ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    if (quantity <= 0)
                        throw new Exception("Quantity must be greater than zero.");

                    // STEP 3: Create Bill FIRST
                    string insertBillQuery =
                        "INSERT INTO Bills (TotalAmount) VALUES (0); SELECT SCOPE_IDENTITY();";

                    int billId;
                    using (SqlCommand cmd = new SqlCommand(insertBillQuery, connection, transaction))
                    {
                        billId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    Console.WriteLine($"Bill created. BillId = {billId}");

                    // STEP 4: Check stock
                    int availableStock;
                    string checkStockQty =
                        "SELECT StockQty FROM Inventory WHERE ProductId = @pid";

                    using (SqlCommand cmd = new SqlCommand(checkStockQty, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid", productId);

                        object result = cmd.ExecuteScalar();
                        if (result == null)
                            throw new Exception("Invalid Product selected.");

                        availableStock = Convert.ToInt32(result);
                    }

                    if (availableStock < quantity)
                        throw new Exception("Insufficient stock.");

                    // STEP 5: Get price
                    decimal price;
                    string getProductPrice =
                        "SELECT Price FROM Inventory WHERE ProductId = @pid";

                    using (SqlCommand cmd = new SqlCommand(getProductPrice, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@pid", productId);
                        price = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    // STEP 6: Insert BillItem
                    string insertBillItemQuery =
                        @"INSERT INTO BillItems (BillId, ProductId, Quantity, Price)
                          VALUES (@bid, @pid, @qty, @price)";

                    using (SqlCommand cmd = new SqlCommand(insertBillItemQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@bid", billId);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.Parameters.AddWithValue("@qty", quantity);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.ExecuteNonQuery();
                    }

                    // STEP 7: Update Inventory
                    string updateInventoryQuery =
                        "UPDATE Inventory SET StockQty = StockQty - @qty WHERE ProductId = @pid";

                    using (SqlCommand cmd = new SqlCommand(updateInventoryQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@qty", quantity);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.ExecuteNonQuery();
                    }

                    // STEP 8: Update Bill Total
                    decimal itemTotal = price * quantity;
                    string updateBillTotalQuery =
                        "UPDATE Bills SET TotalAmount = TotalAmount + @amount WHERE BillId = @bid";

                    using (SqlCommand cmd = new SqlCommand(updateBillTotalQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@amount", itemTotal);
                        cmd.Parameters.AddWithValue("@bid", billId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Billing completed successfully!");
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