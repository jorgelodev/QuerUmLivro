using Microsoft.EntityFrameworkCore;
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Infra.Data.Context;
using System.Linq.Expressions;

namespace QuerUmLivro.Infra.Data.Repositories
{
    public class EFRepository<T> : IRepositoryBase<T> where T : Entidade
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Alterar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _dbSet.Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }
    }
}
