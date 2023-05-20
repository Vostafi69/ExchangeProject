using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.Cities
{
    public interface ICityRepository
    {
        void Add(City city);
        void Edit(City city);
        void Delete(int id);
        IEnumerable<City> GetAll();
        IEnumerable<City> GetByValue(string value);
    }
}
