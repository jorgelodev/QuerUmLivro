using FluentValidation;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Validations.Livros
{
    public class LivroValid : AbstractValidator<Livro>
    {
        public LivroValid()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(l => l.Nome).MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");
            RuleFor(c => c.IdUsuario).GreaterThan(0).WithMessage("Usuário é obrigatório");
        }
    }
}
