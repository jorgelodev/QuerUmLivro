using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Domain.DTOs;

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
        public IActionResult Cadastrar(LivroDTO livroDTO)
        {
            _livroAppService.Cadastrar(null);

            return Ok("Livro Cadastrado");
        }
        [HttpPut("atualizar")]
        public IActionResult Atualizar(LivroDTO livroDTO)
        {
            return Ok("Livro Atualizado");

        }        

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            try
            {

                return Ok("Livro por ID");
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
                
                return Ok("Todos os livros");
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
            return Ok("Livro Excluído");
        }
    }
}
