using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using WebApp.JsonAccess;

namespace WebApp.Eventing;

public static class EventingModule
{
    public static IServiceCollection AddEventing(this IServiceCollection services) =>
        services.AddMassTransit(
            x =>
            {
                x.AddConsumer<MyMessageConsumer>();
                x.UsingRabbitMq(
                    (context, configurator) =>
                    {
                        configurator.ConfigureJsonSerializerOptions(
                            options =>
                            {
                                options.TypeInfoResolverChain.Insert(0, AppJsonSerializationContext.Default);
                                return options;
                            });
                        configurator.Host(
                            "localhost",
                            5672,
                            "/",
                            h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            }
                        );
                        configurator.ConfigureEndpoints(context);
                    }
                );
            }
        );
}