using FluentValidation.Results;

namespace QuerUmLivro.Application.DTOs.Livro
{
    public class CadastraLivroDto
    {
        public CadastraLivroDto()
        {
            ValidationResult = new ValidationResult();
        }

        public string Nome { get; set; }
        public int DoadorId { get; set; }        

        public ValidationResult ValidationResult { get; set; }
    }
}
