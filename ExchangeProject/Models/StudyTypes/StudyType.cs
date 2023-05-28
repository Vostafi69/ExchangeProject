using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.StudyTypes
{
    public class StudyType : IStudyType
    {
        public int StudyTypeId { get; set; }
        [Required(ErrorMessage = "Название типа образования является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название типа образования должно быть не менее 3 и не более 50 символов")]
        public string StudyTypeName { get; set; }
    }
}
