using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Validations.Interesses.Specifications;
using QuerUmLivro.Domain.Validations.Livros.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    public class InteresseManifestarInteresseValid : AbstractValidator<Interesse>
    {
        private readonly IInteresseRepository _interesseRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public InteresseManifestarInteresseValid(IInteresseRepository interesseRepository, ILivroRepository livroRepository, IUsuarioRepository usuarioRepository)
        {
            _interesseRepository = interesseRepository;
            _livroRepository = livroRepository;
            _usuarioRepository = usuarioRepository;

            RuleFor(i => i).Must(InteresseJustificativaTamanhoSpec).WithMessage("Justificativa é obrigatória e com máximo de 100 caracteres.");
            RuleFor(i => i).Must(InteresseDataSpec).WithMessage("Data inválida.");
            RuleFor(i => i).Must(InteresseInteressadoSpec).WithMessage("Id interessado deve ser informado.");
            RuleFor(i => i).Must(InteresseLivroSpec).WithMessage("Id livro deve ser informado.");
            RuleFor(i => i).Must(InteresseLivroExisteSpec).WithMessage("Livro não existe.");
            RuleFor(i => i).Must(InteresseInteressadoNaoManifestouSpec).WithMessage("Interessado já manifestou interesse nesse livro.");
            RuleFor(l => l).Must(InteressadoExisteSpec).WithMessage("Interessado não existe. Informe um usuário cadastrado.");
            RuleFor(l => l).Must(LivroDisponivelSpec).WithMessage("Livro não está mais disponível.");
            RuleFor(l => l).Must(InteressadoNaoEhDonoSpec).WithMessage("Dono do livro não pode manifestar interesse no próprio livro.");

        }

        private bool InteresseJustificativaTamanhoSpec(Interesse interesse)
        {
            return new InteresseJustificativaTamanhoSpec().IsSatisfiedBy(interesse);
        }
        private bool InteresseDataSpec(Interesse interesse)
        {
            return new InteresseDataSpec().IsSatisfiedBy(interesse);
        }

        private bool InteresseInteressadoSpec(Interesse interesse)
        {
            return new InteresseInteressadoSpec().IsSatisfiedBy(interesse);
        }

        private bool InteresseLivroSpec(Interesse interesse)
        {
            return new InteresseLivroSpec().IsSatisfiedBy(interesse);
        }

        private bool InteresseInteressadoNaoManifestouSpec(Interesse interesse)
        {
            return new InteresseInteressadoNaoManifestouSpec(_interesseRepository).IsSatisfiedBy(interesse);
        }
        private bool InteresseLivroExisteSpec(Interesse interesse)
        {
            return new InteresseLivroExisteSpec(_livroRepository).IsSatisfiedBy(interesse);
        }

        private bool InteressadoExisteSpec(Interesse interesse)
        {
            return new InteresseInteressadoExisteSpec(_usuarioRepository).IsSatisfiedBy(interesse);
        }
        private bool LivroDisponivelSpec(Interesse interesse)
        {
            return new LivroDisponivelSpec().IsSatisfiedBy(interesse.Livro);
        }private bool InteressadoNaoEhDonoSpec(Interesse interesse)
        {
            return new InteresseInteressadoNaoEhDonoSpec().IsSatisfiedBy(interesse);
        }
        

    }
}
