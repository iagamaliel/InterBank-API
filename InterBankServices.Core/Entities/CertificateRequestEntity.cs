using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Core.Entities
{
    public class CertificateRequestEntity
    {
        public string asfi_code { get; set; }
        public string serial_number { get; set; }
        public DateTime created_date { get; set; }
        public DateTime validity_date { get; set; }
        public string owner { get; set; }
        public byte certificate { get; set; }

    }
}
