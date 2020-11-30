using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace MassTransitConsumerFaultTest.Consumers
{
    public class HelloWorldConsumerDefinition :
        ConsumerDefinition<HelloWorldConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<HelloWorldConsumer> consumerConfigurator)
        {
            //endpointConfigurator.UseScheduledRedelivery(r => r.Intervals(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(15)));
            endpointConfigurator.UseMessageRetry(r => r.Interval(1, 5000));

        }
    }
}