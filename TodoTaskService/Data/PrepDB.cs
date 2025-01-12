using System.Reflection;
using TodoTaskService.Models;

namespace TodoTaskService.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope() )
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.TodoTasks.Any())
            {
                Console.WriteLine("seeding data");
                context.TodoTasks.AddRange(
                   new TodoTask() { Title = "study", Status = "done" },
                   new TodoTask() { Title = "go gym", Status = "pending" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("we already have data");
            }
        }
    }
}
