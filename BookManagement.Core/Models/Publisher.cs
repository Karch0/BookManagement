using System.ComponentModel.DataAnnotations;

namespace BookManagement.Core.Models;

public class Publisher
{
    [Key]
    public int PublisherID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public List<Book> Books;

    public Publisher(int id, string name, string addres)
    {
        PublisherID = id;
        Name = name;
        Address = addres;
    }

    public Publisher()
    {
        
    }
}

