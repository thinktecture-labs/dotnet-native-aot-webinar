using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using WebApp.DatabaseAccess.Model;

namespace WebApp.ToDo.GetToDos;

public static class GetToDosEndpoint
{
    public static WebApplication MapGetToDos(this WebApplication app)
    {
        app.MapGet("/todos", GetToDos);
        return app;
    }

    public static async Task<IResult> GetToDos(
        IGetToDosSession session,
        IMapper mapper,
        CancellationToken cancellationToken = default
    )
    {
        var toDoList = await session.GetToDoListAsync(cancellationToken);
        var dtoList = mapper.Map<List<ToDoItem>, List<ToDoListDto>>(toDoList);
        return Results.Ok(dtoList);
    }
}