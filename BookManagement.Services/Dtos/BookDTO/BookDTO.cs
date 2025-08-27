namespace BookManagement.Services.Dtos.BookDTO;

public class BookDTO : BookBaseDTO
{
    public int BookID { get; set; }
    public List<int> AuthorIds { get; set; }
}