using System.ComponentModel.DataAnnotations;

namespace PMT.Data.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Phone] [Required] public string MobileNo { get; set; }
    }
}
