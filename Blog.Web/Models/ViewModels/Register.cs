using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels
{
    public class Register
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username must be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string Username {  get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Username must be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(50, ErrorMessage = "Username must be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string Password { get; set; }
    }
}
