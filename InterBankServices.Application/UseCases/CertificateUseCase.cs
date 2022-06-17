using AutoMapper;
using InterBankServices.Application.Features.Queries;
using InterBankServices.Application.UseCases.Interfaces;
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Application.UseCases
{
    public class CertificateUseCase : ICertificateUseCase
    {

        #region ATRIBUTOS
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ILog _log;
      //  private readonly ICertificateCommand _certificateCommmad;

        #endregion

        #region CONTRUCTOR
        public CertificateUseCase(IHttpContextAccessor httpContextAccessor, IMapper mapper/*, ICertificateCommand certificateCommand*/)
        {

            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
           
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
           /* _certificateCommmad = certificateCommand ?? throw new ArgumentNullException(nameof(certificateCommand));*/
        }
        #endregion

        #region METODOS

        public async Task<ObjectResponse<CertificateResponse>> CreateCertificate(CreateCertificateQuery query)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion RequestCertificate. Request: {0}", JsonConvert.SerializeObject(query)));
            var finalResponse = new ObjectResponse<CertificateResponse>();

            var dataCertificateRequest = _mapper.Map<CertificateRequestEntity>(query);
            var createCertificateRequest = dataCertificateRequest;
            //var createCertificateRequest = await _certificateCommmad.CreateCertificateRequestCommand(dataCertificateRequest);
            if (createCertificateRequest != null)
            {
                finalResponse.Code = 1;
                finalResponse.Message = "Exito";
                //  finalResponse.Item = createCertificateRequest;
            }
            else
            {
                finalResponse.Message = "No hay datos";
            }

            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion RequestCertificate. Response: {0}", JsonConvert.SerializeObject(finalResponse)));
            return finalResponse;
        }


        private void LogInfo(string metodo, string message)
        {
            var logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logAppender.Info("En " + GetType().FullName + " --> " + metodo + " CertificateUseCase => " + message);
        }
        #endregion
    }
}
