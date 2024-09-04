using bernamji.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.DataAccess.Repositories.Core;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByUserNameAsync(string userName);
}