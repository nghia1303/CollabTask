using CollabTask.Application;
using CollabTask.Infrastructure;
using CollabTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Infrastructure (DbContext + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);

// 2. Add OpenAPI (if needed)
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// 3. Configure middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Example endpoint
app.MapGet("/", () => "CollabTask API is running");

app.Run();

