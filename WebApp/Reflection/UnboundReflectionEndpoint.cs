using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApp.Reflection;

public static class UnboundReflectionEndpoint
{
    private static readonly string Namespace = "WebApp.Reflection";
    
    public static WebApplication MapUnboundReflectionEndpoint(this WebApplication app)
    {
        app.MapGet("/api/reflection/unbound", GetUnboundReflectionData);
        return app;
    }

    private static IResult GetUnboundReflectionData()
    {
        var typeName = $"{Namespace}.Calculator";
        var type = Type.GetType(typeName);
        if (type is null)
        {
            return Results.NotFound();
        }

        var addMethod = type.GetMethod("Add", BindingFlags.Public | BindingFlags.Static);
        if (addMethod is null)
        {
            return Results.NotFound();
        }

        var result = addMethod.Invoke(null, [40, 2]);
        return Results.Ok(result);
    }
}