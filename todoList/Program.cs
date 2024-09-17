using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using todoList.Models;
using todoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ITaskService, TaskService>();

// Entity Framework
builder.Services.AddDbContext<TodoContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("TodosConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
