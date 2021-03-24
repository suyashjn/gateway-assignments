namespace PMS.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string SmallImage { get; set; }
        public string LongImage { get; set; }

        // M->O with User
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
