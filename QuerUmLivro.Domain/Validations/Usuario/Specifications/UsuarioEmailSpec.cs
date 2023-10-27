using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Specifications;
using QuerUmLivro.Domain.Validations.Utils;

namespace QuerUmLivro.Domain.Validations.Usuarios.Specifications
{
    internal class UsuarioEmailSpec : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            var email = usuario.Email.Trim();

            return RegexUtilities.IsValidEmail(email) && email.Length <= 100;
        }
    }
}
