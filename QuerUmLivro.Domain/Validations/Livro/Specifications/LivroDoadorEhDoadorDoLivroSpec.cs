using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Validations.Livros.Specifications
{
    internal class LivroDoadorEhDoadorDoLivroSpec : ISpecification<Livro>
    {        
        private readonly Usuario _doador;
        public LivroDoadorEhDoadorDoLivroSpec(Usuario doador)
        {
            _doador = doador;            
        }

        public bool IsSatisfiedBy(Livro livro)
        {
            return livro.DoadorId == _doador.Id;
        }
    }
}
