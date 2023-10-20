
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Infra.Data.Context;

namespace QuerUmLivro.Infra.Data.Repositories
{
    public class LivroRepository : EFRepository<Livro>, ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
