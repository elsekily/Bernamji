
namespace Bernamji.DataAccess.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync();
}