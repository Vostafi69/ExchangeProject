using ExchangeProject.Models.StudyPlaces;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._StudyPlaceRepository
{
    public class StudyPlaceRepository : BaseRepository, IStudyPlaceRepository
    {
        private readonly string GetQuery = "SELECT * FROM study ORDER BY studyid DESC";
        private readonly string GetAllParamQuery = "SELECT * FROM study WHERE studyid = @studyid OR studyplace LIKE @studyplace ORDER BY studyid DESC";
        private readonly string DeleteQuery = "DELETE FROM study WHERE studyid = @studyid";
        private readonly string UpdateQuery = "UPDATE study SET studyplace = @studyplace, cityid = @cityid, districtid = @districtid WHERE studyid = @studyid";
        private readonly string InsertQuery = "INSERT INTO study (studyplace, cityid, districtid) VALUES (@studyplace, @cityid, @districtid)";

        public StudyPlaceRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IStudyPlaces studyPlace)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = InsertQuery;
                    command.Parameters.Add("@studyplace", NpgsqlDbType.Varchar).Value = studyPlace.studyplace;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = studyPlace.cityid;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = studyPlace.districtid;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int studyPlaceId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = DeleteQuery;
                    command.Parameters.Add("@studyid", NpgsqlDbType.Integer).Value = studyPlaceId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IStudyPlaces> GetAll()
        {
            var studyPlaceList = new List<IStudyPlaces>();
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
                            IStudyPlaces studyPlace = new StudyPlaces();
                            studyPlace.studyid = (int)reader[0];
                            studyPlace.studyplace = reader[1].ToString();
                            studyPlace.cityid = (int)reader[2];
                            studyPlace.districtid = (int)reader[3];
                            studyPlaceList.Add(studyPlace);
                        }
                    }
                }
            }
            return studyPlaceList;
        }

        public IEnumerable<IStudyPlaces> GetByValue(string value)
        {
            var placesList = new List<IStudyPlaces>();
            int studyplaceid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string studyplacename = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAllParamQuery;
                    command.Parameters.Add("@studyid", NpgsqlDbType.Integer).Value = studyplaceid;
                    command.Parameters.Add("@studyplace", NpgsqlDbType.Varchar).Value = studyplacename + "%";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IStudyPlaces studyPlace = new StudyPlaces();
                            studyPlace.studyid = (int)reader[0];
                            studyPlace.studyplace = reader[1].ToString();
                            studyPlace.cityid = (int)reader[2];
                            studyPlace.districtid = (int)reader[3];
                            placesList.Add(studyPlace);
                        }
                    }
                }
            }
            return placesList;
        }

        public void Update(IStudyPlaces studyPlace)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = UpdateQuery;
                    command.Parameters.Add("@studyid", NpgsqlDbType.Integer).Value = studyPlace.studyid;
                    command.Parameters.Add("@studyplace", NpgsqlDbType.Varchar).Value = studyPlace.studyplace;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = studyPlace.cityid;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = studyPlace.districtid;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
