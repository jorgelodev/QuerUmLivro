using QuerUmLivro.Domain.Entities;
using QuerUmLivro.Domain.Interfaces.Repositories;
using QuerUmLivro.Domain.Interfaces.Services;
using QuerUmLivro.Domain.Validations.Livros;

namespace QuerUmLivro.Domain.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public Livro Cadastrar(Livro livro)
        {
            livro.ValidationResult = new LivroCadastroValid().Validate(livro);

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
            //entidade.ValidationResult = new LivroAtualizacaoValid(_livroRepository).Validate(entidade);

            //if (!entidade.ValidationResult.IsValid)
            //    return entidade;

            return _livroRepository.Deletar(id);
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
    }
}
