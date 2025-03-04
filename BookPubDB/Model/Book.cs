using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateOnly PublishDate { get; set; }
    public decimal BasePrice { get; set; }
    public Author Author { get; set; } = null!;
    public int AuthorId { get; set; }
    //public Cover Cover { get; set; }
}