using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Validations.Interesses;

namespace QuerUmLivro.Domain.Services
{
    public class InteresseService : IInteresseService
    {
        private readonly IInteresseRepository _interesseRepository;

        public InteresseService(IInteresseRepository livroRepository)
        {
            _interesseRepository = livroRepository;
        }

        

        public Interesse ManifestarInteresse(Interesse interesse)
        {
            interesse.Data = DateTime.Now;

            interesse.ValidationResult = new InteresseManifestarInteresseValid(_interesseRepository).Validate(interesse);

            if (!interesse.ValidationResult.IsValid)
                return interesse;

            _interesseRepository.Cadastrar(interesse);            

            return interesse;
        }
    }
}
