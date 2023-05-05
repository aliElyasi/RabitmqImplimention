using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.MessagePublisher.Models;

namespace RabbitMQ.MessagePublisher.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestRabbitController : ControllerBase
    {

         private readonly IMessageBrokerService messageBrokerService;

        public TestRabbitController(IMessageBrokerService messageBrokerService)
        {
            this.messageBrokerService = messageBrokerService;
        }
        [HttpGet("{count}")]
        public async Task<IActionResult> SendMessage(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                var message = new TestRabbitData
                {
                    message="hello world"
              
                };
                string queueName = "order-queue";
             await messageBrokerService.SendMessage(queueName, message);
            }

            return Ok();
        }
        
    }
}