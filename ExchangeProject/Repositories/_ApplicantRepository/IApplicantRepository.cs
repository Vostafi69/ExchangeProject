using ExchangeProject.Models.Applicant;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._ApplicantRepository
{
    public interface IApplicantRepository
    {
        void Add(IApplicant applicant);
        void Update(IApplicant applicant);
        void Delete(int applicantId);
        IEnumerable<IApplicant> GetAll();
        IEnumerable<IApplicant> GetByValue(string value);
    }
}
