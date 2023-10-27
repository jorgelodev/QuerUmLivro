using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Validations.Livros.Specifications
{
    internal class LivroDoadorObrigatorioSpec : ISpecification<Livro>
    {
        public bool IsSatisfiedBy(Livro entidade)
        {
            return entidade.DoadorId > 0;
        }
    }
}
