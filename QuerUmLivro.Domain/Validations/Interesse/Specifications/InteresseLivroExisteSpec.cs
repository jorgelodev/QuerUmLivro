
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    internal class InteresseLivroExisteSpec : ISpecification<Interesse>
    {
        private readonly ILivroRepository _livroRepository;

        public InteresseLivroExisteSpec(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public bool IsSatisfiedBy(Interesse interesse)
        {
            var livroEncontrado = _livroRepository.ObterPorId(interesse.LivroId);

            return livroEncontrado != null;
        }
    }
}
