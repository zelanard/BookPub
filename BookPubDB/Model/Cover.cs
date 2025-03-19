namespace BookPubDB.Model;

public class Cover : IItem
{
    /// <include file='Documentation/Model/Cover.xml' path='doc/cover/member[@name="P:BookPubDB.Model.Cover.Id"]' />
    public int Id { get; set; }

    /// <include file='Documentation/Model/Cover.xml' path='doc/cover/member[@name="P:BookPubDB.Model.Cover.DesignIdeas"]' />
    public string DesignIdeas { get; set; } = null!;

    /// <include file='Documentation/Model/Cover.xml' path='doc/cover/member[@name="P:BookPubDB.Model.Cover.DigitalOnly"]' />
    public bool DigitalOnly { get; set; }

    /// <include file='Documentation/Model/Cover.xml' path='doc/cover/member[@name="P:BookPubDB.Model.Cover.Artists"]' />
    public List<Artist> Artists { get; set; } = [];

    /// <include file='Documentation/Model/Cover.xml' path='doc/cover/member[@name="P:BookPubDB.Model.Cover.Book"]' />
    public Book Book { get; set; } = null!;

    /// <include file='Documentation/Model/Cover.xml' path='doc/cover/member[@name="P:BookPubDB.Model.Cover.BookId"]' />
    public int BookId { get; set; }
}
