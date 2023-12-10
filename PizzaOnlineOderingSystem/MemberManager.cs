using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOnlineOderingSystem
{
    public class MemberManager
    {
        public string name;
        public string address;
        public string phone;
        public MemberManager(string name, string address, string phone) 
        { 
            this.name = name;
            this.address = address;
            this.phone = phone;
        }
        public static void UpdateMemberProfile(int memberId, string name, string address, string phone)
        {
            string connectionString = GetConnectionString(); // Replace with your actual connection string

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                StringBuilder sqlBuilder = new StringBuilder("UPDATE kellammember SET ");

                // Dynamically build the SQL query based on provided values
                var parameters = new List<MySqlParameter>();
                if (!string.IsNullOrEmpty(name))
                {
                    sqlBuilder.Append("member_name = @name, ");
                    parameters.Add(new MySqlParameter("@name", name));
                }
                if (!string.IsNullOrEmpty(address))
                {
                    sqlBuilder.Append("member_address = @address, ");
                    parameters.Add(new MySqlParameter("@address", address));
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    sqlBuilder.Append("member_phone = @phone, ");
                    parameters.Add(new MySqlParameter("@phone", phone));
                }

                // Remove the last comma and space
                sqlBuilder.Length -= 2;
                sqlBuilder.Append(" WHERE member_id = @memberId");
                parameters.Add(new MySqlParameter("@memberId", memberId));

                MySqlCommand cmd = new MySqlCommand(sqlBuilder.ToString(), connection);
                cmd.Parameters.AddRange(parameters.ToArray());

                cmd.ExecuteNonQuery();
            }

        }
        public static MemberManager GetMemberProfile(int memberId)
        {
            string connectionString = GetConnectionString();
            MemberManager memberManager = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT member_name, member_address, member_phone FROM kellammember WHERE member_id = @memberId";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@memberId", memberId);

                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.IsDBNull(reader.GetOrdinal("member_name")) ? "" : reader.GetString("member_name");
                        string address = reader.IsDBNull(reader.GetOrdinal("member_address")) ? "" : reader.GetString("member_address");
                        string phone = reader.IsDBNull(reader.GetOrdinal("member_phone")) ? "" : reader.GetString("member_phone");

                        memberManager = new MemberManager(name, address, phone);
                    }
                }
            }

            return memberManager;
        }
        private static string GetConnectionString()
        {
            return "your_database_connection_here";
        }
    }
}
