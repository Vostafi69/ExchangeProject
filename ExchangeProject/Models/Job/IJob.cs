using System.ComponentModel;

namespace ExchangeProject.Models.Job
{
    public interface IJob
    {
        [DisplayName("ID работы")]
        int JobId { get; set; }
        [DisplayName("Работодатель")]
        int JobGiverId { get; set; }
        [DisplayName("Название работы")]
        string JobName { get; set; }
        [DisplayName("Зарплата")]
        decimal Money { get; set; }
        [DisplayName("Дополнительно")]
        string More { get; set; }
        [DisplayName("Вакансия открыта")]
        bool Available { get; set; }
        [DisplayName("Тип работы")]
        string JobType { get; set; }
    }
}
