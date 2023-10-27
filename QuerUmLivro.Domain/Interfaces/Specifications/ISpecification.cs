namespace QuerUmLivro.Domain.Interfaces.Specifications
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entidade);
    }
}
