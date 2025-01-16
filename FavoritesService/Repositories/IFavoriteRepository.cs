using FavoritesService.Models;

namespace FavoritesService.Repositories
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetFavoritesByUserId(string userId);
        Task<Favorite> AddFavorite(Favorite favorite);
        Task RemoveFavorite(int id);
    }
}