using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;

namespace QuerUmLivro.Domain.Validations.Livros.Specifications
{
    internal class LivroDoadorNaoPodeSerAlteradoSpec : ISpecification<Livro>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroDoadorNaoPodeSerAlteradoSpec(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public bool IsSatisfiedBy(Livro entidade)
        {
            var livro = _livroRepository.ObterPorId(entidade.Id);
            
            if(livro == null) 
                return false;

            return livro.DoadorId == entidade.DoadorId;
        }
    }
}
