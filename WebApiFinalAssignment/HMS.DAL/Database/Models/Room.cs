using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.DAL.Database
{
    public class Room
    {
        [Key] public int Id { get; set; }
        [MaxLength(50)] [Required] public string RoomName { get; set; }
        public byte RoomCategory { get; set; }
        public decimal RoomPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)] [Required] public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(50)] public string UpdatedBy { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}