using HomeControlAPI.Abstractions;
using HomeControlAPI.Domain;

namespace HomeControlAPI.DataAccess.Repositories
{
    public class LEDRepository : BaseRepository<LEDSensor>, ILEDRepository
    {
        private readonly HomeControlDbContext _dbContext;
        public LEDRepository(HomeControlDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
