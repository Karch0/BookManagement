namespace BookManagement.Services.Dtos.BookDTO;

public class BookUpdateDTO : BookBaseDTO
{
    public int BookID { get; set; }
    public List<int> AuthorIds { get; set; }
}