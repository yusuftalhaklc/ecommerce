namespace ecommerce.Domain.Models
{
    public class EntityType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
    }
}

