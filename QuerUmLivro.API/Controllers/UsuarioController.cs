using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuerUmLivro.Application.AppService;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Usuario;

namespace QuerUmLivro.API.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioAppService usuarioAppService, IMapper mapper)
        {
            _usuarioAppService = usuarioAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastro de usuário.
        /// </summary>
        /// <param name="cadastraUsuarioViewModel">ViewModel para cadastro de usuário.</param>        
        /// <remarks>
        /// 
        /// Informe o nome e e-mail para realizar o cadastro do usuário. 
        /// 
        /// </remarks>
        /// <response code="200">Cadastro Realizado com sucesso</response>
        /// <response code="400">Cadastro não realizado, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPost]
        public IActionResult Cadastrar(CadastraUsuarioViewModel cadastraUsuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuarioCadastrado = _usuarioAppService.Cadastrar(_mapper.Map<CadastraUsuarioDto>(cadastraUsuarioViewModel));

            if (!usuarioCadastrado.ValidationResult.IsValid)
                AdicionarErroProcessamento(usuarioCadastrado.ValidationResult);

            return CustomResponse();
        }

        /// <summary>
        /// Alteração de usuário.
        /// </summary>
        /// <param name="alteraUsuarioViewModel">ViewModel para alterar usuário.</param>        
        /// <remarks>
        /// 
        /// Informe o nome, e-mail e id do usuário para realizar a alteração. 
        /// 
        /// </remarks>
        /// <response code="200">Alteração Realizada com sucesso</response>
        /// <response code="400">Alteração não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpPut]
        public IActionResult Alterar(AlteraUsuarioViewModel alteraUsuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var alteraUsuarioDto = _usuarioAppService.Alterar(_mapper.Map<AlteraUsuarioDto>(alteraUsuarioViewModel));

            if (!alteraUsuarioDto.ValidationResult.IsValid)

                AdicionarErroProcessamento(alteraUsuarioDto.ValidationResult);

            return CustomResponse();

        }

        /// <summary>
        /// Consulta um usuário por id.
        /// </summary>
        /// <param name="id">Id do Usuario.</param>        
        /// <remarks>
        /// 
        /// Envia id do Usuário para api.        
        /// 
        /// </remarks>
        /// <response code="200">Retorna sucesso com o Usuário localizado</response>
        /// <response code="404">Usuário não encontrado</response>
        [HttpGet("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(_usuarioAppService.ObterPorId(id));

            if (usuarioViewModel == null)

                return NotFound("Usuario não encontrado");

            return Ok(usuarioViewModel);
        }

        /// <summary>
        /// Deletar um usuário.
        /// </summary>
        /// <param name="id">Id do usuário para deleção.</param>        
        /// <remarks>
        /// 
        /// Informe o id do usuário para realizar a deleção. 
        /// 
        /// </remarks>
        /// <response code="200">Deleção realizada com sucesso</response>
        /// <response code="400">Deleção não realizada, é retornado mensagem com o(s) motivo(s).</response>
        [HttpDelete("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuarioDto = _usuarioAppService.Deletar(id);

            if (!usuarioDto.ValidationResult.IsValid)

                AdicionarErroProcessamento(usuarioDto.ValidationResult);

            return CustomResponse();

        }
    }
}
