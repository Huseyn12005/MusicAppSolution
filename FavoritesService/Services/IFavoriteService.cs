using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoritesService.Services
{
    public interface IFavoriteService
    {
        Task<IEnumerable<string>> GetFavoritesAsync(string userId);
        Task AddFavoriteAsync(string userId, string musicId);
        Task RemoveFavoriteAsync(string userId, string musicId);
    }
}