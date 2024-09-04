using bernamji.Core.Entities;
using Bernamji.DataAccess.Persistence;
using Bernamji.DataAccess.Repositories.Core;
using Bernamji.DataAccess.Repositories.Implementation;
using Bernamji.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.DataAccess;
public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();

        return services;
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BernamjiDbContext>(options =>
                 options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                 opt => opt.MigrationsAssembly(typeof(BernamjiDbContext).Assembly.FullName)));
    }
}