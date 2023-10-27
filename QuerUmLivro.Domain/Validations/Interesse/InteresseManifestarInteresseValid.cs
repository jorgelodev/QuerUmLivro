using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    public class InteresseManifestarInteresseValid : AbstractValidator<Interesse>
    {
        private readonly IInteresseRepository _interesseRepository;
        private readonly ILivroRepository _livroRepository;
        public InteresseManifestarInteresseValid(IInteresseRepository interesseRepository, ILivroRepository livroRepository)
        {
            _interesseRepository = interesseRepository;
            _livroRepository = livroRepository;

            RuleFor(i => i).Must(InteresseJustificativaTamanhoSpec).WithMessage("Justificativa é obrigatória e com máximo de 100 caracteres.");
            RuleFor(i => i).Must(InteresseDataSpec).WithMessage("Data inválida.");
            RuleFor(i => i).Must(InteresseInteressadoSpec).WithMessage("Id interessado deve ser informado.");
            RuleFor(i => i).Must(InteresseLivroSpec).WithMessage("Id livro deve ser informado.");
            RuleFor(i => i).Must(InteresseLivroExisteSpec).WithMessage("Livro não existe.");
            RuleFor(i => i).Must(InteresseInteressadoNaoManifestouSpec).WithMessage("Interessado já manifestou interesse nesse livro.");
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
        
    }
}
