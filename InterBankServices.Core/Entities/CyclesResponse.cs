using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Core.Entities
{
    public class CyclesResponse
    {
        public string asfi_code { get; set; }
        public string serial_cycle { get; set; }
        public string name_cycle { get; set; }
        public DateTime created_date { get; set; }
        public DateTime end_date { get; set; }
        public byte Inactivate { get; set; }

    }
}
