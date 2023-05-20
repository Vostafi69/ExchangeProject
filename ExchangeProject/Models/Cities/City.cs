using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Cities
{
    public class City
    {
        [DisplayName("ID города")]
        public int CityId { get; set; }
        [DisplayName("Название города")]
        [Required(ErrorMessage = "Название города является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название города должно быть не менее 3 и не более 50 символов")]
        public string CityName { get; set; }
    }
}
