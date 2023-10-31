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
            ILivroRepository livroRepository,
            IUsuarioRepository usuarioRepository)
        {
            _interesseRepository = interesseRepository;
            _livroRepository = livroRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Interesse AprovarInteresse(Interesse interesse, int idDoador)
        {
            var interesseEncontrado = _interesseRepository.ObterPorId(interesse.Id);
            
            if (interesseEncontrado == null)
            {
                interesse.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("naoEncontrado", "Interesse não encontrado"));
                return interesse;
            }            

            interesseEncontrado.Livro = _livroRepository.ObterPorId(interesseEncontrado.LivroId);

            interesseEncontrado.ValidationResult = new InteresseAprovarInteresseValid(new Usuario() {  Id = idDoador }).Validate(interesseEncontrado);

            if (!interesseEncontrado.ValidationResult.IsValid)
                return interesseEncontrado;


            interesseEncontrado.Livro.Disponivel = false;

            interesseEncontrado.Aprovado = true;

             _interesseRepository.Alterar(interesseEncontrado);
            _livroRepository.Alterar(interesseEncontrado.Livro);

            return interesseEncontrado;
        }

        public Interesse ManifestarInteresse(Interesse interesse)
        {
            interesse.Data = DateTime.Now;
            interesse.Livro = _livroRepository.ObterPorId(interesse.LivroId);

            if (interesse.Livro == null)
            {
                interesse.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("naoEncontrado", "Livro não encontrado"));
                return interesse;
            }

            interesse.ValidationResult = new InteresseManifestarInteresseValid(_interesseRepository,_livroRepository, _usuarioRepository).Validate(interesse);

            if (!interesse.ValidationResult.IsValid)
                return interesse;

            _interesseRepository.Cadastrar(interesse);            

            return interesse;
        }
    }
}
