using InterBankServices.Application.Features.Queries;
using InterBankServices.Application.UseCases.Interfaces;
using InterBankServices.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.Handlers.Queries
{
    public class CreateCertificateQueryHandler : IRequestHandler<CreateCertificateQuery, ObjectResponse<CertificateResponse>>
    {
        #region ATTRIBUTES
        private readonly ICertificateUseCase _certificateUseCase;
        #endregion

        #region CONSTRUCTOR
        public CreateCertificateQueryHandler(ICertificateUseCase certificateUseCase)
        {
            _certificateUseCase = certificateUseCase ?? throw new ArgumentException(null, nameof(certificateUseCase));
        }
        #endregion

        #region
        public async Task<ObjectResponse<CertificateResponse>> Handle(CreateCertificateQuery query, CancellationToken cancellationToken)
        {
            var finalResponse = new ObjectResponse<CertificateResponse>();

            var response = await _certificateUseCase.CreateCertificate(query);
            if (response != null)
            {
                finalResponse.Code = 1;
                finalResponse.Message = "Exito";
            }
            else
            {
                finalResponse.Message = "No hay datos";
            }

            return finalResponse;
        }
        #endregion

    }
}
