using ExchangeProject.Models.Districts;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._DistrictRepository
{
    class DistrictRepository : BaseRepository, IDistrictRepository
    {
        private readonly string GetAllQuery = @"SELECT * FROM districs WHERE district LIKE @district OR districtid = @districtid ORDER BY districtid DESC";
        private readonly string GetQuery = "SELECT * FROM districs ORDER BY districtid DESC";
        private readonly string InsertQuery = "INSERT INTO districs (district) VALUES (@district)";
        private readonly string DeleteQuery = "DELETE FROM districs WHERE districtid = @districtid";
        private readonly string UpdateQuery = "UPDATE districs SET district = @district WHERE districtid = @districtid";

        public DistrictRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IDistrict district)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = InsertQuery;
                    command.Parameters.Add("@district", NpgsqlDbType.Varchar).Value = district.DistrictName;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int districtid)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = DeleteQuery;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = districtid;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IDistrict> GetByValue(string value)
        {
            var districtList = new List<IDistrict>();
            int districtid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string districtname = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAllQuery;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = districtid;
                    command.Parameters.AddWithValue("@district", NpgsqlDbType.Varchar).Value = districtname + "%";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDistrict district = new District();
                            district.DistrictId = (int)reader[0];
                            district.DistrictName = reader[1].ToString();
                            districtList.Add(district);
                        }
                    }
                }
            }
            return districtList;
        }

        public void Update(IDistrict district)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = UpdateQuery;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = district.DistrictId;
                    command.Parameters.Add("@district", NpgsqlDbType.Varchar).Value = district.DistrictName;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IDistrict> GetAll()
        {
            var districtList = new List<IDistrict>();
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
                            IDistrict district = new District();
                            district.DistrictId = (int)reader[0];
                            district.DistrictName = reader[1].ToString();
                            districtList.Add(district);
                        }
                    }
                }
            }
            return districtList;
        }
    }
}
