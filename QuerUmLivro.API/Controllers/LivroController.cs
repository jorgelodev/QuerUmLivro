using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Livro;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("Livro")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroAppService _livroAppService;
        private readonly IMapper _mapper;

        public LivroController(ILivroAppService livroAppService, IMapper mapper)
        {
            _livroAppService = livroAppService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Cadastrar(LivroViewModel livroViewModel)
        {
            var livroCadastrado = _livroAppService.Cadastrar(_mapper.Map<LivroDto>(livroViewModel));

            if (livroCadastrado.ValidationResult.IsValid)

                return Ok(_mapper.Map<LivroViewModel>(livroCadastrado));
            else
                return BadRequest(livroCadastrado.ValidationResult.Errors);
        }

        [HttpPut]
        public IActionResult Alterar(AlteraLivroDto alteraLivroDto)
        {
            _livroAppService.Alterar(alteraLivroDto);

            return Ok("Livro Atualizado");

        }

        [HttpGet("{id}")]
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
        [HttpGet]
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

        [HttpDelete("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            _livroAppService.Deletar(id);

            return Ok("Livro Excluído");
        }
    }
}
