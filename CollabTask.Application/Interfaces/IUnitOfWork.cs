using CollabTask.Domain.Entities;

namespace CollabTask.Application;

public interface IUnitOfWork : IDisposable
{
    IProjectRepository Projects { get; }
    ITodoTaskRepository TodoTasks { get; }

    Task<int> CompleteAsync();
}
