using System.Collections.Generic;

namespace PMS.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }

        // O->M relationship with product
        public List<Product> Products { get; set; }
    }
}
