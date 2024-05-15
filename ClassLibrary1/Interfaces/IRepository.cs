namespace ClassLibrary1.Interfaces
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        IReadOnlyList<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}