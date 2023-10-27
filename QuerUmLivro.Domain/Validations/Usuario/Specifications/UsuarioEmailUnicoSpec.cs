using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Usuarios.Specifications
{
    internal class UsuarioEmailUnicoSpec : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioEmailUnicoSpec(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            var usuarioComMesmoEmail = _usuarioRepository
                .Buscar(u => u.Email.Equals(usuario.Email) && u.Id != usuario.Id)
                .FirstOrDefault();

            return usuarioComMesmoEmail == null;
        }
    }
}
