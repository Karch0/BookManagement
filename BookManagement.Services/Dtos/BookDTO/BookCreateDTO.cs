using BookManagement.Core.Models;

namespace BookManagement.Services.Dtos.BookDTO;

public class BookCreateDTO : BookBaseDTO
{
    public List<int> AuthorIds { get; set; }
}