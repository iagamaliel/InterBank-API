using AutoMapper;
using InterBankServices.Application.Features.Queries;
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using InterBankServices.Models;
using InterBankServices.WebApi.Models;
using log4net;
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
        #endregion

        #region CONSTRUCTOR
        public CertificateController(IMapper mapper)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region METODOS


        [HttpPost("CreateCertificate")]
        [ProducesResponseType(typeof(ObjectResponse<CertificateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateCertificate([FromBody] CertificateRequest request)
        {
            try
            {
                return Ok(await Mediator.Send(_mapper.Map<CreateCertificateQuery>(request)));
               
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

        [HttpPost("ValidateCertificate")]
        [ProducesResponseType(typeof(ObjectResponse<ValidateCertificateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ValidateCertificate([FromBody] ValidateCertificateRequest request)
        {
            try
            {
                return Ok();
               // return Ok(await Mediator.Send(_mapper.Map<ValidateCertificateQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al validar el Certificado";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }
        #endregion
    }
}
