using System;
using System.ComponentModel;

namespace ExchangeProject.Models.Applicant
{
    public interface IApplicant
    {
        [DisplayName("ID заявителя")]
        int JoblessId { get; set; }
        [DisplayName("Имя")]
        string Name { get; set; }
        [DisplayName("Отчество")]
        string Lastname { get; set; }
        [DisplayName("Фамилия")]
        string Surname { get; set; }
        [DisplayName("ID образования")]
        int StudyTypeID { get; set; }
        [DisplayName("ID города проживания")]
        int CityId { get; set; }
        [DisplayName("ID улицы проживания")]
        int DistrictId { get; set; }
        [DisplayName("ID места образования")]
        int StudyPlace { get; set; }
        [DisplayName("Возраст")]
        int Age { get; set; }
        [DisplayName("Серия и номер паспорта")]
        string Passport { get; set; }
        [DisplayName("Дата выдачи паспорта")]
        DateTime PassportDate { get; set; }
        [DisplayName("Кем выдан паспорт")]
        string PassportRegion { get; set; }
        [DisplayName("Телефон заявителя")]
        string Phone { get; set; }
        [DisplayName("Маркер удаления")]
        bool Deleted { get; set; }
    }
}
