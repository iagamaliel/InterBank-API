using AutoMapper;
using InterBankServices.Application.Interfaces.Commands;
using InterBankServices.Application.Interfaces.Query;
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
        private readonly IMapper _mapper;
        private readonly ILog _log;
        private readonly ICertificateCommand _certificateCommmad;
        private readonly ICertificateQuery _certificateQuery;
        #endregion

        #region CONTRUCTOR
        public CertificateUseCase(IMapper mapper, ICertificateCommand certificateCommand, ICertificateQuery certificateQuery)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _certificateCommmad = certificateCommand ?? throw new ArgumentNullException(nameof(certificateCommand));
            _certificateQuery = certificateQuery ?? throw new ArgumentNullException(nameof(certificateQuery));
        }
        #endregion

        #region METODOS
        public async Task<List<CertificateResponse>> ListCertificate()
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListCertificate. Request: {0}", JsonConvert.SerializeObject("")));

            var ListT = await _certificateQuery.ListCertificate();


            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListCertificate. Response: {0}", JsonConvert.SerializeObject("")));
            return _mapper.Map<List<CertificateResponse>>(ListT);
        }

        public async Task<List<CertificateResponse>> ListCertificateId(int id)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListCertificate. Request: {0}", JsonConvert.SerializeObject("")));

            var ListT = await _certificateQuery.ListCertificateId(id);


            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListCertificate. Response: {0}", JsonConvert.SerializeObject("")));
            return _mapper.Map<List<CertificateResponse>>(ListT);
        }

        public async Task<ObjectResponse<CertificateResponse>> CreateCertificate(CertificateResponse certificateResponse)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion RequestCertificate. Request: {0}", JsonConvert.SerializeObject("")));
            var finalResponse = new ObjectResponse<CertificateResponse>();

            var createCertificateRequest = await _certificateCommmad.CreateCertificateRequestCommand(_mapper.Map<CertificateRequestEntity>(certificateResponse));
            if (createCertificateRequest != null)
            {
                finalResponse.Code = 1;
                finalResponse.Message = "Exito";
                finalResponse.Item = certificateResponse;
            }
            else
            {
                finalResponse.Message = "No hay datos";
            }

            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion RequestCertificate. Response: {0}", JsonConvert.SerializeObject(finalResponse)));
            return finalResponse;
        }


        public async Task<bool> ValidCertificate(string asfi_code, string serial_number)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ValidateCertificateResponse. Request: {0}", JsonConvert.SerializeObject("")));


            var ListFinancialType = new ValidateCertificateResponse();
            ListFinancialType.asfi_code = asfi_code;
            ListFinancialType.serial_number = serial_number;
            var Respons = await _certificateQuery.ValidCertificate(ListFinancialType);


            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ValidateCertificateResponse. Response: {0}", JsonConvert.SerializeObject("")));
            return Respons;
        }

        private void LogInfo(string metodo, string message)
        {
            var logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logAppender.Info("En " + GetType().FullName + " --> " + metodo + " CertificateUseCase => " + message);
        }
        #endregion
    }
}
