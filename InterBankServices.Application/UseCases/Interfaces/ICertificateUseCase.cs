using InterBankServices.Application.Features.Queries;
using InterBankServices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.UseCases.Interfaces
{
    public interface ICertificateUseCase
    {
        Task<ObjectResponse<CertificateResponse>> CreateCertificate(CreateCertificateQuery query);
    }
}
