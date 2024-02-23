namespace GamesUp.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}