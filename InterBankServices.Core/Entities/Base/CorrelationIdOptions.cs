using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Core.Entities.Base
{
    public class CorrelationIdOptions
    {
        private const string DefaultHeader = "X-Correlation-Id";

        public string Header { get; set; } = DefaultHeader;

        public bool IncludeInResponse { get; set; } = true;
    }
}
