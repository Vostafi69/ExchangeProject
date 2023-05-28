using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Job
{
    public class Job : IJob
    {
        public int JobId { get; set; }
        [Required(ErrorMessage = "Работодатель является обязательным полем")]
        public int JobGiverId { get; set; }
        [Required(ErrorMessage = "Название работы является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название работы должно быть не менее 3 и не более 50 символов")]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Зарплата является обязательным полем")]
        public decimal Money { get; set; }
        public string More { get; set; }
        [Required(ErrorMessage = "Зарплата является обязательным полем")]
        public bool Available { get; set; }
        [Required(ErrorMessage = "Зарплата является обязательным полем")]
        public string JobType { get; set; }
    }
}
