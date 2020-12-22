using System.ComponentModel.DataAnnotations;

namespace SourceControlFinalAssignment.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        
        [Required]
        public string ImagePath { get; set; }

        [Required]
        [Phone]
        [StringLength(42)]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

    }
}
