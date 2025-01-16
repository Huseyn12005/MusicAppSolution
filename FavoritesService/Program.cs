using StackExchange.Redis;
using FavoritesService.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Redis with explicit connection options
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
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
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();
