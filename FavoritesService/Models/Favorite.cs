namespace FavoritesService.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int MusicId { get; set; }
    }
}