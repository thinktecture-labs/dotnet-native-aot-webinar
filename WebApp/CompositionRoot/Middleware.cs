using Microsoft.AspNetCore.Builder;
using Serilog;
using WebApp.Contacts;
using WebApp.Eventing;
using WebApp.Reflection;
using WebApp.ToDo;

namespace WebApp.CompositionRoot;

public static class Middleware
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseRouting();
        app.MapReflectionEndpoint()
           .MapUnboundReflectionEndpoint()
           .MapToDoEndpoints()
           .MapContactEndpoints()
           .MapProduceEventEndpoint();
        app.MapHealthChecks("/");
        return app;
    }
}