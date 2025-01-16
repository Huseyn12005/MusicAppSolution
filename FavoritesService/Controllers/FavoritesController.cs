using FavoritesService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FavoritesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _service;

        public FavoritesController(IFavoriteService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavorites(string userId)
        {
            var favorites = await _service.GetFavoritesAsync(userId);
            return Ok(favorites);
        }

        [HttpPost("{userId}/{musicId}")]
        public async Task<IActionResult> AddFavorite(string userId, string musicId)
        {
            await _service.AddFavoriteAsync(userId, musicId);
            return Ok();
        }

        [HttpDelete("{userId}/{musicId}")]
        public async Task<IActionResult> RemoveFavorite(string userId, string musicId)
        {
            await _service.RemoveFavoriteAsync(userId, musicId);
            return NoContent();
        }
    }
}
