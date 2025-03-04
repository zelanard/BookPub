namespace BookPubDB.Model;

public class Artist
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Cover> Covers { get; set; } = new();
}