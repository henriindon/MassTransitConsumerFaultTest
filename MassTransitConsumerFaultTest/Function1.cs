using System.Threading;
using System.Threading.Tasks;
using MassTransit.WebJobs.ServiceBusIntegration;
using MassTransitConsumerFaultTest.Consumers;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MassTransitConsumerFaultTest
{
    public class Function1
    {
        private readonly IMessageReceiver _receiver;

        public Function1(IMessageReceiver receiver)
        {
            _receiver = receiver;
        }

        [FunctionName("Function1")]
        public Task RunAsync([ServiceBusTrigger("FunctionQueue")] Message message, CancellationToken cancellationToken, ILogger log)
        {
            return _receiver.HandleConsumer<HelloWorldConsumer>("FunctionQueue", message, cancellationToken);
        }
    }
}
