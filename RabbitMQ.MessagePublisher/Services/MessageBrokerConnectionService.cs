using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.MessagePublisher.Models;
namespace RabbitMQ.MessagePublisher.Services
{
    public interface IMessageBrokerConnectionService
    {
        IConnection CreateChannel();
    }

    public class MessageBrokerConnectionService : IMessageBrokerConnectionService
    {
        private readonly RabbitMqConfiguration _configuration;
        public MessageBrokerConnectionService(IOptions<RabbitMqConfiguration> options)
        {
            _configuration = options.Value;
        }
        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _configuration.Username,
                Password = _configuration.Password,
                HostName = _configuration.HostName
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}