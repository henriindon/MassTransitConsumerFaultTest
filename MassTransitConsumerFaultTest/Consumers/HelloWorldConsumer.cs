using System;
using MassTransit;
using MassTransitPubSubSender;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MassTransitConsumerFaultTest.Consumers
{
    public class HelloWorldConsumer : IConsumer<HelloWorldModel>
    {

        public Task Consume(ConsumeContext<HelloWorldModel> context)
        {
            throw new Exception("Hallo World Error");
            return Task.CompletedTask;
        }
    }
}