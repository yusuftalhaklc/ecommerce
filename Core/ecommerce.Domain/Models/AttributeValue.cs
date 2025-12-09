namespace ecommerce.Domain.Models
{
    public class AttributeValue : BaseEntity
    {
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }

        public virtual EntityType EntityType { get; set; }
        public virtual Attribute Attribute { get; set; }
    }
}

