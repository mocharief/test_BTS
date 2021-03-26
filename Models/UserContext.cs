using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_BTS.Models
{
    public class UserContext
    {
        public string ConnectionString { get; set; }
        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<UserModels> GetAllUser()
        {
            List<UserModels> list = new List<UserModels>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserModels()
                        {
                            id = reader.GetInt32("id"),
                            username = reader.GetString("username"),
                            password = reader.GetString("password"),
                            email = reader.GetString("email"),
                            phone = reader.GetString("phone"),
                            country = reader.GetString("country"),
                            city = reader.GetString("city"),
                            postcode = reader.GetString("postcode"),
                            name = reader.GetString("name"),
                            address = reader.GetString("address")
                        });
                    }
                }
            }
            return list;
        }

        public List<UserModels> GetUser(string id)
        {
            List<UserModels> list = new List<UserModels>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM siswa WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserModels()
                        {
                            id = reader.GetInt32("id"),
                            username = reader.GetString("username"),
                            password = reader.GetString("password"),
                            email = reader.GetString("email"),
                            phone = reader.GetString("phone"),
                            country = reader.GetString("country"),
                            city = reader.GetString("city"),
                            postcode = reader.GetString("postcode"),
                            name = reader.GetString("name"),
                            address = reader.GetString("address")
                        });
                    }
                }
            }
            return list;
        }
    }
}
