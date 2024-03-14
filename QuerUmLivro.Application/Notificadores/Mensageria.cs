using Microsoft.Extensions.Configuration;
using QuerUmLivro.Domain.Entities;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;


namespace QuerUmLivro.Application.Notificadores
{
    public class Mensageria : INotificador
    {        
        private readonly IConfiguration _configuration;

        private readonly ConnectionFactory _factory;
        public Mensageria(IConfiguration configuration)
        {            
            _configuration = configuration;

            _factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("BrokerConfig")["Servidor"] ?? string.Empty,
                UserName = _configuration.GetSection("BrokerConfig")["Usuario"] ?? string.Empty,
                Password = _configuration.GetSection("BrokerConfig")["Senha"] ?? string.Empty
            };

        }
        public async void NotificaManifestarInteresse(Interesse interesse)
        {
            interesse.Interessado.Interesses = null;
            interesse.Livro.Interesses = null;
            interesse.Livro.Doador.Livros = null;
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "filaEmail",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var message = JsonSerializer.Serialize(interesse);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "filaEmail",
                        basicProperties: null,
                        body: body);

                }
                
            }            
        }
    }
}
