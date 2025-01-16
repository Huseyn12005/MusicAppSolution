using MusicService.Models;

namespace MusicService.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetByMusicIdAsync(int musicId);
        Task AddAsync(Comment comment);
    }
}