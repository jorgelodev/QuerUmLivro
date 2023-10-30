using QuerUmLivro.Application.DTOs.Interesse;
using QuerUmLivro.Application.ViewModels.Interesse;

namespace QuerUmLivro.Application.Interfaces
{
    public interface IInteresseAppService
    {     
        InteresseDto ManifestarInteresse(InteresseDto interesseDto);
        AprovarInteresseDto AprovarInteresse(AprovarInteresseDto aprovarInteresseDto);      
    }
}
