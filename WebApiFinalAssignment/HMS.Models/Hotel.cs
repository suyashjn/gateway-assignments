using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Models
{
    public class Hotel
    {
        public int? Id { get; set; }
        [MaxLength(100)] [Required] public string HotelName { get; set; }
        [MaxLength(300)] [Required] public string Address { get; set; }
        [MaxLength(50)] [Required] public string City { get; set; }
        public int PinCode { get; set; }
        [MaxLength(50)] [Required] public string ContactPerson { get; set; }
        [MaxLength(50)] 
        [RegularExpression(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}98(\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$")]
        [Required] 
        public string ContactNumber { get; set; }
        [MaxLength(300)] public string Website { get; set; }
        [MaxLength(300)] public string Facebook { get; set; }
        [MaxLength(300)] public string Twitter { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)] [Required] public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(50)] public string UpdatedBy { get; set; }
    }
}