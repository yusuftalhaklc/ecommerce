using ecommerce.Domain.Enums;

namespace ecommerce.Domain.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
