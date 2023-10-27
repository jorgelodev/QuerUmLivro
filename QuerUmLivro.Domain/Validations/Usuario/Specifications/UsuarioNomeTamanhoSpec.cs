using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Validations.Usuarios.Specifications
{
    internal class UsuarioNomeTamanhoSpec : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            var nome = usuario.Nome.Trim();
            return nome.Length > 0 && nome.Length <= 100;
        }
    }
}
