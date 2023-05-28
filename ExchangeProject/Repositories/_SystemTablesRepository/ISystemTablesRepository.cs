using ExchangeProject.Models.SysTables;
using System.Collections.Generic;

namespace ExchangeProject.Repositories._SystemTablesRepository
{
    public interface ISystemTablesRepository
    {
        IEnumerable<IPg_Am> GetAllPgAm();
        IEnumerable<IPg_Cast> GetAllPgCast();
        IEnumerable<IPg_Shdepend> GetAllPgShdepend();
    }
}
