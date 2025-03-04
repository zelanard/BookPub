using BookPubDB.Model;
using Newtonsoft.Json;

namespace BookPubDB.DTOs;

public class BookDto
{
    public string Title { get; set; } = null!;
    public DateOnly PublishDate { get; set; }
    public decimal BasePrice { get; set; }
    public int AuthorId { get; set; }
    //public Cover Cover { get; set; }
}