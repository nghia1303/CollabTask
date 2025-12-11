using CollabTask.Application;
using CollabTask.Infrastructure;
using CollabTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext + Repository
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
builder.Services.AddScoped<ITodoTaskService, TodoTaskService>();

// Đăng ký Controllers (rất quan trọng nếu bạn dùng Controller)
builder.Services.AddControllers();

// Đăng ký Swagger (Swashbuckle)
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Map Controllers
app.MapControllers();

// Endpoint test
app.MapGet("/", () => "CollabTask API is running");

app.Run();
