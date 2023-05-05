using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQ.MessagePublisher.Services
{
       public interface IMessageBrokerService
    {
        Task SendMessage<T>(string queueName, T message, string exchange = "");
    }

    public class MessageBrokerService : IMessageBrokerService
    {
        private readonly IMessageBrokerConnectionService messageBrokerConnection;

        public MessageBrokerService(IMessageBrokerConnectionService messageBrokerConnection)
        {
            this.messageBrokerConnection = messageBrokerConnection;
        }
        public Task SendMessage<T>(string queueName, T message, string exchange = "")
        {
            using var connection = messageBrokerConnection.CreateChannel();
            using var model = connection.CreateModel();
            model.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            model.BasicPublish(exchange: exchange,
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);

            return Task.FromResult("Ok");
        }
    }
}