using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.DAL.Database
{
    public class Booking
    {
        [Key] public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomId { get; set; }
        public byte BookingStatus { get; set; }
    }
}