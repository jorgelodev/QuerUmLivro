using QuerUmLivro.Application.ViewModels.Usuario;

namespace QuerUmLivro.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        AlteraUsuarioDto Alterar(AlteraUsuarioDto livro);
        UsuarioDto Cadastrar(CadastraUsuarioDto livro);
        UsuarioDto Deletar(int id);
        UsuarioDto ObterPorId(int id);
    }
}
