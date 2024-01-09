using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var connString = "";

        connString = config.GetConnectionString("DefaultConnection");

        services.AddCors();

        services.AddScoped<ITokenService, TokenService>();

        services.AddDbContext<DataContext>(opt => opt.UseSqlite(connString));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
