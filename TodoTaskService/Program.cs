using Microsoft.EntityFrameworkCore;
using TodoTaskService.Data;
using TodoTaskService.Repositories;
using TodoTaskService.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITodoTaskRepo, TodoTaskRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    // Set the Swagger UI at the root
    c.RoutePrefix = "swagger";
});

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
PrepDB.PrepPopulation(app);
// Important: This will keep the application running
await app.RunAsync();
