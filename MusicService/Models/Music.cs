namespace MusicService.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
    }
}
