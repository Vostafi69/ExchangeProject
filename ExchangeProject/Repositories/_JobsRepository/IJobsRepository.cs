using ExchangeProject.Models.Job;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._JobsRepository
{
    public interface IJobsRepository
    {
        void Add(IJob job);
        void Update(IJob job);
        void Delete(int jobid);
        IEnumerable<IJob> GetAll();
        IEnumerable<IJob> GetByValue(string value);
    }
}
