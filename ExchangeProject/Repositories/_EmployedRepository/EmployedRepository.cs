using ExchangeProject.Models.Employed;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._EmployedRepository
{
    public class EmployedRepository : BaseRepository, IEmployedRepository
    {
        private readonly string GetAllQuery = @"SELECT * FROM jobless_jobs WHERE district LIKE @district OR districtid = @districtid ORDER BY districtid DESC";
        private readonly string GetQuery = "SELECT * FROM jobless_jobs";
        private readonly string InsertQuery = "INSERT INTO districs (district) VALUES (@district)";
        private readonly string DeleteQuery = "DELETE FROM districs WHERE districtid = @districtid";
        private readonly string UpdateQuery = "UPDATE districs SET district = @district WHERE districtid = @districtid";

        public EmployedRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IEmployed employed)
        {
            throw new NotImplementedException();
        }

        public void Delete(int employedid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmployed> GetAll()
        {
            var employedList = new List<IEmployed>();
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
                            IEmployed employed = new Employed();
                            employed.JobId = (int)reader[0];
                            employed.MemberId = (int)reader[1];
                            employedList.Add(employed);
                        }
                    }
                }
            }
            return employedList;
        }

        public IEnumerable<IEmployed> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(IEmployed employed)
        {
            throw new NotImplementedException();
        }
    }
}
