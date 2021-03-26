using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_BTS.Models
{
    public class ShoppingContext
    {
        public string ConnectionString { get; set; }
        public ShoppingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<ShoppingModels> GetAllShopping()
        {
            List<ShoppingModels> list = new List<ShoppingModels>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM shopping", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ShoppingModels()
                        {
                            id = reader.GetInt32("id"),
                            Name = reader.GetString("Name"),
                            CreatedDate = reader.GetDateTime("CreatedDate")
                        });
                    }
                }
            }
            return list;
        }

        public List<ShoppingModels> GetShopping(string id)
        {
            List<ShoppingModels> list = new List<ShoppingModels>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM siswa WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ShoppingModels()
                        {
                            id = reader.GetInt32("id"),
                            Name = reader.GetString("Name"),
                            CreatedDate = reader.GetDateTime("CreatedDate")
                        });
                    }
                }
            }
            return list;
        }
    }
}
