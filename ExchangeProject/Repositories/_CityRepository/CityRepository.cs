using ExchangeProject.Models.Cities;
using ExchangeProject.Repositories._CityRepository;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._CityRepository
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        private readonly string GetQuery = "SELECT * FROM city ORDER BY cityid DESC";
        private readonly string GetAllQuery = @"SELECT * FROM city WHERE cityname LIKE @cityname OR cityid = @cityid ORDER BY cityid DESC";
        private readonly string InsertQuery = "INSERT INTO city (cityname) VALUES (@cityname)";
        private readonly string UpdateQuery = "UPDATE city SET cityname = @cityname WHERE cityid = @cityid";
        private readonly string DeleteQuery = "DELETE FROM city WHERE cityid = @cityid";

        public CityRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(ICity city)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = InsertQuery;
                    command.Parameters.Add("@cityname", NpgsqlDbType.Varchar).Value = city.CityName;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int cityId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = DeleteQuery;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = cityId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(ICity city)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = UpdateQuery;
                    command.Parameters.Add("@cityname", NpgsqlDbType.Varchar).Value = city.CityName;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = city.CityId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ICity> GetAll()
        {
            var cityList = new List<ICity>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetQuery;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ICity city = new City();
                            city.CityId = (int)reader[0];
                            city.CityName = reader[1].ToString();
                            cityList.Add(city);
                        }
                    }
                }
            }
            return cityList;
        }

        public IEnumerable<ICity> GetByValue(string value)
        {
            var cityList = new List<ICity>();
            int cityid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string cityname = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAllQuery;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = cityid;
                    command.Parameters.Add("@cityname", NpgsqlDbType.Varchar).Value = cityname + "%";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ICity city = new City();
                            city.CityId = (int)reader[0];
                            city.CityName = reader[1].ToString();
                            cityList.Add(city);
                        }
                    }
                }
            }
            return cityList;
        }
    }
}
