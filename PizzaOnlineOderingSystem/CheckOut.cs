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
    public partial class CheckOut : Form
    {
        private List<CartItem> cartItems;

        public CheckOut(List<CartItem> items)
        {
            InitializeComponent();
            cartItems = items;
        }

        private bool ValidatePaymentInfo()
        {
            string cardNumber = txtCardNumber.Text.Trim();

            if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
            {
                MessageBox.Show("Invalid card number. The card number must be 16 digits.");
                return false;
            }

            // Add additional validations if needed

            return true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ValidatePaymentInfo())
            {
                // Parse the member ID from the textbox
                if (int.TryParse(txtMemberID.Text.Trim(), out int memberId))
                {
                    try
                    {
                        int orderNumber = OrderManager.InsertOrderAndGetOrderNumber(cartItems, memberId);
                        MessageBox.Show($"Your order has been placed successfully. Your order number is: {orderNumber}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while placing the order: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Member ID.");
                }
            }
        }


        private void CheckOut_Load(object sender, EventArgs e)
        {
            DisplayCartItems();
        }

        private void DisplayCartItems()
        {
            listBoxCartItems.Items.Clear();
            decimal total = 0;

            foreach (var item in cartItems)
            {
                listBoxCartItems.Items.Add(item.ToString());
                total += item.price;
            }

            labelTotal.Text = $"Total: ${total}";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
