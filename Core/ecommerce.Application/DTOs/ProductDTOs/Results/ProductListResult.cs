namespace ecommerce.Application.DTOs.ProductDTOs.Results
{
    public class ProductListResult
    {
        public IEnumerable<ProductResult> Products { get; set; } = new List<ProductResult>();
        public int TotalCount { get; set; }
    }
}

