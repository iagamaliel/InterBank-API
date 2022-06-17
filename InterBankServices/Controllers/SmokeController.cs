using Microsoft.AspNetCore.Mvc;

namespace InterBankServices.Controllers
{
    [ApiVersion("1.0")]
    public class SmokeController : BaseController
    {
        #region Metodos

        [HttpGet]
        public IActionResult Test() => Ok("Is running.");
        #endregion
    }
}
