using FluentValidation.Results;

namespace QuerUmLivro.Application.DTOs.Livro
{
    public class AlteraLivroDto
    {
        public AlteraLivroDto()
        {
            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public string Nome { get; set; }        
        public bool Disponivel { get; set; }

        public virtual ValidationResult ValidationResult { get; set; }
    }
}
