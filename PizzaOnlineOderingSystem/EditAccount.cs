using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOnlineOderingSystem
{
    public partial class EditAccount : Form
    {
        public EditAccount()
        {
            InitializeComponent();
            panel1.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMemberID.Text.Trim(), out int memberId))
            {
                MemberManager.UpdateMemberProfile(memberId, txtName.Text.Trim(), txtAddress.Text.Trim(), txtPhone.Text.Trim());
                MessageBox.Show("Profile updated successfully.");
                panel1.Show();
                DisplayUpdatedProfile(memberId); // Display updated profile in the ListBox
            }
            else
            {
                MessageBox.Show("Please enter a valid Member ID.");
            }
        }

        private void DisplayUpdatedProfile(int memberId)
        {
            var memberManager = MemberManager.GetMemberProfile(memberId);
            if (memberManager != null)
            {
                listBoxProfile.Items.Clear(); // Clear previous items

                listBoxProfile.Items.Add($"Name: {memberManager.name}");
                listBoxProfile.Items.Add($"Address: {memberManager.address}");
                listBoxProfile.Items.Add($"Phone: {memberManager.phone}");
            }
            else
            {
                MessageBox.Show("Member profile not found.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
