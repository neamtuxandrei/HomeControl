using HomeControlAPI.Abstractions;
using HomeControlAPI.Domain;

namespace HomeControlAPI.DataAccess.Repositories
{
    public class TemperatureRepository : BaseRepository<TemperatureSensor>, ITemperatureRepository
    {
        private readonly HomeControlDbContext _dbContext; 
        public TemperatureRepository(HomeControlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
