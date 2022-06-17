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
    public class ChannelsController : BaseController
    {

        #region ATRIBUTOS
        private readonly ILog _log;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public ChannelsController(IMapper mapper)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region METODOS


        [HttpPost("CreateChannels")]
        [ProducesResponseType(typeof(ObjectResponse<ChannelsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateChannels([FromBody] ChannelsRequest request)
        {
            try
            {
                return Ok();
                //    return Ok(await Mediator.Send(_mapper.Map<CreateChannelsQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al realizar el almacenamiento del canal";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        [HttpPut("ModifyChannels")]
        [ProducesResponseType(typeof(ObjectResponse<ChannelsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ModifyChannels([FromBody] ChannelsRequest request)
        {
            try
            {
                return Ok();
                // return Ok(await Mediator.Send(_mapper.Map<ModifyChannelsQuery>(request)));

            }
            catch (FormatException ex)
            {
                return BadRequest(new GenericResponse { Code = 0, Message = ex.Message });
            }
            catch (Exception ex)
            {
                string message = "Ha ocurrido un error al modificar el canal";
                _log.Error(message + " , error : " + ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new GenericResponse { Code = 0, Message = message });
            }
        }

        
        #endregion

    }
}
