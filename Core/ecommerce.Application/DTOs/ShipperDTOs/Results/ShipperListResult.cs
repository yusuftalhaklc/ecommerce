namespace ecommerce.Application.DTOs.ShipperDTOs.Results
{
    public class ShipperListResult
    {
        public IEnumerable<ShipperResult> Shippers { get; set; } = new List<ShipperResult>();
        public int TotalCount { get; set; }
    }
}

