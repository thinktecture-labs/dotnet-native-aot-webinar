using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApp.Eventing;

public static class ProduceEventEndpoint
{
    private static int _counter;

    public static WebApplication MapProduceEventEndpoint(this WebApplication app)
    {
        app.MapPost("/api/produce-event", ProduceEvent);
        return app;
    }

    public static async Task<IResult> ProduceEvent(
        IPublishEndpoint publishEndpoint,
        CancellationToken cancellationToken = default
    )
    {
        var nextValue = Interlocked.Increment(ref _counter);
        await publishEndpoint.Publish(new MyMessage(nextValue), cancellationToken);
        return Results.Ok();
    }
}