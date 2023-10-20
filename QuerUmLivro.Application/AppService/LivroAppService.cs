using QuerUmLivro.Application.Interfaces;
using QuerUmLivro.Domain.Entities;
using System.Linq.Expressions;

namespace QuerUmLivro.Application.AppService
{
    public class LivroAppService : ILivroAppService
    {
        public void Alterar(Livro entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livro> Buscar(Expression<Func<Livro, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Livro entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Livro ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Livro> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
