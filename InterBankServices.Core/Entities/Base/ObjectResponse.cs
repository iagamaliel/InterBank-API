using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Core
{
    public class ObjectResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Item { get; set; }
    }
}
