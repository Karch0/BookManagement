namespace BookManagement.Services.Dtos.AuthorDTO;

public class AuthorDTO : AuthorBaseDTO
{
    public int AuthorID { get; set; }
    public List<int> BookIds { get; set; }
}