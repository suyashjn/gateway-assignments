using System.ComponentModel.DataAnnotations;

namespace PMT.Core.Dto
{
    public class PassengerDto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)] public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)] public string LastName { get; set; }
        [Phone] [Required(AllowEmptyStrings = false)] public string MobileNo { get; set; }
    }
}
