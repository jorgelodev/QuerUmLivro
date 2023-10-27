using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.DTOs.Livro;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Interesse;
using QuerUmLivro.Application.ViewModels.Livro;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("Livro")]
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
        /// Informe o nome e id do doador para realizar o cadastro do livro. 
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
        /// Envia id do Livro para api.        
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
        /// Envia id do Doador para api.        
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
        /// Lista todos os livros que estão disponíveis para solicitar interesse.
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
        /// Manifestar interesse em um determinado livro.
        /// </summary>
        /// <param name="interesseViewModel">ViewModel para manifestar interesse.</param>        
        /// <remarks>
        /// 
        /// Informe o id do livro, id do interessado e justificativa para manifestar o interesse no livro. 
        /// 
        /// </remarks>
        /// <response code="200">Manifestação registrada com sucesso</response>
        /// <response code="400">Manifestação não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost("manifestar-interesse")]
        public IActionResult ManifestarInteresse(InteresseViewModel interesseViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var interesseManifestado = _livroAppService.ManifestarInteresse(_mapper.Map<InteresseDto>(interesseViewModel));

            if (!interesseManifestado.ValidationResult.IsValid)
                AdicionarErroProcessamento(interesseManifestado.ValidationResult);

            return CustomResponse();
        }
    }
}
