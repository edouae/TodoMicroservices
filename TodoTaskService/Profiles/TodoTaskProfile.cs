using AutoMapper;
using TodoTaskService.DTOs;
using TodoTaskService.Models;

namespace TodoTaskService.Profiles
{
    public class TodoTaskProfile : Profile
    {
        public TodoTaskProfile() 
        {
            CreateMap<TodoTaskCreateDTO, TodoTask>();
            CreateMap<TodoTask, TodoTaskReadDTO>();
        }
    }
}
