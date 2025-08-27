namespace BookManagement.Core.Repositories;

public interface IEntityRepository<T> where T : class
{
    Task<T> Create(T model);
    Task<T> GetById(int id);
    Task<List<T>> GetAll();
    Task<T> Update(T model);
    Task Delete(int id);


}