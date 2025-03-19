using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model.Identity
{
    /// <include file='Documentation/Model/Identity/User.xml' path='doc/user/member[@name="T:BookPubDB.Model.Identity.User"]' />
    public class User : IItem
    {
        /// <include file='Documentation/Model/Identity/User.xml' path='doc/user/member[@name="P:BookPubDB.Model.Identity.User.Id"]' />
        public int Id { get; set; }

        /// <include file='Documentation/Model/Identity/User.xml' path='doc/user/member[@name="P:BookPubDB.Model.Identity.User.Email"]' />
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <include file='Documentation/Model/Identity/User.xml' path='doc/user/member[@name="P:BookPubDB.Model.Identity.User.Password"]' />
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;

        /// <include file='Documentation/Model/Identity/User.xml' path='doc/user/member[@name="P:BookPubDB.Model.Identity.User.Username"]' />
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = null!;
    }
}