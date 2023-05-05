using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.MessageSubscriber.Helper
{
    public static class RabbitMqHelper
    {
        public static  EventingBasicConsumer GetEventingBasicConsumer(this IModel? model, string queueName, bool durable,
                                   bool exclusive,
                                   bool autoDelete,
                                   IDictionary<string, object> arguments = null)
        {

             
      

      model.QueueDeclare(queueName,
                         durable,
                         exclusive,
                         autoDelete,
                         null);

            var consumer = new EventingBasicConsumer(model);
            return consumer;

        }
    }
}