using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IAuthorRepository:IEntityRepository<Author>
{
    Task<List<Author>> GetAllAuthorsByBook(int id);
}