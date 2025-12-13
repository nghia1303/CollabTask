using System.Security;
using CollabTask.Application;
using CollabTask.Domain.Entities;
using CollabTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollabTask.Infrastructure;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Project project)
    {
        await _context.AddAsync(project);
    }


    public async Task DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        return await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
    }

    // Thêm hàm này (và nhớ khai báo trong Interface IProjectRepository nhé)
    public async Task<Project?> GetByIdWithTasksAsync(Guid id)
    {
        return await _context.Projects
            .Include(p => p.Tasks) // <--- Eager Loading: Lấy luôn Task con
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
