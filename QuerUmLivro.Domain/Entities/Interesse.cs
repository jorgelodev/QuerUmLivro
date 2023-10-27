﻿namespace QuerUmLivro.Domain.Entities
{
    public class Interesse : Entidade
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int InteressadoId { get; set; }
        public string Justificativa { get; set; }
        public bool Aprovado { get; set; }
        public DateTime Data { get; set; }
    }
}
