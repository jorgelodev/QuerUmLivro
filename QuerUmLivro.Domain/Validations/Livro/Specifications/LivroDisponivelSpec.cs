using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;


namespace QuerUmLivro.Domain.Validations.Livros.Specifications
{
    internal class LivroDisponivelSpec : ISpecification<Livro>
    {
        public bool IsSatisfiedBy(Livro entidade)
        {
            return entidade.Disponivel;
        }
    }
}
