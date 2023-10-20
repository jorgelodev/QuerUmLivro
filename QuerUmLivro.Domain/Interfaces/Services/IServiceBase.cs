using System.Linq.Expressions;

namespace QuerUmLivro.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Deletar(int id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
    }
}
