using MusicService.Models;
using MusicService.Repositories;

namespace MusicService.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Comment>> GetByMusicIdAsync(int musicId) => _repository.GetByMusicIdAsync(musicId);

        public Task AddAsync(Comment comment) => _repository.AddAsync(comment);
    }
}