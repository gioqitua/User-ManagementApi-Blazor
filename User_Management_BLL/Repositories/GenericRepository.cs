using Microsoft.EntityFrameworkCore;
using User_Management_DAL;
using User_Management_DAL.Entities;

namespace User_Management_BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _dbContext;
        protected DbSet<T> _set => _dbContext.Set<T>();
        public GenericRepository(DataContext dbContext) => _dbContext = dbContext;
        public IQueryable<T> Entities => _set.AsQueryable().AsNoTracking();
        public void Remove(T entity) => _set.Remove(entity);
        public void Add(T entity) => _set.Add(entity);
        public void Update(T entity) => _set.Update(entity);
        public T? GetById(int id) => _set.Find(id);
    }
}
