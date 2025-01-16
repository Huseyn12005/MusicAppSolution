using MusicService.Models;

namespace MusicService.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<Playlist>> GetAllByUserAsync(string userId);
        Task<Playlist?> GetByIdAsync(int id);
        Task AddAsync(Playlist playlist);
        Task UpdateAsync(Playlist playlist);
        Task DeleteAsync(int id);
    }
}