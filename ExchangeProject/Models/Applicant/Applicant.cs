using System;
using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Applicant
{
    public class Applicant : IApplicant
    {
        public int JoblessId { get; set; }
        [Required(ErrorMessage = "Имя является обязательным полем")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Имя должно быть не менее 2 и не более 20 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Отчество является обязательным полем")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Отчество должно быть не менее 2 и не более 20 символов")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Фамилия является обязательным полем")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия должно быть не менее 2 и не более 20 символов")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Тип образования является обязательным полем")]
        public int StudyTypeID { get; set; }
        [Required(ErrorMessage = "ID города является обязательным полем")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "ID улицы является обязательным полем")]
        public int DistrictId { get; set; }
        [Required(ErrorMessage = "Место образования является обязательным полем")]
        public int StudyPlace { get; set; }
        [Required(ErrorMessage = "Возраст является обязательным полем")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Серия и номер паспорта является обязательным полем")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Серия и номер паспорта должны быть 10 символов")]
        public string Passport { get; set; }
        [Required(ErrorMessage = "Дата выдачи является обязательным полем")]
        public DateTime PassportDate { get; set; }
        [Required(ErrorMessage = "Кем выдан является обязательным полем")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Кем выдан должен быть не менее 1 и не более 100 символов")]
        public string PassportRegion { get; set; }
        [Required(ErrorMessage = "Телефон является обязательным полем")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Телефон должен быть 11 символов")]
        public string Phone { get; set; }
        public bool Deleted { get; set; }
    }
}
