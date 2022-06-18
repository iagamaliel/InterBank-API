using InterBankServices.Core;
using InterBankServices.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.UseCases.Interfaces
{
    public interface ICertificateUseCase
    {

        Task<List<CertificateResponse>> ListCertificate();
        Task<List<CertificateResponse>> ListCertificateId(int id);
        Task<ObjectResponse<CertificateResponse>> CreateCertificate(CertificateResponse certificateResponse);

        Task<bool>  ValidCertificate(string asfi_code, string serial_number);
    }
}
