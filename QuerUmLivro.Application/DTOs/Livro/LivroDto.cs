namespace QuerUmLivro.Application.DTOs.Livro
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public bool Disponivel { get; set; }
    }
}
