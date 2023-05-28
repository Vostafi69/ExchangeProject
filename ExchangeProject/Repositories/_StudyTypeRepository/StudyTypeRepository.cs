using ExchangeProject.Models.StudyTypes;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._StudyTypeRepository
{
    public class StudyTypeRepository : BaseRepository, IStudyTypeRepository
    {
        private readonly string GetQuery = "SELECT * FROM studytype ORDER BY typeid DESC";
        private readonly string UpdateQuery = "UPDATE studytype SET typename = @typename WHERE typeid = @typeid";
        private readonly string GetQueryByValue = "SELECT * FROM studytype WHERE typeid = @typeid OR typename LIKE @typename ORDER BY typeid DESC";
        private readonly string DeleteQuery = "DELETE FROM studytype WHERE typeid = @typeid";
        private readonly string InsertQuery = "INSERT INTO studytype (typename) VALUES (@typename)";

        public StudyTypeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IStudyType type)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = InsertQuery;
                    command.Parameters.Add("@typename", NpgsqlDbType.Varchar).Value = type.StudyTypeName;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int typeId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = DeleteQuery;
                    command.Parameters.Add("@typeid", NpgsqlDbType.Integer).Value = typeId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IStudyType> GetAll()
        {
            var studyTypesList = new List<IStudyType>();
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
                            IStudyType studyType = new StudyType();
                            studyType.StudyTypeId = (int)reader[0];
                            studyType.StudyTypeName = reader[1].ToString();
                            studyTypesList.Add(studyType);
                        }
                    }
                }
            }
            return studyTypesList;
        }

        public IEnumerable<IStudyType> GetByValue(string value)
        {
            var typeList = new List<IStudyType>();
            int typeid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string typename = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetQueryByValue;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = typeid;
                    command.Parameters.Add("@cityname", NpgsqlDbType.Varchar).Value = typename + "%";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IStudyType type = new StudyType();
                            type.StudyTypeId = (int)reader[0];
                            type.StudyTypeName = reader[1].ToString();
                            typeList.Add(type);
                        }
                    }
                }
            }
            return typeList;
        }

        public void Update(IStudyType type)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = UpdateQuery;
                    command.Parameters.Add("@typename", NpgsqlDbType.Varchar).Value = type.StudyTypeName;
                    command.Parameters.Add("@typeid", NpgsqlDbType.Integer).Value = type.StudyTypeId;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
