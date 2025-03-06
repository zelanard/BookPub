namespace BookPubDB.Model;
public class Cover : IItem
{
    public int Id { get; set; }
    public string DesignIdeas { get; set; } = null!;
    public bool DigitalOnly { get; set; }
    public List<Artist> Artists { get; set; } = [];
    public Book Book { get; set; } = null!;
    public int BookId { get; set; }
}