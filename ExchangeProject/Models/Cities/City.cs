using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Cities
{
    public class City : ICity
    {
        public int CityId { get; set; }
        [Required(ErrorMessage = "Название города является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название города должно быть не менее 3 и не более 50 символов")]
        public string CityName { get; set; }
    }
}
