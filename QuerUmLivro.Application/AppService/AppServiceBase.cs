using QuerUmLivro.Application.Interfaces;
using System.Linq.Expressions;

namespace QuerUmLivro.Application.AppService
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        public void Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public T ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
