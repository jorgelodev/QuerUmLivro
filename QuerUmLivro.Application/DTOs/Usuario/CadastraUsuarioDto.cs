using FluentValidation.Results;

namespace QuerUmLivro.Application.ViewModels.Usuario
{
    public class CadastraUsuarioDto
    {        
        public CadastraUsuarioDto()
        {
            ValidationResult = new ValidationResult();
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
