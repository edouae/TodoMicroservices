using TodoTaskService.Models;

namespace TodoTaskService.Repositories.IRepositories
{
    public interface ITodoTaskRepo
    {
        IEnumerable<TodoTask> GetAllTodoTasks();
        TodoTask GetTodoTaskById(int id);
        void CreateTodoTask(TodoTask todoTask);
        bool SaveChanges();
    }
}
