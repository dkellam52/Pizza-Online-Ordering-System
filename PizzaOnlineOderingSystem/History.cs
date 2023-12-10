using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOnlineOderingSystem
{
    public class History
    {
        public int OrderId;
        public DateTime OrderDate;
        public decimal TotalAmount;
        public string Status;
        //constructor
        public History(int OrderId, DateTime OrderDate, decimal TotalAmount, string Status) 
        { 
            this.OrderId = OrderId;
            this.OrderDate = OrderDate;
            this.TotalAmount = TotalAmount;
            this.Status = Status;
        }

        public override string ToString()
        {
            // Customize the string format based on how you want to display the history
            return $"Order ID: {OrderId}, Date: {OrderDate.ToShortDateString()}, Total: ${TotalAmount}, Status: {Status}";
        }

        public static List<History> GetOrderHistoryByMemberId(int memberId)
        {
            List<History> historyList = new List<History>();
            string connectionString = GetConnectionString(); 

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT order_id, order_date, total_amount, status FROM kellam_orders WHERE member_id = @memberId";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@memberId", memberId);

                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32("order_id");
                        DateTime orderDate = reader.GetDateTime("order_date");
                        decimal totalAmount = reader.GetDecimal("total_amount");
                        string status = reader.GetString("status");

                        historyList.Add(new History(orderId, orderDate, totalAmount, status));
                    }
                }
            }
            return historyList;
        }

        private static string GetConnectionString()
        {
            return "your_database_connection_here";
        }

    }
}
