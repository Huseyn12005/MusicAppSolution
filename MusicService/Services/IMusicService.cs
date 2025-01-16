using MusicService.Models;


namespace MusicService.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Music>> GetAllAsync();
        Task<Music?> GetByIdAsync(int id);
        Task AddAsync(Music music);
        Task UpdateAsync(Music music);
        Task DeleteAsync(int id);
    }
}