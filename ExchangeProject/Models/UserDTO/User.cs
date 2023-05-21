using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.UserDTO
{
    class User : IUser
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string NpgsqlConnectionString { get; set; }
    }
}
