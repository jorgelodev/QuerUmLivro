using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.Interfaces;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("Livro")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroAppService _livroAppService;

        public LivroController(ILivroAppService livroAppService)
        {
            _livroAppService = livroAppService;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(LivroDto livroDto)
        {

            _livroAppService.Cadastrar(livroDto);

            return Ok("Livro Cadastrado");
        }
        [HttpPut("alterar")]
        public IActionResult Alterar(AlteraLivroDto alteraLivroDto)
        {
            _livroAppService.Alterar(alteraLivroDto);

            return Ok("Livro Atualizado");

        }        

        [HttpGet("obter-por-id/{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            try
            {
                var livroDto = _livroAppService.ObterPorId(id);

                return Ok(livroDto);
            }
            catch (Exception ex)
            {

                //_logger.LogError(ex, $"Exception Forçada: {ex.Message}");
                return BadRequest();

            }
        }
        [HttpGet("obter-todos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var livrosDto = _livroAppService.ObterTodos();

                return Ok(livrosDto);
            }
            catch (Exception ex)
            {

                //_logger.LogError(ex, $"Exception Forçada: {ex.Message}");
                return BadRequest();

            }
        }

        [HttpDelete("remover/{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            _livroAppService.Deletar(id);

            return Ok("Livro Excluído");
        }
    }
}
