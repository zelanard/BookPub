using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model.Identity
{
    public class LoginUser : IItem
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}