using Bernamji.DataAccess.Repositories.Core;
using Bernamji.DataAccess.UnitOfWork;
using Bernamji.Shared.Services.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Bernamji.DataAccess.Persistence.DatabaseSeed;

namespace Bernamji.DataAccess.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<BernamjiDbContext>();
            await context.Database.MigrateAsync();

            
            
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var secuirtyService = scope.ServiceProvider.GetRequiredService<ISecurityService>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            
            await Seed.SeedUsersAndRolesAsync(userRepository, secuirtyService);
            await unitOfWork.CommitAsync();
        }
    }
}
