namespace ecommerce.Application.DTOs.AppUserDTOs.Results
{
    public class AppUserListResult
    {
        public IEnumerable<AppUserResult> AppUsers { get; set; } = new List<AppUserResult>();
        public int TotalCount { get; set; }
    }
}

