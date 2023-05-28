using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.SysTables
{
    public interface IPg_Shdepend
    {
        int Dbid { get; set; }
        int Classid { get; set; }
        int Objid { get; set; }
        int Objsubid { get; set; }
        int Refclassid { get; set; }
        int Refobjid { get; set; }
        char Deptype { get; set; }
    }
}
