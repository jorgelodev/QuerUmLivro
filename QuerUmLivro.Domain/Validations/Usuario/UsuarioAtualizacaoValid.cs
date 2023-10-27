using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Validations.Usuarios.Specifications;

namespace QuerUmLivro.Domain.Validations.Usuarios
{
    public class UsuarioAtualizacaoValid : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioAtualizacaoValid(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

            RuleFor(i => i).Must(UsuarioNomeTamanhoSpec).WithMessage("Nome é obrigatório e com máximo de 100 caracteres.");
            RuleFor(i => i).Must(UsuarioEmailSpec).WithMessage("Formato do E-mail inválido, ou não definido. E-mail é obrigatório e com máximo de 100 caracteres.");
            RuleFor(i => i).Must(UsuarioEmailUnicoSpec).WithMessage("E-mail já está sendo utilizado.");
        }

        private bool UsuarioNomeTamanhoSpec(Usuario usuario)
        {
            return new UsuarioNomeTamanhoSpec().IsSatisfiedBy(usuario);
        }
        private bool UsuarioEmailSpec(Usuario usuario)
        {
            return new UsuarioEmailSpec().IsSatisfiedBy(usuario);
        }

        private bool UsuarioEmailUnicoSpec(Usuario usuario)
        {
            return new UsuarioEmailUnicoSpec(_usuarioRepository).IsSatisfiedBy(usuario);
        }

    }
}
