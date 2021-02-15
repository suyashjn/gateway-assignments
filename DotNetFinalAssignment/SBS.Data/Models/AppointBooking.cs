using System;

namespace SBS.Data.Models
{
    public class AppointBooking
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int VehicleId { get; set; }
        public int DealerId { get; set; }
        public int? MechanicId { get; set; }
        public int ServiceId { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Status { get; set; }
    
        public virtual Dealer Dealer { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Service Service { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
