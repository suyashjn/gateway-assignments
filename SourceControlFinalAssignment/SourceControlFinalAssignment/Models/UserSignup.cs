using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SourceControlFinalAssignment.CustomValidation;

namespace SourceControlFinalAssignment.Models
{
    public class UserSignUp
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "File is required")]
        [CustomFileExtValidation("jpg png jpeg", ErrorMessage = "Only image can be used here")]
        public IFormFile UserImage { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [Phone]
        [StringLength(42)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is required")]
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage = "The Email is not a valid e-mail address.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must have at least one letter, one number and one special character")]
        [MinLength(8, ErrorMessage = "Password must of minimum 8 characters")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password should match with Password")]
        public string ConfirmPassword { get; set; }
    }
}
