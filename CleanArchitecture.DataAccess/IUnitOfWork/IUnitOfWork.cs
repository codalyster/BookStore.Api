using CleanArchitecture.DataAccess.IRepository;
using CleanArchitecture.DataAccess.Models;


namespace CleanArchitecture.DataAccess.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : ModelBase;

        Task<int> Complete();


        IApplicationUserRepository ApplicationUserRepository { get; }
    }
}
