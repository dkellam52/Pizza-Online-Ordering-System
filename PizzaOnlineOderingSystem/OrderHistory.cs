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
    public partial class OrderHistory : Form
    {
        public OrderHistory()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFindHistory_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMemberId.Text.Trim(), out int memberId))
            {
                List<History> orderHistory = History.GetOrderHistoryByMemberId(memberId);
                DisplayOrderHistory(orderHistory);
            }
            else
            {
                MessageBox.Show("Please enter a valid Member ID.");
            }
        }
        private void DisplayOrderHistory(List<History> orderHistory)
        {
            listBoxHistory.Items.Clear();

            foreach (var historyItem in orderHistory)
            {
                listBoxHistory.Items.Add(historyItem.ToString());
            }
        }
    }
}
