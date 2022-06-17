using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Core.Entities
{
    public class ChannelsResponse
    {
        public string asfi_code { get; set; }
        public string serial_Channel { get; set; }
        public string Name_Channel { get; set; }
        public DateTime created_date { get; set; }
        public byte Inactivate { get; set; }
    }
}
