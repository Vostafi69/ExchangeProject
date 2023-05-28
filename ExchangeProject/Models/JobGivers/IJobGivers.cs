using System.ComponentModel;

namespace ExchangeProject.Models.JobGivers
{
    public interface IJobGivers
    {
        [DisplayName("ID работодателя")]
        int JobGiverId { get; set; }
        [DisplayName("Работодатель")]
        string JobGiver { get; set; }
        [DisplayName("Город")]
        int CityId { get; set; }
        [DisplayName("Улица")]
        int DistrictId { get; set; }
        [DisplayName("Телефон")]
        string Mobile { get; set; }
    }
}
