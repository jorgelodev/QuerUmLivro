using QuerUmLivro.Domain.Entities;


namespace QuerUmLivro.Application.Notificadores
{
    public interface INotificador
    {
        void NotificaManifestarInteresse(Interesse interesse);
    }
}
