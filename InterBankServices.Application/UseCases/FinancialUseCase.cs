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
    public class FinancialUseCase : IFinancialUseCase
    {

        #region ATRIBUTOS
        private readonly IMapper _mapper;
        private readonly ILog _log;
        private readonly IFinancialCommand _financialCommand;
        private readonly IFinancialQuery _financialQuery;

        #endregion

        #region CONTRUCTOR
        public FinancialUseCase(IMapper mapper, IFinancialCommand financialCommand, IFinancialQuery financialQuery)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _financialCommand = financialCommand ?? throw new ArgumentNullException(nameof(financialCommand));
            _financialQuery = financialQuery ?? throw new ArgumentNullException(nameof(financialQuery));
        }
        #endregion
        #region METODOS

        public async Task<ObjectResponse<FinancialTypeResponse>> CreateFinancialTypeRequestCommand(FinancialTypeResponse command)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion FinancialTypeResponse. Request: {0}", JsonConvert.SerializeObject(command)));
            var finalResponse = new ObjectResponse<FinancialTypeResponse>();

            var createCertificateRequest = await _financialCommand.CreateFinancialTypeRequestCommand(_mapper.Map<FinancialTypeEntity>(command));
            if (createCertificateRequest != null)
            {
                finalResponse.Code = 1;
                finalResponse.Message = "Exito";
                finalResponse.Item = command;
            }
            else
            {
                finalResponse.Message = "No hay datos";
            }

            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion FinancialTypeResponse. Response: {0}", JsonConvert.SerializeObject(finalResponse)));
            return finalResponse;
        }

        public async Task<ObjectResponse<FinancialTypeResponse>> ModifyFinancialTypeRequestCommand(FinancialTypeResponse command)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion FinancialTypeResponse. Request: {0}", JsonConvert.SerializeObject(command)));
            var finalResponse = new ObjectResponse<FinancialTypeResponse>();

            var createCertificateRequest = await _financialCommand.ModifyFinancialTypeRequestCommand(_mapper.Map<FinancialTypeEntity>(command));
            if (createCertificateRequest != null)
            {
                finalResponse.Code = 1;
                finalResponse.Message = "Exito";
                finalResponse.Item = command;
            }
            else
            {
                finalResponse.Message = "No hay datos";
            }

            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion FinancialTypeResponse. Response: {0}", JsonConvert.SerializeObject(finalResponse)));
            return finalResponse;
        }

        public async Task<List<FinancialTypeResponse>> ListFinancialType()
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListFinancialType. Request: {0}", JsonConvert.SerializeObject("")));
          
            var ListFinancialT = await _financialQuery.ListFinancialType();
           

            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListFinancialType. Response: {0}", JsonConvert.SerializeObject("")));
            return _mapper.Map< List<FinancialTypeResponse>>(ListFinancialT) ;
        }

        public async Task<List<FinancialTypeResponse>> ListFinancialTypeId(int id)
        {
            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListFinancialType. Request: {0}", JsonConvert.SerializeObject("")));

            var ListFinancialT = await _financialQuery.ListFinancialTypeId(id);


            LogInfo(System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("==>Ejecucion ListFinancialType. Response: {0}", JsonConvert.SerializeObject("")));
            return _mapper.Map<List<FinancialTypeResponse>>(ListFinancialT);
        }

        private void LogInfo(string metodo, string message)
        {
            var logAppender = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logAppender.Info("En " + GetType().FullName + " --> " + metodo + " FinancialTypeUseCase => " + message);
        }
        #endregion
    }
}
