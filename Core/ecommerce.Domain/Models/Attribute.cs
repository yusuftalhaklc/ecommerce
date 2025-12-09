namespace ecommerce.Domain.Models
{
    public class Attribute : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<AttributeValue> Values { get; set; }
    }
}

