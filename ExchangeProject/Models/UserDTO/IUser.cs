namespace ExchangeProject.Models.UserDTO
{
    interface IUser
    {
        string UserName { get; set; }
        string UserRole { get; set; }
        string NpgsqlConnectionString { get; set; }
    }
}
