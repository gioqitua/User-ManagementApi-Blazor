using Microsoft.EntityFrameworkCore;
using User_Management_DAL.Entities;

namespace User_Management_BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _ctx;
        public IGenericRepository<UserProfile> UserProfiles { get; }
        public IGenericRepository<User> Users { get; }
        public UnitOfWork()
        {
            _ctx = new DataContext();
            Users = new GenericRepository<User>(_ctx);
            UserProfiles = new GenericRepository<UserProfile>(_ctx);
        }
        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in _ctx.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
