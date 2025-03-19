using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model;

/// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="T:BookPubDB.Model.Book"]' />
public class Book : IItem
{
    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.Id"]' />
    public int Id { get; set; }

    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.Title"]' />
    public string Title { get; set; } = null!;

    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.PublishDate"]' />
    public DateOnly PublishDate { get; set; }

    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.BasePrice"]' />
    public decimal BasePrice { get; set; }

    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.Author"]' />
    public Author Author { get; set; } = null!;

    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.AuthorId"]' />
    public int AuthorId { get; set; }

    /// <include file='Documentation/Model/Book.xml' path='doc/book/member[@name="P:BookPubDB.Model.Book.Cover"]' />
    public Cover Cover { get; set; } = null!;
}
