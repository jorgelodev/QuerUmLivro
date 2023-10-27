namespace QuerUmLivro.Application.ViewModels.Livro
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DoadorId { get; set; }
        public bool Disponivel { get; set; }
    }
}
