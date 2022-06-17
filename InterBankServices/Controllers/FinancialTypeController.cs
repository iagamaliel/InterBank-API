using AutoMapper;
using InterBankServices.Controllers;
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using InterBankServices.Models;
using InterBankServices.WebApi.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace InterBankServices.WebApi.Controllers
{
     [ApiVersion("1.0")]
    public class FinancialTypeController : BaseController
    {
        #region ATRIBUTOS
        private readonly ILog _log;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public FinancialTypeController(IMapper mapper)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region METODOS


        [HttpPost("CreateFinancialType")]
        [ProducesResponseType(typeof(ObjectResponse<FinancialTypeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateFinancialType([FromBody] FinancialTypeRequest request)
        {
            try
            {
                return Ok();
                //    return Ok(await Mediator.Send(_mapper.Map<CreateFinancialTypeQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al realizar el almacenamiento de la financiera";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        [HttpPut("ModifyFinancialType")]
        [ProducesResponseType(typeof(ObjectResponse<FinancialTypeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ModifyFinancialType([FromBody] FinancialTypeRequest request)
        {
            try
            {
                return Ok();
                // return Ok(await Mediator.Send(_mapper.Map<ModifyFinancialTypeQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al modificar la financiera";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        #endregion
    }
}
