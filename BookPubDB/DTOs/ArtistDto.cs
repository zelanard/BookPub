namespace BookPubDB.DTOs
{
    /// <include file='Documentation/DTOs/ArtistDto.xml' path='doc/artistdto/member[@name="T:BookPubDB.DTOs.ArtistDto"]' />
    public class ArtistDto
    {
        /// <include file='Documentation/DTOs/ArtistDto.xml' path='doc/artistdto/member[@name="P:BookPubDB.DTOs.ArtistDto.FirstName"]' />
        public string FirstName { get; set; } = null!;
        
        /// <include file='Documentation/DTOs/ArtistDto.xml' path='doc/artistdto/member[@name="P:BookPubDB.DTOs.ArtistDto.LastName"]' />
        public string LastName { get; set; } = null!;
    }
}