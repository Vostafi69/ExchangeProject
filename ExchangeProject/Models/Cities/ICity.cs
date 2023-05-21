using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Cities
{
    public interface ICity
    {
        [DisplayName("ID города")]
        int CityId { get; set; }
        [DisplayName("Название города")]
        string CityName { get; set; }
    }
}
