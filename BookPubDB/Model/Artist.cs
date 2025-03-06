namespace BookPubDB.Model;

public class Artist : IItem
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Cover> Covers { get; set; } = [];
}