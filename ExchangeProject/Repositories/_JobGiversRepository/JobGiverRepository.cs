using ExchangeProject.Models.JobGivers;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._JobGiversRepository
{
    public class JobGiverRepository : BaseRepository, IJobGiversRepository
    {
        private readonly string GetAllQuery = @"SELECT * FROM districs WHERE district LIKE @district OR districtid = @districtid ORDER BY districtid DESC";
        private readonly string GetQuery = "SELECT * FROM jobgivers ORDER BY districtid DESC";
        private readonly string InsertQuery = "INSERT INTO districs (district) VALUES (@district)";
        private readonly string DeleteQuery = "DELETE FROM districs WHERE districtid = @districtid";
        private readonly string UpdateQuery = "UPDATE districs SET district = @district WHERE districtid = @districtid";

        public JobGiverRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IJobGivers jobgiver)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = InsertQuery;
                    
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
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IJobGivers> GetByValue(string value)
        {
            var districtList = new List<IJobGivers>();
            int districtid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string districtname = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAllQuery;
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                        }
                    }
                }
            }
            return districtList;
        }

        public void Update(IJobGivers jobgiver)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = UpdateQuery;
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IJobGivers> GetAll()
        {
            var jobgiverslist = new List<IJobGivers>();
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
                            IJobGivers jobgiver = new JobGivers();
                            jobgiver.JobGiverId = (int)reader[0];
                            jobgiver.JobGiver = reader[1].ToString();
                            jobgiver.CityId = (int)reader[2];
                            jobgiver.DistrictId = (int)reader[3];
                            jobgiver.Mobile = reader[4].ToString();
                            jobgiverslist.Add(jobgiver);
                        }
                    }
                }
            }
            return jobgiverslist;
        }
    }
}
