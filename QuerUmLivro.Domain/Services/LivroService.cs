using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Validations.Livros;

namespace QuerUmLivro.Domain.Services
{
    public class LivroService : ServiceBase<Livro>, ILivroService
    {
        public LivroService(IRepositoryBase<Livro> repository) : base(repository)
        {
        }

        public override Livro Cadastrar(Livro entidade)
        {            
            entidade.ValidationResult = new LivroValid().Validate(entidade);


            if (!entidade.ValidationResult.IsValid)
                return entidade;

            return base.Cadastrar(entidade);
        }
         
        public override Livro Alterar(Livro entidade)
        {  

            return base.Alterar(entidade);

        }

    }
}
