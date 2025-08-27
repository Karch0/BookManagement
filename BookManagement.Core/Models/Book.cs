using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Core.Models;

public class Book
{
    [Key]
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishDate { get; set; }
    public int PublisherID { get; set; }

    [ForeignKey("PublisherID")]
    public Publisher Publisher { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; }

    public Book(int id, string title, string genre, DateTime publishDate, int publisherId)
    {
        BookID = id;
        Title = title;
        Genre = genre;
        PublishDate = publishDate;
        PublisherID = publisherId;
    }

    public Book()
    {
        
    }
}