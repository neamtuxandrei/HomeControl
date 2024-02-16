using HomeControlAPI.Domain;

namespace HomeControlAPI.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        void Add(T toAdd);
        void Remove(T entity);

        void Update(T entity);
        Task<T?> GetById(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
