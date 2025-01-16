namespace MusicService.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ICollection<Music> Tracks { get; set; } = new List<Music>();
    }
}