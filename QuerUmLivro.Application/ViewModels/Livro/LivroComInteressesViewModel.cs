using QuerUmLivro.Application.ViewModels.Interesse;

namespace QuerUmLivro.Application.ViewModels.Livro
{
    public class LivroComInteressesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DoadorId { get; set; }
        public bool Disponivel { get; set; }
        public ICollection<InteresseViewModel> Interesses { get; set; }
    }
}
