namespace QuerUmLivro.Domain.Entities
{
    public class Livro : Entidade
    {        
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public bool Disponivel { get; set; }        
    }
}
