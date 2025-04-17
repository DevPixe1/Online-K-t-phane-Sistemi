namespace OnlineKutuphane.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        T? GetById(int id);
        bool Update(int id, T updated);
        bool Delete(int id);
        List<T> GetAll();
    }
}
