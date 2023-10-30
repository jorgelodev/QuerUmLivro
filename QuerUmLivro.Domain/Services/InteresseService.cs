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
        private readonly IUsuarioRepository _usuarioRepository;

        public InteresseService(
            IInteresseRepository interesseRepository, 
            ILivroRepository livrRepository,
            IUsuarioRepository usuarioRepository)
        {
            _interesseRepository = interesseRepository;
            _livroRepository = livrRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Interesse AprovarInteresse(Interesse interesse)
        {
            interesse = _interesseRepository.ObterPorId(interesse.Id);
            var livro = _livroRepository.ObterPorId(interesse.LivroId);
            
            livro.Disponivel = false;
            
            interesse.Aprovado = true;

             _interesseRepository.Alterar(interesse);
            _livroRepository.Alterar(livro);

            return interesse;
        }

        public Interesse ManifestarInteresse(Interesse interesse)
        {
            interesse.Data = DateTime.Now;

            interesse.ValidationResult = new InteresseManifestarInteresseValid(_interesseRepository,_livroRepository, _usuarioRepository).Validate(interesse);

            if (!interesse.ValidationResult.IsValid)
                return interesse;

            _interesseRepository.Cadastrar(interesse);            

            return interesse;
        }
    }
}
