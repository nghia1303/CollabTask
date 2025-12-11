using CollabTask.Application;
using CollabTask.Domain.Entities;
using CollabTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollabTask.Infrastructure;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly ApplicationDbContext _context;

    public TodoTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TodoTask todoTask)
    {
        await _context.AddAsync(todoTask);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TodoTask todoTask)
    {
        _context.TodoTasks.Remove(todoTask);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoTask>> GetAllAsync()
    {
        return await _context.TodoTasks.ToListAsync();
    }

    public async Task<TodoTask?> GetByIdAsync(Guid id)
    {
        return await _context.TodoTasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(TodoTask todoTask)
    {
        _context.TodoTasks.Update(todoTask);
        await _context.SaveChangesAsync();
    }
}
