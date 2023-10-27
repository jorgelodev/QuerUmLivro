using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Validations.Interesses;

namespace QuerUmLivro.Domain.Services
{
    public class InteresseService : IInteresseService
    {
        private readonly IInteresseRepository _interesseRepository;
        private readonly ILivroRepository _livroRepository;

        public InteresseService(IInteresseRepository livroRepository, ILivroRepository livrRepository)
        {
            _interesseRepository = livroRepository;
            _livroRepository = livrRepository;
        }



        public Interesse ManifestarInteresse(Interesse interesse)
        {
            interesse.Data = DateTime.Now;

            interesse.ValidationResult = new InteresseManifestarInteresseValid(_interesseRepository,_livroRepository).Validate(interesse);

            if (!interesse.ValidationResult.IsValid)
                return interesse;

            _interesseRepository.Cadastrar(interesse);            

            return interesse;
        }
    }
}
