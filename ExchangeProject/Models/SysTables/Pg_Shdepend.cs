using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.SysTables
{
    class Pg_Shdepend : IPg_Shdepend
    {
        public int Dbid { get; set; }
        public int Classid { get; set; }
        public int Objid { get; set; }
        public int Objsubid { get; set; }
        public int Refclassid { get; set; }
        public int Refobjid { get; set; }
        public char Deptype { get; set; }
    }
}
