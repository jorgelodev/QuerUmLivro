
using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Infra.Data.Context;

namespace QuerUmLivro.Infra.Data.Repositories
{
    public class InteresseRepository : EFRepository<Interesse>, IInteresseRepository
    {
        public InteresseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
