using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Validations.Livros.Specifications;

namespace QuerUmLivro.Domain.Validations.Livros
{
    public class LivroAtualizacaoValid : AbstractValidator<Livro>
    {
        private readonly ILivroRepository _livroRepository;
        public LivroAtualizacaoValid(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;

            RuleFor(l => l).Must(IdLivroObrigatorio).WithMessage("Id do Livro não informado");
            RuleFor(l => l).Must(NomeObrigatorio).WithMessage("Nome é obrigatório");
            RuleFor(l => l).Must(NomeTamanho).WithMessage("Nome deve ter no máximo 100 caracteres");
            RuleFor(l => l).Must(DoadorObrigatorio).WithMessage("Doador é obrigatório");
            RuleFor(l => l).Must(DoadorNaoPodeSerAlteradoSpec).WithMessage("Doador não pode ser alterado");
        }
        private bool IdLivroObrigatorio(Livro livro)
        {
            return new LivroIdObrigatorioSpec().IsSatisfiedBy(livro);
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

        private bool DoadorNaoPodeSerAlteradoSpec(Livro livro)
        {
            return new LivroDoadorNaoPodeSerAlteradoSpec(_livroRepository).IsSatisfiedBy(livro);
        }
    }
}
