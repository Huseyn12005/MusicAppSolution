namespace IdentityService.Services
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task RegisterAsync(string username, string password);
        Task UploadProfilePictureAsync(int userId, IFormFile picture);
    }
}