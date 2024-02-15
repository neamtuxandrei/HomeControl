using HomeControlAPI.Abstractions;
using HomeControlAPI.Domain;

namespace HomeControlAPI.DataAccess.Repositories
{
    public class LEDSensorRepository : BaseRepository<LEDSensor>, ILEDRepository
    {
        private readonly HomeControlDbContext _dbContext;
        public LEDSensorRepository(HomeControlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
