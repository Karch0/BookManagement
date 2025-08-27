namespace BookManagement.Services.Dtos.BookDTO;

public class BookBaseDTO
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishDate { get; set; }
    public int PublisherID { get; set; }
}