using CST465Lab5.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CST465Lab5.Repositories
{
    public class TreaterDBRepository : ITreaterRepository
    {
        protected string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<Startup>();
            var configuration = builder.Build();
            string connectionstring = configuration.GetConnectionString("DB_Halloween");
            return connectionstring;
        }

        public List<TrickOrTreaterModel> GetList()
        {
            List<TrickOrTreaterModel> treaters = new List<TrickOrTreaterModel>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Treaters_GetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string candy = reader["Candy"].ToString();
                            string costume = reader["Costume"].ToString();

                            treaters.Add(new TrickOrTreaterModel() { Name = name, FavoriteCandy = candy, Costume = costume });
                        }
                    }
                }
            }
            return treaters;
        }

        public void Insert(TrickOrTreaterModel treater)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Treaters_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Name", treater.Name);
                    command.Parameters.AddWithValue("@FavoriteCandy", treater.FavoriteCandy);
                    command.Parameters.AddWithValue("@Costume", treater.Costume);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
