using System.ComponentModel;

namespace ExchangeProject.Models.StudyPlaces
{
    public interface IStudyPlaces
    {
        [DisplayName("ID учебного заведения")]
        int studyid { get; set; }
        [DisplayName("Название")]
        string studyplace { get; set; }
        [DisplayName("ID города")]
        int cityid { get; set; }
        [DisplayName("ID улицы")]
        int districtid { get; set; }
    }
}
