using System;
using System.ComponentModel;

namespace ExchangeProject.Models.Registration
{
    public interface IRegistration
    {
        [DisplayName("ID")]
        int Memberid { get; set; }
        [DisplayName("ID заявления")]
        int Joblessid { get; set; }
        [DisplayName("Регистрар")]
        string Registrar { get; set; }
        [DisplayName("Дата регистрации")]
        DateTime Regdate { get; set; }
        [DisplayName("Жедаемая зарплата")]
        decimal Payment { get; set; }
        [DisplayName("Опыт")]
        bool Experience { get; set; }
        [DisplayName("Коммент")]
        string Comment { get; set; }
    }
}
