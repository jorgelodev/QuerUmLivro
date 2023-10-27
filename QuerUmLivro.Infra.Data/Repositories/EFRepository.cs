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

        public T Alterar(T entidade)
        {
            var existingEntity = _dbSet.Find(entidade.Id);

            if (existingEntity != null)
            {                
                _dbSet.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Update(entidade);
            _context.SaveChanges();

            return entidade;
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public T Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();

            return entidade;
        }

        public T Deletar(int id)
        {
            var entidade = ObterPorId(id);

            _dbSet.Remove(entidade);
            _context.SaveChanges();

            return entidade;
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
