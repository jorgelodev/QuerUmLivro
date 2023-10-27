using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Validations.Usuarios.Specifications;

namespace QuerUmLivro.Domain.Validations.Usuarios
{
    public class UsuarioExclusaoValid : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioExclusaoValid(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;            
            
            RuleFor(i => i).Must(UsuarioEmailUnicoSpec).WithMessage("E-mail já está sendo utilizado.");
        }
        private bool UsuarioEmailUnicoSpec(Usuario usuario)
        {
            return new UsuarioEmailUnicoSpec(_usuarioRepository).IsSatisfiedBy(usuario);
        }

    }
}
