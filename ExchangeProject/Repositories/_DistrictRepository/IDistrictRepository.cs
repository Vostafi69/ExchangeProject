using ExchangeProject.Models.Districts;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._DistrictRepository
{
    public interface IDistrictRepository
    {
        void Add(IDistrict district);
        void Update(IDistrict district);
        void Delete(int districtid);
        IEnumerable<IDistrict> GetAll();
        IEnumerable<IDistrict> GetByValue(string value);
    }
}
