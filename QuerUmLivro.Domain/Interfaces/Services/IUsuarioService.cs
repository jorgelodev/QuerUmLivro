using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Alterar(Usuario livro);
        Usuario Cadastrar(Usuario livro);
        Usuario Deletar(int id);
        Usuario ObterPorId(int id);
    }
}
