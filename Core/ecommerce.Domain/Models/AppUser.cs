namespace ecommerce.Domain.Models
{
    public class AppUser : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual AppUserProfile Profile { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
