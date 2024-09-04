using Bernamji.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.DataAccess.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly BernamjiDbContext context;

    public UnitOfWork(BernamjiDbContext context)
    {
        this.context = context;
    }
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}