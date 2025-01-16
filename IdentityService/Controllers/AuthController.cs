using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.LoginRequest request)
        {
            try
            {
                var token = await _service.AuthenticateAsync(request.Username, request.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid credentials");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Models.LoginRequest request)
        {
            try
            {
                await _service.RegisterAsync(request.Username, request.Password);
                return Ok("Registration successful");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload-profile-picture")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] ProfilePictureRequest request)
        {
            try
            {
                await _service.UploadProfilePictureAsync(int.Parse(request.UserId), request.Picture);
                return Ok("Profile picture uploaded successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}