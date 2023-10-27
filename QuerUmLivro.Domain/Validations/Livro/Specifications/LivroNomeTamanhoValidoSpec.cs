using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Validations.Livros.Specifications
{
    internal class LivroNomeTamanhoValidoSpec : ISpecification<Livro>
    {
        public bool IsSatisfiedBy(Livro entidade)
        {
            return entidade.Nome.Trim().Length <= 100;
        }
    }
}
