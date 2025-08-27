using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IPublisherRepository:IEntityRepository<Publisher>
{
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
}