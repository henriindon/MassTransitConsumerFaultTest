using System;
using GreenPipes;
using MassTransit;
using MassTransitConsumerFaultTest.Consumers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MassTransitConsumerFaultTest.Startup))]
namespace MassTransitConsumerFaultTest
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddScoped<Function1>()
                .AddMassTransitForAzureFunctions(cfg =>
                    {
                        cfg.AddConsumer<HelloWorldConsumer>(typeof(HelloWorldConsumerDefinition));
                        cfg.AddConsumer<HelloWorldFaultConsumer>();
                    }
                    ,
                    (busContext, busConfig) =>
                    {
                        busConfig.ReceiveEndpoint("FunctionQueue", configurator =>
                        {
                            configurator.Consumer<HelloWorldConsumer>();
                            configurator.Consumer<HelloWorldFaultConsumer>();
                        });
                    }
                );
        }
    }
}
