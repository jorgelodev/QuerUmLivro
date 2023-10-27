using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Validations.Usuarios;

namespace QuerUmLivro.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            usuario.ValidationResult = new UsuarioCadastroValid(_usuarioRepository).Validate(usuario);

            if (!usuario.ValidationResult.IsValid)
                return usuario;            

            return _usuarioRepository.Cadastrar(usuario);
        }

        public Usuario Alterar(Usuario usuarioModificado)
        {
            var usuario = _usuarioRepository.ObterPorId(usuarioModificado.Id);

            if (usuario == null)
            {
                usuarioModificado.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("naoEncontrado", "Usuário não encontrado"));
                return usuarioModificado;
            }

            usuario.Nome = usuarioModificado.Nome;
            usuario.Email = usuarioModificado.Email;

            usuario.ValidationResult = new UsuarioAtualizacaoValid(_usuarioRepository).Validate(usuario);

            if (!usuario.ValidationResult.IsValid)
                return usuario;

            return _usuarioRepository.Alterar(usuario);

        }

        public Usuario Deletar(int id)
        {
            try
            {
                return _usuarioRepository.Deletar(id);
                
            }
            catch
            {
                var usuario = new Usuario();
                usuario.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("falhaExclusao", "Usuário está sendo utilizado, não é possível excluir."));

                return usuario;
            }            
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioRepository.ObterPorId(id);
        }
       
    }
}
