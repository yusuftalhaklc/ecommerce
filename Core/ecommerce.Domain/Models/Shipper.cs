namespace ecommerce.Domain.Models
{
    public class Shipper : BaseEntity
    {
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
