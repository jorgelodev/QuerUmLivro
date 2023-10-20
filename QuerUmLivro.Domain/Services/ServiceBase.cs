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

        public T Alterar(T entidade)
        {
            return _repository.Alterar(entidade);
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return _repository.Buscar(predicate);
        }

        public T Cadastrar(T entidade)
        {
            return _repository.Cadastrar(entidade);
        }

        public T Deletar(int id)
        {
            return _repository.Deletar(id);
        }

        public T ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IList<T> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
