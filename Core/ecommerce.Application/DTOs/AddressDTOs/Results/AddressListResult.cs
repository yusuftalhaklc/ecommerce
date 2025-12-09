namespace ecommerce.Application.DTOs.AddressDTOs.Results
{
    public class AddressListResult
    {
        public IEnumerable<AddressResult> Addresses { get; set; } = new List<AddressResult>();
        public int TotalCount { get; set; }
    }
}

