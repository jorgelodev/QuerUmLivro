using FluentValidation.Results;

namespace QuerUmLivro.Application.DTOs.Interesse
{
    public class InteresseDto
    {
        public InteresseDto()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }
        public int LivroId { get; set; }
        public int InteressadoId { get; set; }
        public string Justificativa { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
