using bernamji.Core.Entities;
using Bernamji.DataAccess.Persistence;
using Bernamji.DataAccess.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.DataAccess.Repositories.Implementation;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BernamjiDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await dbContext.Users
                    .Where(u => u.UserName == userName)
                    .FirstOrDefaultAsync();

    }
}