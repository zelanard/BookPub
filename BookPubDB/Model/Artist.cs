namespace BookPubDB.Model;

/// <include file='Documentation/Model/Artist.xml' path='doc/artist/member[@name="T:BookPubDB.Model.Artist"]' />
public class Artist : IItem
{
    /// <include file='Documentation/Model/Artist.xml' path='doc/artist/member[@name="P:BookPubDB.Model.Artist.Id"]' />
    public int Id { get; set; }

    /// <include file='Documentation/Model/Artist.xml' path='doc/artist/member[@name="P:BookPubDB.Model.Artist.FirstName"]' />
    public string FirstName { get; set; } = null!;

    /// <include file='Documentation/Model/Artist.xml' path='doc/artist/member[@name="P:BookPubDB.Model.Artist.LastName"]' />
    public string LastName { get; set; } = null!;

    /// <include file='Documentation/Model/Artist.xml' path='doc/artist/member[@name="P:BookPubDB.Model.Artist.Covers"]' />
    public List<Cover> Covers { get; set; } = [];
}