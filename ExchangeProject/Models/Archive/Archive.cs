using System;
using System.ComponentModel.DataAnnotations;

namespace ExchangeProject.Models.Archive
{
    class Archive : IArchive
    {
        public int ArchiveId { get; set; }
        [Required(ErrorMessage = "Архивист является обязательным полем")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Поле Архивист должно быть не менее 3 и не более 50 символов")]
        public string Archivist { get; set; }
        [Required(ErrorMessage = "Дата архивации является обязательным полем")]
        public DateTime ArchiveDate { get; set; }
        [Required(ErrorMessage = "ID вакансии является обязательным полем")]
        public int JobId { get; set; }
        [Required(ErrorMessage = "ID соискателя является обязательным полем")]
        public int MemberId { get; set; }
    }
}
