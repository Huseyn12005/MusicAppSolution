using MusicService.Models;
using MusicService.Repositories;

namespace MusicService.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _repository;

        public MusicService(IMusicRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Music>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Music?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Music music) => _repository.AddAsync(music);

        public Task UpdateAsync(Music music) => _repository.UpdateAsync(music);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}