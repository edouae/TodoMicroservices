using TodoTaskService.Data;
using TodoTaskService.Models;
using TodoTaskService.Repositories.IRepositories;

namespace TodoTaskService.Repositories
{
    public class TodoTaskRepo : ITodoTaskRepo
    {
        private readonly AppDbContext context;
        public TodoTaskRepo(AppDbContext context) 
        { 
            this.context = context;
        }
        public void CreateTodoTask(TodoTask todoTask)
        {
            if (todoTask == null)
            {
                throw new ArgumentNullException(nameof(todoTask));
            }
            context.TodoTasks.Add(todoTask);
        }

        public IEnumerable<TodoTask> GetAllTodoTasks()
        {
          return context.TodoTasks.ToList();
        }

        public TodoTask GetTodoTaskById(int id)
        {
            return context.TodoTasks.FirstOrDefault(t => t.Id == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
