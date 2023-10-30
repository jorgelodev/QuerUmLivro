using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Interfaces.Services
{
    public interface ILivroService
    {
        Livro Alterar(Livro livro);
        Livro Cadastrar(Livro livro);
        Livro Deletar(int id);
        Livro ObterPorId(int id);    
        IList<Livro> ObterPorDoador(int idUsuario);
        IList<Livro> Disponiveis();
        ICollection<Livro> ObterComInteresse(int idDoador);            
    }
}
