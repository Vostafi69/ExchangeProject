using ExchangeProject.Models.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Repositories._LogInRepository
{
    public interface ILogInRepository
    {
        IUser GetRole(string login, string passwd);
    }
}
