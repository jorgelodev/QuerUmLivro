using AutoMapper;
using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Application.ViewModels.Usuario;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Services;

namespace QuerUmLivro.Application.AppService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;        
        private readonly IMapper _mapper;

        public UsuarioAppService(
            IUsuarioService usuarioService,             
            IMapper mapper)
        {            
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public AlteraUsuarioDto Alterar(AlteraUsuarioDto alteraUsuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(alteraUsuarioDto);
            
            return _mapper.Map<AlteraUsuarioDto>(_usuarioService.Alterar(usuario));
        }

        public UsuarioDto Cadastrar(CadastraUsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);            

            return _mapper.Map<UsuarioDto>(_usuarioService.Cadastrar(usuario));
        }

        public UsuarioDto Deletar(int id)
        {
            var livro = _usuarioService.Deletar(id);

            return _mapper.Map<UsuarioDto>(livro);
        }

        public UsuarioDto ObterPorId(int id)
        {
            var livro = _usuarioService.ObterPorId(id);

            return _mapper.Map<UsuarioDto>(livro);
        }

      

      
    }
}
