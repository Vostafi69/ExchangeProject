using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeProject.Models.SysTables
{
    public class Pg_Cast : IPg_Cast
    {
        public int Oid { get; set; }
        public int CastSource { get; set; }
        public int CastTarget { get; set; }
        public int CastFunc { get; set; }
        public char CastContext { get; set; }
        public char CastMethod { get; set; }
    }
}
