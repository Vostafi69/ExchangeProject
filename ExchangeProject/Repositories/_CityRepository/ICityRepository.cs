using ExchangeProject.Models.Cities;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._CityRepository
{
    public interface ICityRepository
    {
        void Add(ICity city);
        void Update(ICity city);
        void Delete(int cityId);
        IEnumerable<ICity> GetAll();
        IEnumerable<ICity> GetByValue(string value);
    }
}
