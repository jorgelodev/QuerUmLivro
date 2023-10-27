using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Validations.Livros.Specifications;

namespace QuerUmLivro.Domain.Validations.Livros
{
    public class LivroCadastroValid : AbstractValidator<Livro>
    {
        public LivroCadastroValid()
        {
            RuleFor(l => l).Must(NomeObrigatorio).WithMessage("Nome é obrigatório");
            RuleFor(l => l).Must(NomeTamanho).WithMessage("Nome deve ter no máximo 100 caracteres");
            RuleFor(l => l).Must(DoadorObrigatorio).WithMessage("Doador é obrigatório");
        }

        private bool NomeObrigatorio(Livro livro)
        {
            return new LivroNomeObrigatorioSpec().IsSatisfiedBy(livro);
        }

        private bool NomeTamanho(Livro livro)
        {
            return new LivroNomeTamanhoValidoSpec().IsSatisfiedBy(livro);
        }

        private bool DoadorObrigatorio(Livro livro)
        {
            return new LivroDoadorObrigatorioSpec().IsSatisfiedBy(livro);
        }
    }
}
