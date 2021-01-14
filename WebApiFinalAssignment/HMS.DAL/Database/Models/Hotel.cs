using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS.DAL.Database
{
    public class Hotel
    {
        [Key] public int Id { get; set; }
        [MaxLength(100)] [Required] public string HotelName { get; set; }
        [MaxLength(300)] [Required] public string Address { get; set; }
        [MaxLength(50)] [Required] public string City { get; set; }
        public int PinCode { get; set; }
        [MaxLength(50)] [Required] public string ContactPerson { get; set; }
        [MaxLength(50)] [Required] public string ContactNumber { get; set; }
        [MaxLength(300)] public string Website { get; set; }
        [MaxLength(300)] public string Facebook { get; set; }
        [MaxLength(300)] public string Twitter { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)] [Required] public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(50)] public string UpdatedBy { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}