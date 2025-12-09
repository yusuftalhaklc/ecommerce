namespace ecommerce.Domain.Models
{
    public class Address : BaseEntity
    {
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
