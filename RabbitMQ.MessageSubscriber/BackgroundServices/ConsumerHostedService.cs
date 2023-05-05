using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.MessageSubscriber.Helper;
using RabbitMQ.MessageSubscriber.Services;

namespace RabbitMQ.MessageSubscriber.BackgroundServices
{
    public class ConsumerHostedService:BackgroundService
    {
       private IMessageBrokerConnectionService _RabbitConnectionService;

        public ConsumerHostedService(IMessageBrokerConnectionService rabbitConnectionService)
        {
            _RabbitConnectionService = rabbitConnectionService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var QueueName = "rabbit-test";
            var connection = _RabbitConnectionService.CreateChannel();
            using (var model = connection.CreateModel())
            {
          
         var consumer= model.GetEventingBasicConsumer(QueueName,false,false,false);




                 consumer.Received += async (model, ea) =>
                {
                    IDictionary<string, object> headers = ea.BasicProperties.Headers; // get headers from Received msg

                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    //call another service
                };

               

                model.BasicConsume(QueueName,false, consumer);
                Console.WriteLine("Waiting for feedback. Press [enter] to exit.");
                Console.ReadLine();

            }
        }
        
    }
}