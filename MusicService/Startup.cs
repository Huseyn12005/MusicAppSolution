using Microsoft.EntityFrameworkCore;
using MusicService.Data;
using MusicService.Repositories;
using MusicService.Services;

namespace MusicService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Replace in-memory database with PostgreSQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Default")));

            services.AddScoped<IMusicRepository, MusicRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IMusicService, Services.MusicService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicService API V1");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate(); // Apply migrations
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
