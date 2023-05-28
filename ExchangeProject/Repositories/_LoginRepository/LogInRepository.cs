using ExchangeProject.Models.UserDTO;
using Npgsql;
using NpgsqlTypes;

namespace ExchangeProject.Repositories._LogInRepository
{
    public class LogInRepository : BaseRepository, ILogInRepository
    {
        private readonly string GetRoleQuery = "SELECT usename, groname FROM pg_user AS PG_U " +
                            "LEFT JOIN pg_group AS PG_G ON " +
                            "PG_U.usesysid = ANY(PG_G.grolist) " +
                            "WHERE PG_U.usename = @username";
        public LogInRepository()
        {

        }

        public IUser GetRole(string login, string passwd)
        {
            connectionString = $"Host=localhost;Username={login};Password={passwd};Database=birzhadb";
            IUser user = new User();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                using (var command = new NpgsqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = GetRoleQuery;
                    command.Parameters.Add("@username", NpgsqlDbType.Varchar).Value = login;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserName = reader[0].ToString();
                            user.UserRole = reader[1].ToString();
                            user.NpgsqlConnectionString = connectionString;
                        }
                    }
                }
            }
            return user;
        }
    }
}
