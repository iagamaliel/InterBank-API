using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Infrastructure.Exceptions
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpException(HttpStatusCode codigo, string servicio) : base($"El servicio {servicio} ha respondido con código {codigo}")
        {

        }
    }
}
