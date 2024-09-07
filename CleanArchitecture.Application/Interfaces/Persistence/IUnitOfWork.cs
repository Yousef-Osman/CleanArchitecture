namespace CleanArchitecture.Application.Interfaces.Persistence;
public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}
