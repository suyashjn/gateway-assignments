using System;

namespace HMS.Models
{
    public enum BookingStatus
    {
        Optional,
        Definitive,
        Cancelled,
        Deleted
    }

    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomId { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}