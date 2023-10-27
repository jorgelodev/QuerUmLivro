
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    internal class InteresseDataSpec : ISpecification<Interesse>
    {
        public bool IsSatisfiedBy(Interesse interesse)
        {
            return interesse.Data > new DateTime(1900, 1, 1);
        }
    }
}
