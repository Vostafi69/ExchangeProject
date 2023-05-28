using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.StudyPlaces
{
    class StudyPlaces : IStudyPlaces
    {
        public int studyid { get; set; }
        [Required(ErrorMessage = "Название учебного заведения является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название учебного заведения должно быть не менее 3 и не более 50 символов")]
        public string studyplace { get; set; }
        [Required(ErrorMessage = "ID города учебного заведения является обязательным полем")]
        public int cityid { get; set; }
        [Required(ErrorMessage = "ID улицы учебного заведения является обязательным полем")]
        public int districtid { get; set; }
    }
}
