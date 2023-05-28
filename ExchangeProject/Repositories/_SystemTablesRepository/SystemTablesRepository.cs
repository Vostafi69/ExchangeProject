using ExchangeProject.Models.SysTables;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._SystemTablesRepository
{
    public class SystemTablesRepository : BaseRepository, ISystemTablesRepository
    {
        private readonly string GetAppPgAMQuery = "SELECT oid, amname, amtype FROM  pg_am;";
        private readonly string GetAppPgCastQuery = "SELECT * FROM pg_cast";
        private readonly string GetAppPgSHQuery = "SELECT * FROM pg_shdepend";

        public SystemTablesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<IPg_Am> GetAllPgAm()
        {
            var dataList = new List<IPg_Am>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAppPgAMQuery;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IPg_Am data = new Pg_Am();
                            data.Oid = Convert.ToInt32(reader[0]);
                            data.Amname = reader[1].ToString();
                            data.Amtype = Convert.ToChar(reader[2]);
                            dataList.Add(data);
                        }
                    }
                }
            }
            return dataList;
        }

        public IEnumerable<IPg_Cast> GetAllPgCast()
        {
            var dataList = new List<IPg_Cast>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAppPgCastQuery;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IPg_Cast data = new Pg_Cast();
                            data.Oid = Convert.ToInt32(reader[0]);
                            data.CastSource = Convert.ToInt32(reader[1]);
                            data.CastTarget = Convert.ToInt32(reader[2]);
                            data.CastFunc = Convert.ToInt32(reader[3]);
                            data.CastContext = Convert.ToChar(reader[4]);
                            data.CastMethod = Convert.ToChar(reader[5]);
                            dataList.Add(data);
                        }
                    }
                }
            }
            return dataList;
        }

        public IEnumerable<IPg_Shdepend> GetAllPgShdepend()
        {
            var dataList = new List<IPg_Shdepend>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetAppPgSHQuery;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IPg_Shdepend data = new Pg_Shdepend();
                            data.Dbid = Convert.ToInt32(reader[0]);
                            data.Classid = Convert.ToInt32(reader[1]);
                            data.Objid = Convert.ToInt32(reader[2]);
                            data.Objsubid = Convert.ToInt32(reader[3]);
                            data.Refclassid = Convert.ToInt32(reader[4]);
                            data.Refobjid = Convert.ToInt32(reader[5]);
                            data.Deptype = Convert.ToChar(reader[6]);
                            dataList.Add(data);
                        }
                    }
                }
            }
            return dataList;
        }
    }
}
