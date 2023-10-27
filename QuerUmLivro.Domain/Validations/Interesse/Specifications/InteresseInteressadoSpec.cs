
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    internal class InteresseInteressadoSpec : ISpecification<Interesse>
    {
        public bool IsSatisfiedBy(Interesse interesse)
        {
            return interesse.InteressadoId > 0;
        }
    }
}
