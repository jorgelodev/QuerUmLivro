
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    internal class InteresseLivroSpec : ISpecification<Interesse>
    {
        public bool IsSatisfiedBy(Interesse interesse)
        {
            return interesse.LivroId > 0;
        }
    }
}
