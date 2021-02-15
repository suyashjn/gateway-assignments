using System.Collections.Generic;

namespace SBS.Data.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public virtual List<AppointBooking> AppointBookings { get; set; }
        public virtual List<Mechanic> Mechanics { get; set; }
    }
}
