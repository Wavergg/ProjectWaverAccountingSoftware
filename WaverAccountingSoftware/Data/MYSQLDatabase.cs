using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaverAccountingSoftware.Models;
using MySql.Data.MySqlClient;

namespace WaverAccountingSoftware.Data
{
    class MYSQLDatabase
    {
        
        public static User GetUser(string username, string password)
        {
            string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            User user = null;

            using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                string sqlCommand = "SELECT userID, userName, userPassword, userType FROM accountinguser WHERE userName=@USERNAME AND userPassword=@USERPASSWORD";
                using(MySqlCommand command =new MySqlCommand(sqlCommand, conn))
                {
                    command.Parameters.AddWithValue("USERNAME", username);
                    command.Parameters.AddWithValue("USERPASSWORD", password);

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;

                        while (reader.Read())
                        {
                            int userID = reader.GetInt32(0);
                            string userName = reader.GetString(1);
                            string userPassword = reader.GetString(2);
                            string userType = reader.GetString(3);
                            user = new User(userID, userName, userPassword, userType);
                        }
                    }
                }

                conn.Close();
            }

            return user;
        }
    }
}
