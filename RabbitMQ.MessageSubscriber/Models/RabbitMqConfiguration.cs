using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.MessageSubscriber.Models
{
    public class RabbitMqConfiguration
    {
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}