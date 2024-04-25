using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.ViewModels
{
    public class Login
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username must be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9_@.]*$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username must be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9_@.!#]*$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        [MinLength(2)]
        public string Password { get; set; }
    }
}
