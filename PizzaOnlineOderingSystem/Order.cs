using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PizzaOnlineOderingSystem
{
    internal class Order
    {
        int orderId;
        int memberId;
        DateTime orderDate;
        decimal totalAmount;
        string orderStatus;

        //constructor
        public Order(int orderId, int memberId, DateTime orderDate, decimal totalAmount, string orderStatus)
        {
            this.orderId = orderId;
            this.memberId = memberId;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;
            this.orderStatus = orderStatus;
        }

        // ToString method
        public override string ToString()
        {
            return $"Order ID: {orderId}, Member ID: {memberId}, Order Date: {orderDate.ToShortDateString()}, Total Amount: {totalAmount}, Status: {orderStatus}";
        }

        // GetPendingOrders method
        public static List<Order> GetPendingOrders(int orderId)
        {
            List<Order> orderList = new List<Order>();

            string connStr = "your_database_connection_here";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT order_id, member_id, order_date, total_amount, status FROM kellam_orders WHERE order_id = @orderId AND status = 'Processing'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                DataTable myTable = new DataTable();
                myAdapter.Fill(myTable);

                Console.WriteLine("Table is ready.");

                foreach (DataRow row in myTable.Rows)
                {
                    int orderID = row["order_id"] != DBNull.Value ? Convert.ToInt32(row["order_id"]) : 0;
                    int memberId = row["member_id"] != DBNull.Value ? Convert.ToInt32(row["member_id"]) : 0;
                    DateTime orderDate = row["order_date"] != DBNull.Value ? Convert.ToDateTime(row["order_date"]) : DateTime.MinValue;
                    decimal totalAmount = row["total_amount"] != DBNull.Value ? Convert.ToDecimal(row["total_amount"]) : 0;
                    string orderStatus = row["status"] != DBNull.Value ? row["status"].ToString() : string.Empty;

                    Order newOrder = new Order(orderID, memberId, orderDate, totalAmount, orderStatus);
                    orderList.Add(newOrder);
                }
                Console.WriteLine("Data is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            return orderList;
        }
    }
}
