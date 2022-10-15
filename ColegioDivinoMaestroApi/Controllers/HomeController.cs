using Microsoft.AspNetCore.Mvc;

namespace ColegioDivinoMaestroApi.Controllers
{
    [Controller]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<object> HomePage()
        {
            return Ok(new { hola = "Conti!!"});
        }
    }
}
