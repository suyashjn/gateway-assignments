using System.Collections.Generic;

namespace SBS.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public bool Active { get; set; }

        public virtual List<AppointBooking> AppointBookings { get; set; }
    }
}
