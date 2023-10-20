using QuerUmLivro.Application.DTOs.Livro;

namespace QuerUmLivro.Application.Interfaces
{
    public interface ILivroAppService
    {
        LivroDto Cadastrar(LivroDto livroDto);
        AlteraLivroDto Alterar(AlteraLivroDto alteraLivroDto);

        IList<LivroDto> ObterTodos();
        LivroDto ObterPorId(int id);
        LivroDto Deletar(int id);
    }
}
