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
    public class CostumeDBRepository : ICostumeRepository
    {
        protected string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<Startup>();
            var configuration = builder.Build();
            string connectionstring = configuration.GetConnectionString("DB_Halloween");
            return connectionstring;
        }
        public List<CostumeModel> GetList()
        {
            List<CostumeModel> costume = new List<CostumeModel>();
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
                            int id = (int)reader["Id"];
                            string name = reader["Costume"].ToString();
                            costume.Add(new CostumeModel() {Id = id, Name = name });
                        }
                    }
                }
            }
            return costume;
        }
        public List<string> GetListString()
        {
            List<CostumeModel> costume = GetList();
            List<string> costumeString = new List<string>();
            foreach (var c in costume)
            {
                costumeString.Add(c.Name);
            }
            return costumeString;
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
