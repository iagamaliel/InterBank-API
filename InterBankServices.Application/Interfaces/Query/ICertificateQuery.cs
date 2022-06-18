using InterBankServices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.Interfaces.Query
{
    public interface ICertificateQuery
    {
        Task<List<CertificateResponseEntity>> ListCertificate();
        Task<List<CertificateResponseEntity>> ListCertificateId(int id);
        Task<bool> ValidCertificate(ValidateCertificateResponse valid);
    }
}
