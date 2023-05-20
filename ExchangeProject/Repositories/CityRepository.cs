using ExchangeProject.Models.Cities;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeProject.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(City city)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(City city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAll()
        {
            var cityList = new List<City>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM city order by cityid desc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var city = new City();
                            city.CityId = (int)reader[0];
                            city.CityName = reader[1].ToString();
                            cityList.Add(city);
                        }
                    }
                }
            }
            return cityList;
        }

        public IEnumerable<City> GetByValue(string value)
        {
            var cityList = new List<City>();
            int cityid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string cityname = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM city WHERE cityname LIKE @cityname OR cityid = @cityid ORDER BY cityid DESC";
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = cityid;
                    command.Parameters.AddWithValue("@cityname", NpgsqlDbType.Varchar).Value = cityname + "%";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var city = new City();
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
