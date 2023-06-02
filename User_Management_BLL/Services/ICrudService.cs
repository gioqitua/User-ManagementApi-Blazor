namespace User_Management_BLL.Services
{
    public interface ICrudService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Save(T entity);
        void Delete(int id);
    }
}
