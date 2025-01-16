namespace MusicService.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int MusicId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
