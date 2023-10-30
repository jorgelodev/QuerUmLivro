using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;

namespace QuerUmLivro.Domain.Validations.Interesses.Specifications
{
    internal class InteresseInteressadoExisteSpec : ISpecification<Interesse>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public InteresseInteressadoExisteSpec(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Interesse entidade)
        {
            var usuarioEncontrado = _usuarioRepository.ObterPorId(entidade.InteressadoId);

            return usuarioEncontrado != null;
        }
    }
}
