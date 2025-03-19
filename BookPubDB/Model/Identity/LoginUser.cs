using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model.Identity
{
    /// <include file='Documentation/Model/Identity/LoginUser.xml' path='doc/loginuser/member[@name="T:BookPubDB.Model.Identity.LoginUser"]' />
    public class LoginUser : IItem
    {
        /// <include file='Documentation/Model/Identity/LoginUser.xml' path='doc/loginuser/member[@name="P:BookPubDB.Model.Identity.LoginUser.Id"]' />
        public int Id { get; set; }

        /// <include file='Documentation/Model/Identity/LoginUser.xml' path='doc/loginuser/member[@name="P:BookPubDB.Model.Identity.LoginUser.Login"]' />
        [Required]
        public string Login { get; set; } = null!;

        /// <include file='Documentation/Model/Identity/LoginUser.xml' path='doc/loginuser/member[@name="P:BookPubDB.Model.Identity.LoginUser.Password"]' />
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}