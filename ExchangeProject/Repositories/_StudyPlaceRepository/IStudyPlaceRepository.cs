using ExchangeProject.Models.StudyPlaces;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._StudyPlaceRepository
{
    public interface IStudyPlaceRepository
    {
        void Add(IStudyPlaces studyPlace);
        void Update(IStudyPlaces studyPlace);
        void Delete(int studyPlaceId);
        IEnumerable<IStudyPlaces> GetAll();
        IEnumerable<IStudyPlaces> GetByValue(string value);

    }
}
