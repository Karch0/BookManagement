using BookManagement.Services.Dtos.BookDTO;

namespace BookManagement.Services;

public interface IBookService
{
    Task<BookDTO> CreateAsync(BookCreateDTO dto);
    Task<BookDTO> UpdateAsync(BookUpdateDTO dto);
    Task<BookDTO> GetByIdAsync(int id);
    Task<List<BookDTO>> GetAllAsync();
    Task DeleteAsync(int id);
}