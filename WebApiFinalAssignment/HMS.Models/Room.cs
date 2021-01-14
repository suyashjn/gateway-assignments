using System;

namespace HMS.Models
{
    public enum RoomCategory
    {
        Category1,
        Category2,
        Category3
    }

    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public decimal RoomPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public int HotelId { get; set; }
    }
}