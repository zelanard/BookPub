namespace BookPubDB.DTOs
{
    /// <include file='Documentation/DTOs/CoverDto.xml' path='doc/coverdto/member[@name="T:BookPubDB.DTOs.CoverDto"]' />
    public class CoverDto
    {
        /// <include file='Documentation/DTOs/CoverDto.xml' path='doc/coverdto/member[@name="P:BookPubDB.DTOs.CoverDto.DesignIdeas"]' />
        public string DesignIdeas { get; set; } = null!;

        /// <include file='Documentation/DTOs/CoverDto.xml' path='doc/coverdto/member[@name="P:BookPubDB.DTOs.CoverDto.DigitalOnly"]' />
        public bool DigitalOnly { get; set; }

        /// <include file='Documentation/DTOs/CoverDto.xml' path='doc/coverdto/member[@name="P:BookPubDB.DTOs.CoverDto.Artists"]' />
        public List<int> Artists { get; set; } = [];

        /// <include file='Documentation/DTOs/CoverDto.xml' path='doc/coverdto/member[@name="P:BookPubDB.DTOs.CoverDto.BookId"]' />
        public int BookId { get; set; }
    }
}