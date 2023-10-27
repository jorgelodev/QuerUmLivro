using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.DTOs.Livro;

namespace QuerUmLivro.Application.Interfaces
{
    public interface ILivroAppService
    {
        LivroDto Cadastrar(CadastraLivroDto livroDto);
        AlteraLivroDto Alterar(AlteraLivroDto alteraLivroDto);
        IList<LivroDto> ObterPorDoador(int idUsuario);        
        LivroDto ObterPorId(int id);
        LivroDto Deletar(int id);
        IList<LivroDto> Disponiveis();
        InteresseDto ManifestarInteresse(InteresseDto interesse);
    }
}
