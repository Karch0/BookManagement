namespace BookManagement.Services.Dtos.PublisherDTO;

public class PublisherDTO : PublisherBaseDTO
{
    public int PublisherID { get; set; }
    public List<int> BookIds { get; set; } 
}
