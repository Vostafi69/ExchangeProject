using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.Registration
{
    public class Registration : IRegistration
    {
        public int Memberid { get; set; }
        [Required(ErrorMessage = "ID заявления является обязательным полем")]
        public int Joblessid { get; set; }
        [Required(ErrorMessage = "Регистрар является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "поле Регистрар должно быть не менее 3 и не более 50 символов")]
        public string Registrar { get; set; }
        [Required(ErrorMessage = "Дата регистрации является обязательным полем")]
        public DateTime Regdate { get; set; }
        [Required(ErrorMessage = "Желаемая зарплата является обязательным полем")]
        public decimal Payment { get; set; }
        [Required(ErrorMessage = "Опыт является обязательным полем")]
        public bool Experience { get; set; }
        public string Comment { get; set; }
    }
}
