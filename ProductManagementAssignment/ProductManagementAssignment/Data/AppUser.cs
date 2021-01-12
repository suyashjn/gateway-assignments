using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data
{
    public class AppUser
    {
        [Key] public int Id { get; set; }

        [Required] [MaxLength(30)] public string UserName { get; set; }

        [Required] [MaxLength(254)] public string Email { get; set; }

        [Required] public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<Product> Products { get; set; }
    }
}