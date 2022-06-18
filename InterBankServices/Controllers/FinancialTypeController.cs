using AutoMapper;
using InterBankServices.Application.UseCases.Interfaces;
using InterBankServices.Controllers;
using InterBankServices.Core;
using InterBankServices.Core.Entities;
using InterBankServices.Models;
using InterBankServices.WebApi.Models;
using log4net;
using MediatR;
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
        private readonly IFinancialUseCase _financialUseCase;

        #endregion

        #region CONSTRUCTOR
        public FinancialTypeController(IMapper mapper, IFinancialUseCase financialUseCase)
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _financialUseCase = financialUseCase ?? throw new ArgumentException(null, nameof(financialUseCase));
        }
        #endregion

        public class FinancialType
        {
            public int id { get; set; }
            public string description { get; set; }
        }



        #region METODOS
        [HttpGet("ListFinancialType")]
        public JsonResult ListFinancialType()
        {

            var lista = new List<FinancialType>()
             {
                 new FinancialType {id = 1, description ="financiera"}
             };

            return new JsonResult(lista);
        }
        //[HttpGet("ListFinancialType")]
        //[ProducesResponseType(typeof(ObjectResponse<FinancialTypeResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        //public async Task<IActionResult> ListFinancialType()
        //{
        //    return Ok(await _financialUseCase.ListFinancialType());
        //}

        [HttpGet("ListFinancialTypeId")]
        [ProducesResponseType(typeof(ObjectResponse<FinancialTypeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> ListFinancialTypeId(int id)
        {
            return Ok(await _financialUseCase.ListFinancialTypeId(id));
        }

        [HttpPost("CreateFinancialType")]
        [ProducesResponseType(typeof(ObjectResponse<FinancialTypeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateFinancialType([FromBody] FinancialTypeRequest request)
        {
            try
            {
                return Ok(_financialUseCase.CreateFinancialTypeRequestCommand(_mapper.Map<FinancialTypeResponse>(request)));

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
                return Ok(_financialUseCase.ModifyFinancialTypeRequestCommand(_mapper.Map<FinancialTypeResponse>(request)));

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
