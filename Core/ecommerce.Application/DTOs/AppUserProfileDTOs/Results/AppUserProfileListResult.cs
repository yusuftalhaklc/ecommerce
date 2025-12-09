namespace ecommerce.Application.DTOs.AppUserProfileDTOs.Results
{
    public class AppUserProfileListResult
    {
        public IEnumerable<AppUserProfileResult> AppUserProfiles { get; set; } = new List<AppUserProfileResult>();
        public int TotalCount { get; set; }
    }
}

