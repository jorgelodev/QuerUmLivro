using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Validations.Livros;

namespace QuerUmLivro.Domain.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public LivroService(ILivroRepository livroRepository, IUsuarioRepository usuarioRepository)
        {
            _livroRepository = livroRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Livro Cadastrar(Livro livro)
        {
            livro.ValidationResult = new LivroCadastroValid(_usuarioRepository).Validate(livro);

            if (!livro.ValidationResult.IsValid)
                return livro;

            livro.Disponivel = true;

            return _livroRepository.Cadastrar(livro);
        }

        public Livro Alterar(Livro livroModificado)
        {
            var livro = _livroRepository.ObterPorId(livroModificado.Id);

            if (livro == null)
            {
                livroModificado.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("naoEncontrado", "Livro não encontrado"));
                return livroModificado;
            }

            livro.Nome = livroModificado.Nome;

            livro.ValidationResult = new LivroAtualizacaoValid(_livroRepository).Validate(livro);

            if (!livro.ValidationResult.IsValid)
                return livro;

            return _livroRepository.Alterar(livro);

        }

        public Livro Deletar(int id)
        {
            try
            {
                return _livroRepository.Deletar(id);

            }            
            catch(Exception ex)
            {
                var livro = new Livro();
                livro.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("falhaExclusao", ex.Message));

                return livro;
            }
        }

        public Livro ObterPorId(int id)
        {
            return _livroRepository.ObterPorId(id);
        }

        public IList<Livro> ObterPorDoador(int idUsuario)
        {

            return _livroRepository.Buscar(l => l.DoadorId == idUsuario).ToList();
        }

        public IList<Livro> Disponiveis()
        {
            return _livroRepository.Buscar(l => l.Disponivel).ToList();
        }

        public ICollection<Livro> ObterComInteresse(int idDoador)
        {
            return _livroRepository.ObterComInteresse(idDoador).ToList();
        }
    }
}
