using AutoMapper;
using InterBankServices.Application.UseCases;
using InterBankServices.Application.UseCases.Interfaces;
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using InterBankServices.Models;
using InterBankServices.WebApi.Models;

namespace InterBankServices.Mapping
{
    public class ApplicationMapping : Profile
    {

        #region CONTRUCTOR
        public ApplicationMapping()
        {
            Mapping();
        }
        #endregion

        #region METODOS
        private void Mapping()
        {
            #region Mapping mediator request

            CreateMap<CertificateResponse, CertificateRequest>().ReverseMap();
            CreateMap<FinancialTypeResponse, FinancialTypeRequest>().ReverseMap();
            CreateMap<ValidateCertificateResponse, ValidateCertificateRequest>().ReverseMap();
            #endregion

            #region Mapping by entity
            CreateMap<CertificateResponseEntity, CertificateResponse>().ReverseMap();
            CreateMap<FinancialTypeEntity, FinancialTypeResponse>().ReverseMap();
            #endregion

            #region Mapping by request
            CreateMap<CertificateResponse, CertificateRequestEntity>().ReverseMap();
            #endregion

            #region Mapping by  response

            #endregion
        }
        #endregion
    }
}
