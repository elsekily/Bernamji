using bernamji.Core.Entities;
using Bernamji.DataAccess.Repositories.Core;
using Bernamji.Shared.Services.Core;


namespace Bernamji.DataAccess.Persistence;

public class DatabaseSeed
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IUserRepository userRepository,ISecurityService securityService)
        {
            if (!(await userRepository.GetAllAsync()).Any())
            {
                var users = new List<User>()
                {
                    new User() { UserName = "test1", Password = securityService.HashPassword("Abc123") },
                    new User() { UserName = "test2", Password = securityService.HashPassword("Efg123") },
                    new User() { UserName = "test3", Password = securityService.HashPassword("Hij123") }
                };
                foreach (var user in users)
                {
                    await userRepository.AddAsync(user);
                }
            }
        }
    }
}