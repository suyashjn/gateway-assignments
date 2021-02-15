﻿using System.Collections.Generic;

namespace SBS.Data.Models
{
    public class Customer
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
        public string Question { get; set; }
        public string Answer { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
