using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Districts
{
    class District : IDistrict
    {
        public int DistrictId { get; set; }
        [Required(ErrorMessage = "Название улицы является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название улицы должно быть не менее 3 и не более 50 символов")]
        public string DistrictName { get; set; }
    }
}
