using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required] [MaxLength(30)] public string Name { get; set; }

        [Required] [MaxLength(30)] public string Category { get; set; }

        [Column(TypeName = "Money")] public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required] [MaxLength(100)] public string ShortDescription { get; set; }

        [Required] public string LongDescription { get; set; }

        [Required] [MaxLength(300)] public string SmallImagePath { get; set; }

        [Required] [MaxLength(300)] public string LargeImagePath { get; set; }

        public int UserId { get; set; }

        public AppUser User { get; set; }
    }
}