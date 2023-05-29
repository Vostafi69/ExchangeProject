using ExchangeProject.Models.Job;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._JobsRepository
{
    class JobsRepository : BaseRepository, IJobsRepository
    {
        private readonly string GetAllQuery = @"SELECT * FROM districs WHERE district LIKE @district OR districtid = @districtid ORDER BY districtid DESC";
        private readonly string GetQuery = "SELECT * FROM job ORDER BY jobid DESC";
        private readonly string InsertQuery = "INSERT INTO districs (district) VALUES (@district)";
        private readonly string DeleteQuery = "DELETE FROM districs WHERE districtid = @districtid";
        private readonly string UpdateQuery = "UPDATE districs SET district = @district WHERE districtid = @districtid";

        public JobsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IJob job)
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

        public IEnumerable<IJob> GetByValue(string value)
        {
            var districtList = new List<IJob>();
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

        public void Update(IJob job)
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

        public IEnumerable<IJob> GetAll()
        {
            var jobsList = new List<IJob>();
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
                            IJob job = new Job();
                            job.JobId = (int)reader[0];
                            job.JobGiverId = (int)reader[1];
                            job.JobName = reader[2].ToString();
                            job.Money = (decimal)reader[3];
                            job.More = reader[4].ToString();
                            job.Available = (bool)reader[5];
                            job.JobType = reader[6].ToString();
                            jobsList.Add(job);
                        }
                    }
                }
            }
            return jobsList;
        }
    }
}
