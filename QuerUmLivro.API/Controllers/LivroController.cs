using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Livro;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("livro")]
    public class LivroController : MainController
    {
        private readonly ILivroAppService _livroAppService;
        private readonly IMapper _mapper;

        public LivroController(ILivroAppService livroAppService, IMapper mapper)
        {
            _livroAppService = livroAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastro de livros para doação.
        /// </summary>
        /// <param name="livroViewModel">ViewModel para cadastro de livro.</param>        
        /// <remarks>
        /// 
        /// Informe o nome do livro e o id do usuário doador para realizar o cadastro do livro. 
        /// 
        /// </remarks>
        /// <response code="200">Cadastro Realizado com sucesso</response>
        /// <response code="400">Cadastro não realizado, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost]
        public IActionResult Cadastrar(CadastraLivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var livroCadastrado = _livroAppService.Cadastrar(_mapper.Map<CadastraLivroDto>(livroViewModel));

            if (!livroCadastrado.ValidationResult.IsValid)
                AdicionarErroProcessamento(livroCadastrado.ValidationResult);

            return CustomResponse();
        }

        /// <summary>
        /// Alteração de livros para doação.
        /// </summary>
        /// <param name="alteraLivroViewModel">ViewModel para alterar livro.</param>        
        /// <remarks>
        /// 
        /// Informe o nome e id do livro para realizar a alteração. 
        /// 
        /// </remarks>
        /// <response code="200">Alteração Realizada com sucesso</response>
        /// <response code="400">Alteração não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPut]
        public IActionResult Alterar(AlteraLivroViewModel alteraLivroViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var alteraLivroDto = _livroAppService.Alterar(_mapper.Map<AlteraLivroDto>(alteraLivroViewModel));

            if (!alteraLivroDto.ValidationResult.IsValid)

                AdicionarErroProcessamento(alteraLivroDto.ValidationResult);

            return CustomResponse();

        }

        /// <summary>
        /// Consulta um livro por id.
        /// </summary>
        /// <param name="id">Id do Livro.</param>        
        /// <remarks>
        /// 
        /// Envia id do livro para api.        
        /// 
        /// </remarks>
        /// <response code="200">Retorna sucesso com o livro localizado</response>
        /// <response code="404">Livro não encontrado</response>
        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var livroViewModel = _mapper.Map<LivroViewModel>(_livroAppService.ObterPorId(id));

            if (livroViewModel == null)

                return NotFound("Livro não encontrado");

            return Ok(livroViewModel);
        }

        /// <summary>
        /// Consulta todos os livros de um determinado Doador.
        /// </summary>
        /// <param name="id">Id do Doador.</param>        
        /// <remarks>
        /// 
        /// Envia id do usuário doador para api.        
        /// 
        /// </remarks>
        /// <response code="200">Retorna sucesso com uma lista com os livros encontrados, ou uma lista vazia caso não encontre nenhum registro</response>        
        [HttpGet("livros-por-doador/{id}")]
        public IActionResult ObterTodosPorDoador([FromRoute] int id)
        {
            var livrosViewModel = _mapper.Map<List<LivroViewModel>>(_livroAppService.ObterPorDoador(id));            

            return Ok(livrosViewModel);

        }

        /// <summary>
        /// Consulta todos os livros que estão disponíveis.
        /// </summary>        
        /// <remarks>
        /// 
        /// Lista todos os livros que estão disponíveis para manifestar interesse.
        /// 
        /// </remarks>
        /// <response code="200">Retorna sucesso com uma lista com os livros encontrados, ou uma lista vazia caso não encontre nenhum registro</response>        
        [HttpGet("disponiveis")]
        public IActionResult LivrosDisponiveis()
        {
            var livrosViewModel = _mapper.Map<List<LivroViewModel>>(_livroAppService.Disponiveis());

            return Ok(livrosViewModel);

        }


        /// <summary>
        /// Deletar um livro.
        /// </summary>
        /// <param name="id">Id do livro para deleção.</param>        
        /// <remarks>
        /// 
        /// Informe o id do livro para realizar a deleção. 
        /// 
        /// </remarks>
        /// <response code="200">Deleção realizada com sucesso</response>
        /// <response code="400">Deleção não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var livroDto = _livroAppService.Deletar(id);

            if (!livroDto.ValidationResult.IsValid)

                AdicionarErroProcessamento(livroDto.ValidationResult);

            return CustomResponse();

        }

        /// <summary>
        /// Consulta todos os livros disponíveis, de um determinado doador, que já possuírem interesse cadastrado. 
        /// E para cada livro uma lista dos interesses já manifestados.
        /// </summary>
        /// <param name="id">Id do usuário Doador.</param>        
        /// <remarks>
        /// 
        /// Envia id do usuário doador para api.        
        /// 
        /// </remarks>
        /// <response code="200">Retorna sucesso com uma lista dos livros e suas solicitações de interesse, ou uma lista vazia caso não encontre nenhum registro</response>        
        [HttpGet("doador/{id}")]
        public IActionResult ObterComInteresse([FromRoute] int id)
        {
            var livrosViewModel = _mapper.Map<ICollection<LivroComInteressesViewModel>>(_livroAppService.ObterComInteresse(id));

            return Ok(livrosViewModel);

        }

    }
}
