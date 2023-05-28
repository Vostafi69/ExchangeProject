using System.ComponentModel;

namespace ExchangeProject.Models.Employed
{
    public interface IEmployed
    {
        [DisplayName("ID вакансии")]
        int JobId { get; set; }
        [DisplayName("ID соискателя")]
        int MemberId { get; set; }
    }
}
