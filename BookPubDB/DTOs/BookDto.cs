namespace BookPubDB.DTOs;

/// <include file='Documentation/DTOs/BookDto.xml' path='doc/bookdto/member[@name="T:BookPubDB.DTOs.BookDto"]' />
public class BookDto
{
    /// <include file='Documentation/DTOs/BookDto.xml' path='doc/bookdto/member[@name="P:BookPubDB.DTOs.BookDto.Title"]' />
    public string Title { get; set; } = null!;

    /// <include file='Documentation/DTOs/BookDto.xml' path='doc/bookdto/member[@name="P:BookPubDB.DTOs.BookDto.PublishDate"]' />
    public DateOnly PublishDate { get; set; }

    /// <include file='Documentation/DTOs/BookDto.xml' path='doc/bookdto/member[@name="P:BookPubDB.DTOs.BookDto.BasePrice"]' />
    public decimal BasePrice { get; set; }

    /// <include file='Documentation/DTOs/BookDto.xml' path='doc/bookdto/member[@name="P:BookPubDB.DTOs.BookDto.AuthorId"]' />
    public int AuthorId { get; set; }
}