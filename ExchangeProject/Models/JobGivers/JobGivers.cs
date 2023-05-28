using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.JobGivers
{
    public class JobGivers : IJobGivers
    {
        public int JobGiverId { get; set; }
        [Required(ErrorMessage = "Работодатель является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Работодатель должен быть не менее 3 и не более 50 символов")]
        public string JobGiver { get; set; }
        [Required(ErrorMessage = "Город является обязательным полем")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Улица является обязательным полем")]
        public int DistrictId { get; set; }
        [Required(ErrorMessage = "Телефон является обязательным полем")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Телефон должен включать 11 цифр")]
        public string Mobile { get; set; }
    }
}
