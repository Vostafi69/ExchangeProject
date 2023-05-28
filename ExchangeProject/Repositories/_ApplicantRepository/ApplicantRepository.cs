using ExchangeProject.Models.Applicant;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._ApplicantRepository
{
    public class ApplicantRepository : BaseRepository, IApplicantRepository
    {
        private readonly string GetQuery = "SELECT * FROM applicant ORDER BY joblessid DESC";
        private readonly string InsertQuery = "INSERT INTO applicant (" +
            "name, typeid, cityid, districtid, lastname, surname, studyid, age, passport, passportdate, passportregion, phone, deleted" +
            ") VALUES (" +
            "@name, @typeid, @cityid, @districtid, @lastname, @surname, @studyid, @age, @passport, @passportdate, @passportregion, @phone, @deleted" +
            ")";
        private readonly string GetAllParamQuery = "SELECT * FROM applicant WHERE joblessid = @joblessid OR name LIKE @name OR surname LIKE @surname OR lastname LIKE @lastname";
        private readonly string DeleteQuery = "DELETE FROM applicant WHERE joblessid = @joblessid";
        private readonly string UpdateQuery = "UPDATE applicant SET " +
            "name = @name, typeid = @typeid, cityid = @cityid, districtid = @districtid, lastname = @lastname, surname = @surname, " +
            "studyid = @studyid, age = @age, passport = @passport, passportdate = @passportdate, passportregion = @passportregion, phone = @phone, deleted = @deleted WHERE joblessid = @joblessid";

        public ApplicantRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(IApplicant applicant)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = InsertQuery;
                    command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = applicant.Name;
                    command.Parameters.Add("@typeid", NpgsqlDbType.Integer).Value = applicant.StudyTypeID;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = applicant.CityId;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = applicant.DistrictId;
                    command.Parameters.Add("@lastname", NpgsqlDbType.Varchar).Value = applicant.Lastname;
                    command.Parameters.Add("@surname", NpgsqlDbType.Varchar).Value = applicant.Surname;
                    command.Parameters.Add("@studyid", NpgsqlDbType.Integer).Value = applicant.StudyPlace;
                    command.Parameters.Add("@age", NpgsqlDbType.Integer).Value = applicant.Age;
                    command.Parameters.Add("@passport", NpgsqlDbType.Varchar).Value = applicant.Passport;
                    command.Parameters.Add("@passportdate", NpgsqlDbType.Date).Value = applicant.PassportDate;
                    command.Parameters.Add("@passportregion", NpgsqlDbType.Varchar).Value = applicant.PassportRegion;
                    command.Parameters.Add("@phone", NpgsqlDbType.Varchar).Value = applicant.Phone;
                    command.Parameters.Add("@deleted", NpgsqlDbType.Boolean).Value = applicant.Deleted;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int applicantId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = DeleteQuery;
                    command.Parameters.Add("@joblessid", NpgsqlDbType.Integer).Value = applicantId;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IApplicant> GetAll()
        {
            var applicantsList = new List<IApplicant>();
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
                            IApplicant applicant = new Applicant();
                            applicant.JoblessId = (int)reader[0];
                            applicant.Name = reader[1].ToString();
                            applicant.StudyTypeID = (int)reader[2];
                            applicant.CityId = (int)reader[3];
                            applicant.DistrictId = (int)reader[4];
                            applicant.Lastname = reader[5].ToString();
                            applicant.Surname = reader[6].ToString();
                            applicant.StudyPlace = (int)reader[7];
                            applicant.Age = (int)reader[8];
                            applicant.Passport = reader[9].ToString();
                            applicant.PassportDate = Convert.ToDateTime(reader[10]);
                            applicant.PassportRegion = reader[11].ToString();
                            applicant.Phone = reader[12].ToString();
                            applicant.Deleted = Convert.ToBoolean(reader[13]);
                            applicantsList.Add(applicant);
                        }
                    }
                }
            }
            return applicantsList;
        }

        public IEnumerable<IApplicant> GetByValue(string value)
        {
            var applicantlist = new List<IApplicant>();
            int applicantid = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string applicantname = value;
            string applicantsurname = value;
            string applicantlastname = value;
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAllParamQuery;
                    command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = applicantname + "%";
                    command.Parameters.Add("@lastname", NpgsqlDbType.Varchar).Value = applicantlastname + "%";
                    command.Parameters.Add("@joblessid", NpgsqlDbType.Integer).Value = applicantid;
                    command.Parameters.Add("@surname", NpgsqlDbType.Varchar).Value = applicantsurname + "%";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IApplicant applicant = new Applicant();
                            applicant.JoblessId = (int)reader[0];
                            applicant.Name = reader[1].ToString();
                            applicant.StudyTypeID = (int)reader[2];
                            applicant.CityId = (int)reader[3];
                            applicant.DistrictId = (int)reader[4];
                            applicant.Lastname = reader[5].ToString();
                            applicant.Surname = reader[6].ToString();
                            applicant.StudyPlace = (int)reader[7];
                            applicant.Age = (int)reader[8];
                            applicant.Passport = reader[9].ToString();
                            applicant.PassportDate = Convert.ToDateTime(reader[10]);
                            applicant.PassportRegion = reader[11].ToString();
                            applicant.Phone = reader[12].ToString();
                            applicant.Deleted = Convert.ToBoolean(reader[13]);
                            applicantlist.Add(applicant);
                        }
                    }
                }
            }
            return applicantlist;
        }

        public void Update(IApplicant applicant)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = UpdateQuery;
                    command.Parameters.Add("@joblessid", NpgsqlDbType.Integer).Value = applicant.JoblessId;
                    command.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = applicant.Name;
                    command.Parameters.Add("@typeid", NpgsqlDbType.Integer).Value = applicant.StudyTypeID;
                    command.Parameters.Add("@cityid", NpgsqlDbType.Integer).Value = applicant.CityId;
                    command.Parameters.Add("@districtid", NpgsqlDbType.Integer).Value = applicant.DistrictId;
                    command.Parameters.Add("@lastname", NpgsqlDbType.Varchar).Value = applicant.Lastname;
                    command.Parameters.Add("@surname", NpgsqlDbType.Varchar).Value = applicant.Surname;
                    command.Parameters.Add("@studyid", NpgsqlDbType.Integer).Value = applicant.StudyPlace;
                    command.Parameters.Add("@age", NpgsqlDbType.Integer).Value = applicant.Age;
                    command.Parameters.Add("@passport", NpgsqlDbType.Varchar).Value = applicant.Passport;
                    command.Parameters.Add("@passportdate", NpgsqlDbType.Date).Value = applicant.PassportDate;
                    command.Parameters.Add("@passportregion", NpgsqlDbType.Varchar).Value = applicant.PassportRegion;
                    command.Parameters.Add("@phone", NpgsqlDbType.Varchar).Value = applicant.Phone;
                    command.Parameters.Add("@deleted", NpgsqlDbType.Boolean).Value = applicant.Deleted;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
