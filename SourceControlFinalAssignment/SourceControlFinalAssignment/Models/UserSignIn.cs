using System.ComponentModel.DataAnnotations;

namespace SourceControlFinalAssignment.Models
{
    public class UserSignIn
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is required")]
        [EmailAddress(ErrorMessage = "The Email is not a valid e-mail address.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must of minimum 8 characters")]
        public string Password { get; set; }
    }
}
