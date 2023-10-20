using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;

namespace QuerUmLivro.Domain.Services
{
    public class LivroService : ServiceBase<Livro>, ILivroService
    {
        public LivroService(IRepositoryBase<Livro> repository) : base(repository)
        {
        }

    }
}
