
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.MessageSubscriber.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace RabbitMQ.MessageSubscriber.Services
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



        IConnection IMessageBrokerConnectionService.CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _configuration.Username,
                Password = _configuration.Password,
                HostName = _configuration.HostName
            };
            // connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;

        }
    }
}