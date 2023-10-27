﻿namespace QuerUmLivro.Domain.Entities
{
    public class Livro : Entidade
    {        
        public string Nome { get; set; }
        public int DoadorId { get; set; }
        public bool Disponivel { get; set; }

        public ICollection<Interesse> Interesses { get; set; }

    }
}