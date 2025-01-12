using Microsoft.EntityFrameworkCore;
using TodoTaskService.Models;

namespace TodoTaskService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
