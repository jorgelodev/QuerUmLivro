﻿using QuerUmLivro.Domain.Entities;

namespace QuerUmLivro.Domain.Interfaces.Services
{
    public interface IInteresseService
    {        
        Interesse ManifestarInteresse(Interesse interesse);
        Interesse AprovarInteresse(Interesse interesse, int IdDoador);

    }
}
