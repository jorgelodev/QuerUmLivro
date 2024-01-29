using Microsoft.AspNetCore.Mvc;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("Apresentacao")]
    public class ApresentacaoProjeto : Controller
    {
        [HttpGet()]
        public IActionResult Ola()
        {
            return Ok("Tech Challenge Fase 2");
        }
    }
}
