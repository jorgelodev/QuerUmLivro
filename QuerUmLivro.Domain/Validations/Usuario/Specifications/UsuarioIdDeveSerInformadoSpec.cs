using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;

namespace QuerUmLivro.Domain.Validations.Usuarios.Specifications
{
    internal class UsuarioIdDeveSerInformadoSpec : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return usuario.Id > 0;
        }
    }
}
