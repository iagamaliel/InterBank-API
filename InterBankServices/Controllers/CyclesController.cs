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
    public class CyclesController : BaseController

    {
        #region ATRIBUTOS
        private readonly ILog _log;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public CyclesController(IMapper mapper)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region METODOS


        [HttpPost("CreateCycles")]
        [ProducesResponseType(typeof(ObjectResponse<CyclesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateCycles([FromBody] CyclesRequest request)
        {
            try
            {
                return Ok();
                //    return Ok(await Mediator.Send(_mapper.Map<CreateCyclesQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al realizar el almacenamiento del ciclo";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        [HttpPut("ModifyCycles")]
        [ProducesResponseType(typeof(ObjectResponse<CyclesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ModifyCycles([FromBody] CyclesRequest request)
        {
            try
            {
                return Ok();
                // return Ok(await Mediator.Send(_mapper.Map<ModifyCyclesQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al modificar el ciclo";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        #endregion
    }
}
