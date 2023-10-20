namespace QuerUmLivro.Domain.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public bool Disponivel { get; set; }
    }
}
