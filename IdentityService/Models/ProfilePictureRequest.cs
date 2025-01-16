namespace IdentityService.Models
{
    public class ProfilePictureRequest
    {
        public string UserId { get; set; } = string.Empty;
        public IFormFile Picture { get; set; } = null!;
    }
}