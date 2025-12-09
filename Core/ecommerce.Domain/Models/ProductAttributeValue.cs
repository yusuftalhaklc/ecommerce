namespace ecommerce.Domain.Models
{
    public class ProductAttributeValue : BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductAttribute Attribute { get; set; }
    }
}
