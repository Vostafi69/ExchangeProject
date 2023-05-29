using ExchangeProject.Models.JobGivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Repositories._JobGiversRepository
{
    public interface IJobGiversRepository
    {
        void Add(IJobGivers jobgiver);
        void Update(IJobGivers jobgiver);
        void Delete(int jobgiverid);
        IEnumerable<IJobGivers> GetAll();
        IEnumerable<IJobGivers> GetByValue(string value);
    }
}
