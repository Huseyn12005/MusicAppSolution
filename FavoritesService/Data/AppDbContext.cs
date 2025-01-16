using Microsoft.EntityFrameworkCore;
using FavoritesService.Models;

namespace FavoritesService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
