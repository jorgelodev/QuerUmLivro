using FluentValidation.Results;

namespace QuerUmLivro.Application.DTOs.Livro
{
    public class LivroDto
    {
        public LivroDto()
        {
            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public bool Disponivel { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
