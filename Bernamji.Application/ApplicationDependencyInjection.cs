using Bernamji.Application.MappingProfiles;
using Bernamji.Application.Services.Core;
using Bernamji.Application.Services.Implementation;
using Bernamji.Shared.Services.Core;
using Bernamji.Shared.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Bernamji.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        services.RegisterAutoMapper();

        return services;
    }
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISecurityService, SecurityService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }
}
