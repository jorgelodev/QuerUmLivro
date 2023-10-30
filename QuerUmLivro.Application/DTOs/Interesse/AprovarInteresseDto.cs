using FluentValidation.Results;

namespace QuerUmLivro.Application.ViewModels.Interesse
{
    public class AprovarInteresseDto
    {
        public AprovarInteresseDto()
        {
            ValidationResult = new ValidationResult();
        }
        public int Id { get; set; }
        public int DoadorId { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
