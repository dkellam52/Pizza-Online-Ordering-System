using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOnlineOderingSystem
{
    public partial class OrderPizza : Form
    {
        private List<CartItem> cartItems = new List<CartItem>();
        public OrderPizza()
        {
            InitializeComponent();
            btnAddToCart1.Tag = 1; // Pizza ID for the first pizza
            btnAddToCart2.Tag = 2; // Pizza ID for the second pizza
            btnAddToCart3.Tag = 3; // Pizza ID for the third pizza
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void btnAddToCart3_Click(object sender, EventArgs e)
        {


        }
        private void btnAddToCart2_Click(object sender, EventArgs e)
        {
            int pizzaId = (int)((Button)sender).Tag;

            // Retrieve pizza details from the database
            CartItem newItem = GetPizzaDetails(pizzaId);

            if (newItem != null)
            {
                cartItems.Add(newItem);
                MessageBox.Show($"{newItem.pizzaName} added to the cart.");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckOut checkout = new CheckOut(cartItems);
            checkout.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToCart1_Click(object sender, EventArgs e)
        {
            int pizzaId = (int)((Button)sender).Tag;

            // Retrieve pizza details from the database
            CartItem newItem = GetPizzaDetails(pizzaId);

            if (newItem != null)
            {
                cartItems.Add(newItem);
                MessageBox.Show($"{newItem.pizzaName} added to the cart.");
            }

        }

        private CartItem GetPizzaDetails(int pizzaId)
        {
            string connStr = "your_database_connection_here";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT pizza_id, pizza_name, pizza_price FROM kellampizza WHERE pizza_id = @pizzaId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pizzaId", pizzaId);

                Console.WriteLine("Query executed :-)");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming pizza_id is an integer in your database
                        int fetchedPizzaId = reader.GetInt32("pizza_id");
                        string pizzaName = reader["pizza_name"].ToString();
                        decimal price = reader.GetDecimal("pizza_price");

                        CartItem newItem = new CartItem(fetchedPizzaId, pizzaName, price);

                        Console.WriteLine("Item is in Cart");

                        return newItem;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        private void btnAddToCart3_Click_1(object sender, EventArgs e)
        {
            int pizzaId = (int)((Button)sender).Tag;

            // Retrieve pizza details from the database
            CartItem newItem = GetPizzaDetails(pizzaId);

            if (newItem != null)
            {
                cartItems.Add(newItem);
                MessageBox.Show($"{newItem.pizzaName} added to the cart.");
            }
        }
    }
}
