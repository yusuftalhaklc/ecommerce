namespace ecommerce.Domain.Models
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductAttributeValue> Values { get; set; }
    }
}
