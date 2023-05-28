using System;
using System.ComponentModel;

namespace ExchangeProject.Models.Archive
{
    public interface IArchive
    {
        [DisplayName("ID записи")]
        int ArchiveId { get; set; }
        [DisplayName("Архивист")]
        string Archivist { get; set; }
        [DisplayName("Дата архивации")]
        DateTime ArchiveDate { get; set; }
        [DisplayName("ID вакансии")]
        int JobId { get; set; }
        [DisplayName("ID соискателя")]
        int MemberId { get; set; }
    }
}
