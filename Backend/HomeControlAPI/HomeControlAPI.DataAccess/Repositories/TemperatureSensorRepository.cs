using HomeControlAPI.Abstractions;
using HomeControlAPI.Domain;

namespace HomeControlAPI.DataAccess.Repositories
{
    public class TemperatureSensorRepository : BaseRepository<TemperatureSensor>, ITemperatureRepository
    {
        private readonly HomeControlDbContext _dbContext; 
        public TemperatureSensorRepository(HomeControlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
