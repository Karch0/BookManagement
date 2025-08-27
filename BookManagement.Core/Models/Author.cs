using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Core.Models;

public class Author
{
    [Key]
    public int AuthorID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }


    public Author(int id, string firstName, string lastName, DateTime birth, string biography)
    {
        AuthorID = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = birth;
        Biography = biography; 
    }

    public Author()
    {
        
    }
}
    
    