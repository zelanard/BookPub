using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model;

/// <include file='Documentation/Model/Author.xml' path='doc/author/member[@name="T:BookPubDB.Model.Author"]' />
public class Author : IItem
{
    /// <include file='Documentation/Model/Author.xml' path='doc/author/member[@name="P:BookPubDB.Model.Author.Id"]' />
    public int Id { get; set; }

    /// <include file='Documentation/Model/Author.xml' path='doc/author/member[@name="P:BookPubDB.Model.Author.FirstName"]' />
    public string FirstName { get; set; } = null!;

    /// <include file='Documentation/Model/Author.xml' path='doc/author/member[@name="P:BookPubDB.Model.Author.LastName"]' />
    public string LastName { get; set; } = null!;

    /// <include file='Documentation/Model/Author.xml' path='doc/author/member[@name="P:BookPubDB.Model.Author.Books"]' />
    public List<Book> Books { get; set; } = [];
}
