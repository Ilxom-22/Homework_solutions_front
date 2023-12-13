using AutoMapper;
using Todo.Api.Dtos.Models;
using Todo.Domain.Entities;

namespace ToDo.Api.Mappers;

public class TodoMapper : Profile
{
    public TodoMapper()
    {
        CreateMap<TodoItem, TodoDto>().ReverseMap();
    }
}