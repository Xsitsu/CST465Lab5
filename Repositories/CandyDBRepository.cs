using CST465Lab5.Models;
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
    public class CandyDBRepository : ICandyRepository
    {
        protected string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<Startup>();
            var configuration = builder.Build();
            string connectionstring = configuration.GetConnectionString("DB_Halloween");
            return connectionstring;
        }
        public List<CandyModel> GetList()
        {
            List<CandyModel> candy = new List<CandyModel>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_GetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            string productName = reader["ProductName"].ToString();
                            candy.Add(new CandyModel() { Id = id, ProductName = productName });
                        }
                    }
                }
            }
            return candy;
        }
        public List<string> GetListString()
        {
            List<CandyModel> candy = GetList();
            List<string> candyString = new List<string>();
            foreach (var c in candy)
            {
                candyString.Add(c.ProductName);
            }
            return candyString;
        }
        public void Insert(string candy)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@ProductName", candy);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_Delete", connection))
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
