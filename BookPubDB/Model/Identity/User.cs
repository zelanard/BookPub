using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookPubDB.Model.Identity
{
    public class User : IItem
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = null!;

        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = null!;
    }
}