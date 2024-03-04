using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace WebApp.Eventing;

public sealed class MyMessageConsumer : IConsumer<MyMessage>
{
    private readonly ILogger<MyMessageConsumer> _logger;

    public MyMessageConsumer(ILogger<MyMessageConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<MyMessage> context)
    {
        _logger.LogInformation("Received message {@Message}", context.Message);
        return Task.CompletedTask;
    }
}