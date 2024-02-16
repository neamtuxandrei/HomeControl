using HomeControlAPI.Abstractions;
using HomeControlAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeControlAPI.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly HomeControlDbContext _dbContext;
        internal DbSet<T> dbSet;
        public BaseRepository(HomeControlDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }
        public void Add(T toAdd)
        {
            dbSet.Add(toAdd);
        }

        public async Task<T?> GetById(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
    }
}
