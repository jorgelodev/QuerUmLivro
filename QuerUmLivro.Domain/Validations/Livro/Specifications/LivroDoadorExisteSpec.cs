using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;

namespace QuerUmLivro.Domain.Validations.Livros.Specifications
{
    internal class LivroDoadorExisteSpec : ISpecification<Livro>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LivroDoadorExisteSpec(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Livro entidade)
        {
            var usuarioEncontrado = _usuarioRepository.ObterPorId(entidade.DoadorId);

            return usuarioEncontrado != null;
        }
    }
}
