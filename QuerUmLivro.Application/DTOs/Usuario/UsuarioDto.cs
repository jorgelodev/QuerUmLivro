using FluentValidation.Results;

namespace QuerUmLivro.Application.ViewModels.Usuario
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ValidationResult ValidationResult { get; set; }
        
    }
}
