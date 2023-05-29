using ExchangeProject.Models.Employed;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._EmployedRepository
{
    public interface IEmployedRepository
    {
        void Add(IEmployed employed);
        void Update(IEmployed employed);
        void Delete(int employedid);
        IEnumerable<IEmployed> GetAll();
        IEnumerable<IEmployed> GetByValue(string value);
    }
}
