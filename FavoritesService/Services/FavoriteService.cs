using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoritesService.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IConnectionMultiplexer _redis;

        public FavoriteService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<IEnumerable<string>> GetFavoritesAsync(string userId)
        {
            var db = _redis.GetDatabase();
            var favorites = await db.SetMembersAsync(userId);
            return favorites.Select(f => f.ToString());
        }

        public async Task AddFavoriteAsync(string userId, string musicId)
        {
            var db = _redis.GetDatabase();
            await db.SetAddAsync(userId, musicId);
        }

        public async Task RemoveFavoriteAsync(string userId, string musicId)
        {
            var db = _redis.GetDatabase();
            await db.SetRemoveAsync(userId, musicId);
        }
    }
}
