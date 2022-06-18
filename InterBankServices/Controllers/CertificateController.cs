using AutoMapper;
using InterBankServices.Application.UseCases.Interfaces;
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using InterBankServices.Models;
using InterBankServices.WebApi.CorrelationIdMiddleware;
using InterBankServices.WebApi.Models;
using log4net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace InterBankServices.Controllers
{
    [ApiVersion("1.0")]
    public class CertificateController : BaseController
    {
        #region ATRIBUTOS
        private readonly ILog _log;
        private readonly IMapper _mapper;
        private readonly ICertificateUseCase _certificateUseCase;
        #endregion

        #region CONSTRUCTOR
        public CertificateController(IMapper mapper,  ICertificateUseCase certificateUseCase)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _certificateUseCase = certificateUseCase ?? throw new ArgumentException(null, nameof(certificateUseCase));
        }
        #endregion

        #region METODOS
        [HttpGet("ListCertificate")]
        [ProducesResponseType(typeof(ObjectResponse<CertificateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ListCertificate()
        {
            return Ok(await _certificateUseCase.ListCertificate());
        }

        [HttpGet("ListCertificateId")]
        [ProducesResponseType(typeof(ObjectResponse<CertificateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ListCertificateId(int id)
        {
            return Ok(await _certificateUseCase.ListCertificateId(id));
        }
        [HttpGet("ValidCertificate")]
        public async Task<bool> ValidCertificate(string asfi_code ,string serial_number)
        {

            return await _certificateUseCase.ValidCertificate(asfi_code, serial_number);
        }

        [TypeFilter(typeof(CorrelationIdMiddleware))]
        [HttpPost("CreateCertificate")]
        [ProducesResponseType(typeof(ObjectResponse<CertificateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateCertificate([FromBody] CertificateRequest request)
        {
            try
            {
                return Ok(_certificateUseCase.CreateCertificate(_mapper.Map<CertificateResponse>(request)));
            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al realizar el almacenamiento del Certificado";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        #endregion
    }
}
