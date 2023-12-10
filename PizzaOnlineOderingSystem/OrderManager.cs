using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOnlineOderingSystem
{
    public class OrderManager
    {
        // Method to insert an order and get the order number
        public static int InsertOrderAndGetOrderNumber(List<CartItem> cartItems, int memberId)
        {
            string connectionString = GetConnectionString(); // Replace with your actual connection string
            int orderNumber = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert into kellam_orders table and get the auto-generated order_id
                        string orderSql = "INSERT INTO kellam_orders (member_id, order_date, total_amount, status) VALUES (@memberId, @orderDate, @totalAmount, @status); SELECT LAST_INSERT_ID();";
                        MySqlCommand orderCmd = new MySqlCommand(orderSql, connection, transaction);
                        orderCmd.Parameters.AddWithValue("@memberId", memberId);
                        orderCmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
                        orderCmd.Parameters.AddWithValue("@totalAmount", cartItems.Sum(item => item.price));
                        orderCmd.Parameters.AddWithValue("@status", "Processing");

                        // Execute the command and get the inserted order number
                        orderNumber = Convert.ToInt32(orderCmd.ExecuteScalar());

                        // Insert each cart item into the kellam_order_details table
                        foreach (var item in cartItems)
                        {
                            string detailsSql = "INSERT INTO kellam_order_details (order_id, pizza_id, quantity, price) VALUES (@orderId, @pizzaId, @quantity, @price)";
                            MySqlCommand detailsCmd = new MySqlCommand(detailsSql, connection, transaction);
                            detailsCmd.Parameters.AddWithValue("@orderId", orderNumber);
                            detailsCmd.Parameters.AddWithValue("@pizzaId", item.pizzaId);
                            detailsCmd.Parameters.AddWithValue("@quantity", 1); // Update this based on your application logic
                            detailsCmd.Parameters.AddWithValue("@price", item.price);

                            detailsCmd.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        throw new Exception($"An error occurred while placing the order: {ex.Message}");
                    }
                }
            }

            return orderNumber;
        }

        private static string GetConnectionString()
        {
            return "your_database_connection_here";
        }
    }
}

