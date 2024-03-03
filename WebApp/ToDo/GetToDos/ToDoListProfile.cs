using AutoMapper;
using WebApp.DatabaseAccess.Model;

namespace WebApp.ToDo.GetToDos;

public sealed class ToDoListProfile : Profile
{
    public ToDoListProfile()
    {
        CreateMap<ToDoItem, ToDoListDto>();
    }
}