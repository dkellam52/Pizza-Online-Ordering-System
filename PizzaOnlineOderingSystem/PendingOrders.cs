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
    public partial class PendingOrders : Form
    {

        public PendingOrders()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtOrderId.Text, out int orderId))
            {
                var pendingOrders = Order.GetPendingOrders(orderId);
                listBoxOrders.Items.Clear();
                foreach (var order in pendingOrders)
                {
                    listBoxOrders.Items.Add(order.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Order ID.");
            }
        }


    }
}
