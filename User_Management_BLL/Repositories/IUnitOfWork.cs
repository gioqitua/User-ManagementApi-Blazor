using User_Management_DAL.Entities;

namespace User_Management_BLL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<UserProfile> UserProfiles { get; }
        void Commit();
        void RejectChanges();
    }
}
