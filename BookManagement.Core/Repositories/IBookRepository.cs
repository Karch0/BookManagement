using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IBookRepository:IEntityRepository<Book>
{
    Task<List<Book>> GetBooksByAuthorWithPublisher(int id);
    Task<List<Book>> GetBooksByPublisher(int id);
}