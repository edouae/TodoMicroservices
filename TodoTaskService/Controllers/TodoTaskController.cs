using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoTaskService.DTOs;
using TodoTaskService.Models;
using TodoTaskService.Repositories.IRepositories;


namespace TodoTaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskRepo repo;
        private readonly IMapper mapper;

        public TodoTaskController(ITodoTaskRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TodoTaskReadDTO>> GetAllTodoTasks()
        {
            IEnumerable<TodoTask> TodoTasks = repo.GetAllTodoTasks();
            return Ok(mapper.Map<IEnumerable<TodoTaskReadDTO>>(TodoTasks));
        }

        [HttpGet("{id}")]
        public ActionResult<TodoTaskReadDTO> GetTodoTaskById(int id)
        {
            TodoTask todoTask = repo.GetTodoTaskById(id);
            if (todoTask == null) { return NotFound(); }
            return Ok(mapper.Map<TodoTaskReadDTO>(todoTask));
        }

        [HttpPost]
        public ActionResult<TodoTaskReadDTO> CreateTodoTask(TodoTaskCreateDTO todoTaskCreate)
        {
            TodoTask todoTask = mapper.Map<TodoTask>(todoTaskCreate);
            repo.CreateTodoTask(todoTask);
            repo.SaveChanges();
            TodoTaskReadDTO todoTaskRead = mapper.Map<TodoTaskReadDTO>(todoTask);
            return CreatedAtAction(nameof(GetTodoTaskById), new { Id = todoTask.Id }, todoTaskRead);
        }
    }
}
