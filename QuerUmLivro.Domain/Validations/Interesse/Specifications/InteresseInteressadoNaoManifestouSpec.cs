
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Interesses
{
    internal class InteresseInteressadoNaoManifestouSpec : ISpecification<Interesse>
    {
        private readonly IInteresseRepository _interesseRepository;

        public InteresseInteressadoNaoManifestouSpec(IInteresseRepository interesseRepository)
        {
            _interesseRepository = interesseRepository;
        }

        public bool IsSatisfiedBy(Interesse interesse)
        {
            var interesseEncontrado = _interesseRepository.Buscar(i =>
            i.InteressadoId == interesse.InteressadoId &&
            i.LivroId == interesse.LivroId).FirstOrDefault();

            return interesseEncontrado == null;
        }
    }
}
