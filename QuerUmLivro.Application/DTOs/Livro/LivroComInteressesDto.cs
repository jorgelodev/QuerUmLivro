using FluentValidation.Results;
using QuerUmLivro.Application.DTOs.Interesse;

namespace QuerUmLivro.Application.DTOs.Livro
{
    public class LivroComInteressesDto
    {
        public LivroComInteressesDto()
        {
            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DoadorId { get; set; }
        public bool Disponivel { get; set; }        
        public ICollection<InteresseDto> Interesses { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
