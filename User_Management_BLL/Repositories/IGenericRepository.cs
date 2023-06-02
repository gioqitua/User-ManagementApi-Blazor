using User_Management_DAL;

namespace User_Management_BLL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        T? GetById(int id);
        void Remove(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}
