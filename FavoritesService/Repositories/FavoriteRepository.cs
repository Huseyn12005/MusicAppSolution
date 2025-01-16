using FavoritesService.Data;
using FavoritesService.Models;
using Microsoft.EntityFrameworkCore;

namespace FavoritesService.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;
        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserId(string userId)
        {
            return await _context.Favorites.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<Favorite> AddFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task RemoveFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
