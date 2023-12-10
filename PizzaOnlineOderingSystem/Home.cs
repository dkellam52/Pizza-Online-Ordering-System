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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            panel2.Hide();//hide form
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderPizza form2 = new OrderPizza();
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PendingOrders pendingOrders = new PendingOrders();
            pendingOrders.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //create Account
            panel2.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /* if...
            string message = "The email is already in use. Please use a different email address.";
            string title = "Error: Account Already Exists";
            MessageBox.Show(message, title);
            else..*/


            bool notExist = Member.checkEmail(textBox4.Text);
            if (notExist == true)
            {
                //textBox4.Text = "newMember";
                Member newMember = new Member(textBox1.Text, textBox2.Text, textBox4.Text, textBox3.Text, textBox5.Text);
                //System.Console.WriteLine(newMember.getEmail());
                newMember.saveDataToDatabase(newMember);
                string message = "Congratulations! You are a new member.";
                string title = "Welcome";
                MessageBox.Show(message, title);
            }
            else
            {
                textBox4.Text = "already exist";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            EditAccount editAccount = new EditAccount();
            editAccount.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
   
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory();
            orderHistory.ShowDialog();
        }
    }
}
