using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace QuerUmLivro.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

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
