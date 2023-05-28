using System.ComponentModel;

namespace ExchangeProject.Models.StudyTypes
{
    public interface IStudyType
    {
        [DisplayName("ID образования")]
        int StudyTypeId { get; set; }
        [DisplayName("Название")]
        string StudyTypeName { get; set; }
    }
}
