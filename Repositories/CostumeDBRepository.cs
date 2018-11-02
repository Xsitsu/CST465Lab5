using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Repositories
{
    public class CostumeDBRepository : ICostumeRepository
    {
        protected string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            string connectionstring = configuration.GetConnectionString("DB_Halloween");
            return connectionstring;
        }
        public List<string> GetList()
        {
            List<string> candy = new List<string>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_GetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            candy.Add(reader["Costume"].ToString());
                        }
                    }
                }
            }
            return candy;
        }
        public void Insert(string costume)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Costume", costume);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
