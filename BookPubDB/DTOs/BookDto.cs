using BookPubDB.Model;

namespace BookPubDB.DTOs;

public class BookDto
{
    public string Title { get; set; } = null!;
    public DateOnly PublishDate { get; set; }
    public decimal BasePrice { get; set; }
    public int AuthorId { get; set; }
}