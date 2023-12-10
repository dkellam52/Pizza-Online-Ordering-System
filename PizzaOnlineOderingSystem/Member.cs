using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOnlineOderingSystem
{
    internal class Member
    {
        String name;
        String address;
        String email;
        String phone;
        String password;

        //constructor
        public Member(string name, string address, string email, string phone, string password)
        {
            this.name = name;
            this.address = address;
            this.email = email; 
            this.phone = phone;
            this.password = password;
        }

        public void saveDataToDatabase(Member newMember)
        {
            //int localID = Int32.Parse(textBox1.Text);
            //string localName = textBox2.Text;

            Console.WriteLine("Connecting to MySQL...");

            string connStr = "your_database_connection_here";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL again...");
                conn.Open();
                string sql = "INSERT INTO kellammember (member_name, member_address, member_email, member_phone, member_password) VALUES (@uname, @uaddress, @uemail, @uphone, @upassword)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                string tName = newMember.getName();
                string tAddress = newMember.getAddress();
                string tEmail = newMember.getEmail();
                string tPhone = newMember.getPhone();
                string tPassword = newMember.getPassword();
                cmd.Parameters.AddWithValue("@uname", tName);
                cmd.Parameters.AddWithValue("@uaddress", tAddress);
                cmd.Parameters.AddWithValue("@uemail", tEmail);
                cmd.Parameters.AddWithValue("@uphone", tPhone);
                cmd.Parameters.AddWithValue("@upassword", tPassword);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
        public String getName()
        {
            return name;
        }
        public String getAddress()
        {
            return address;
        }
        public String getPhone()
        {
            return phone;
        }
        public String getPassword()
        {
            return password;
        }
        public String getEmail()
        {
            return email;
        }
        private void displayExistanceError()
        {

        }
        public static bool checkEmail(String emailData)
        {
            string s = emailData;
            string connStr = "your_database_connection_here";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM kellammember WHERE member_email=@uemail";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uemail", s);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    myReader.Close();
                    return false;
                }
                else
                {
                    myReader.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            Console.WriteLine("Done.");

            return true;
        }

    }
}

