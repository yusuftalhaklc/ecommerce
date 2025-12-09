using ecommerce.Domain.Enums;

namespace ecommerce.Domain.Models
{
    public class EntityType : BaseEntity
    {
        public EntityTypeEnum Name { get; set; }

        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
    }
}

