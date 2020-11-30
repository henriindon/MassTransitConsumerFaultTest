using MassTransit;
using MassTransitPubSubSender;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MassTransitConsumerFaultTest.Consumers
{
    public class HelloWorldFaultConsumer : IConsumer<Fault<HelloWorldModel>>
    {

        public Task Consume(ConsumeContext<Fault<HelloWorldModel>> context)
        {
            return Task.CompletedTask;
        }
    }
}