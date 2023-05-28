using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.SysTables
{
    public class Pg_Am : IPg_Am
    {
        public int Oid { get; set; }
        public string Amname { get; set; }
        public char Amtype { get; set; }
    }
}
