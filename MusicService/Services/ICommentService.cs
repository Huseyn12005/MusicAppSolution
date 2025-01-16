using MusicService.Models;

namespace MusicService.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetByMusicIdAsync(int musicId);
        Task AddAsync(Comment comment);
    }
}