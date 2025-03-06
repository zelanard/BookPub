using BookPubDB.Model;

namespace BookPubDB.DTOs
{
    public class CoverDto
    {
        public string DesignIdeas { get; set; } = null!;
        public bool DigitalOnly { get; set; }
        public List<int> Artists { get; set; } = [];
        public int BookId { get; set; }
    }
}