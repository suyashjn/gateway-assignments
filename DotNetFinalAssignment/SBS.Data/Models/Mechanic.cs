using System.Collections.Generic;

namespace SBS.Data.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Make { get; set; }
        public string Email { get; set; }
        public int DealerId { get; set; }

        public virtual List<AppointBooking> AppointBookings { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
