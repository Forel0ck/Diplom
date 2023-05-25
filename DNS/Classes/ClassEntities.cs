using DNS.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNS.Classes
{
    internal class ClassEntities
    {
        public static DNSEntities2 context { get; set; } = new DNSEntities2();
    }
}
