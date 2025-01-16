using FavoritesService.Services;
using StackExchange.Redis;

namespace FavoritesService
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
            // Configure Redis with explicit connection options
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var muxer = ConnectionMultiplexer.Connect(new ConfigurationOptions
                {
                    EndPoints = { { "redis-19752.c16.us-east-1-2.ec2.redns.redis-cloud.com", 19752 } },
                    User = "default",
                    Password = "5IrXAwCr5xa1jRRqPwBg0Xkce19gQv9g"
                });
                return muxer;
            });

            // Add other services
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
