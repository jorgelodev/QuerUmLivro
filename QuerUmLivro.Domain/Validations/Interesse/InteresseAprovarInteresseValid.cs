using FluentValidation;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Validations.Livros.Specifications;
using QuerUmLivro.Domain.Validations.Usuarios.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    public class InteresseAprovarInteresseValid : AbstractValidator<Interesse>
    {
        private readonly Usuario _doador;
        public InteresseAprovarInteresseValid(Usuario daoador)
        {
            _doador= daoador;

            RuleFor(i => i).Must(LivroDisponivelSpec).WithMessage("Livro não está mais disponível.");
            RuleFor(i => i).Must(DoadorEhDoadorDoLivroSpec).WithMessage("Doador informado não pode aprovar pois não é doador do Livro.");
            RuleFor(i => i).Must(DoadorObrigatorioSpec).WithMessage("Id Doador deve ser informado.");            
        }

        private bool LivroDisponivelSpec(Interesse interesse)
        {
            return new LivroDisponivelSpec().IsSatisfiedBy(interesse.Livro);
        }
        private bool DoadorEhDoadorDoLivroSpec(Interesse interesse)
        {
            return new LivroDoadorEhDoadorDoLivroSpec(_doador).IsSatisfiedBy(interesse.Livro);
        }
        private bool DoadorObrigatorioSpec(Interesse interesse)
        {
            return new UsuarioIdDeveSerInformadoSpec().IsSatisfiedBy(_doador);
        }


    }
}
