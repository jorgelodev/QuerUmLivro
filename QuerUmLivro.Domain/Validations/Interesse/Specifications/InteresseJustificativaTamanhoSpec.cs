
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    internal class InteresseJustificativaTamanhoSpec : ISpecification<Interesse>
    {
        public bool IsSatisfiedBy(Interesse entidade)
        {
            var justificativa = entidade.Justificativa.Trim();

            return justificativa.Length > 0 && justificativa.Length <= 100;
        }
    }
}
