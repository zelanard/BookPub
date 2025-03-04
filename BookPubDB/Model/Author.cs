using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model;

public class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public List<Book> Books { get; set; } = new();
}
