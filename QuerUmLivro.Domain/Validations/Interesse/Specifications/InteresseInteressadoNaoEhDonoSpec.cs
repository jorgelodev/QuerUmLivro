using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Validations.Interesses.Specifications
{
    internal class InteresseInteressadoNaoEhDonoSpec : ISpecification<Interesse>
    {
        public bool IsSatisfiedBy(Interesse interesse)
        {
            return interesse.Livro.DoadorId != interesse.InteressadoId;
        }
    }
}
