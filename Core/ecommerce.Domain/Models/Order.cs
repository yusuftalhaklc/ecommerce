namespace ecommerce.Domain.Models
{
    public class Order: BaseEntity
    {
        public int AppUserId { get; set; }
        public int ShipperId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }


}
