using MusicService.Models;
using MusicService.Repositories;

namespace MusicService.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _repository;

        public PlaylistService(IPlaylistRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Playlist>> GetAllByUserAsync(string userId) => _repository.GetAllByUserAsync(userId);

        public Task<Playlist?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Playlist playlist) => _repository.AddAsync(playlist);

        public Task UpdateAsync(Playlist playlist) => _repository.UpdateAsync(playlist);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}