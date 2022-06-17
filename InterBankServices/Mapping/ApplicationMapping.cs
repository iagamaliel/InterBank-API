using AutoMapper;
using InterBankServices.Application.Features.Queries;
using InterBankServices.Core.Entities;
using InterBankServices.Models;

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

            CreateMap<CreateCertificateQuery, CertificateRequest>().ReverseMap();
            #endregion

            #region Mapping by entity

            CreateMap<CertificateRequestEntity, CreateCertificateQuery>().ReverseMap();
            #endregion

            #region Mapping by request

            #endregion

            #region Mapping by  response

            #endregion
        }
        #endregion
    }
}
