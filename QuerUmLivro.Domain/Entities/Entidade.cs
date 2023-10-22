using FluentValidation.Results;

namespace QuerUmLivro.Domain.Entities
{
    public abstract class Entidade
    {
        public int Id { get; set; }
        protected Entidade()
        {
            ValidationResult = new ValidationResult();
        }
        public ValidationResult ValidationResult { get; set; }        
    }
}
