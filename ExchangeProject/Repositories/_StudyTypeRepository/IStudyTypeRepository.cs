using ExchangeProject.Models.StudyTypes;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._StudyTypeRepository
{
    public interface IStudyTypeRepository
    {
        void Add(IStudyType type);
        void Update(IStudyType type);
        void Delete(int typeId);
        IEnumerable<IStudyType> GetAll();
        IEnumerable<IStudyType> GetByValue(string value);
    }
}
