using System.ComponentModel;

namespace ExchangeProject.Models.Districts
{
    public interface IDistrict
    {
        [DisplayName("ID улицы")]
        int DistrictId { get; set; }
        [DisplayName("Название улицы")]
        string DistrictName { get; set; }
    }
}
