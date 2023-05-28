using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Employed
{
    public class Employed : IEmployed
    {
        [Required(ErrorMessage = "ID вакансии является обязательным полем")]
        public int JobId { get; set; }
        [Required(ErrorMessage = "ID соискателя является обязательным полем")]
        public int MemberId { get; set; }
    }
}
