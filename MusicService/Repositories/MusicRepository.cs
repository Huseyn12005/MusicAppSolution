using Microsoft.EntityFrameworkCore;
using MusicService.Data;
using MusicService.Models;

namespace MusicService.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly AppDbContext _context;

        public MusicRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Music>> GetAllAsync()
        {
            return await _context.Musics.ToListAsync();
        }

        public async Task<Music?> GetByIdAsync(int id)
        {
            return await _context.Musics.FindAsync(id);
        }

        public async Task AddAsync(Music music)
        {
            await _context.Musics.AddAsync(music);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Music music)
        {
            _context.Musics.Update(music);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var music = await _context.Musics.FindAsync(id);
            if (music != null)
            {
                _context.Musics.Remove(music);
                await _context.SaveChangesAsync();
            }
        }
    }
}