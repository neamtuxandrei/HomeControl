using HomeControlAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeControlAPI.DataAccess
{
    public class HomeControlDbContext : DbContext
    {
        public HomeControlDbContext(DbContextOptions<HomeControlDbContext> options) 
            :base(options)
        {
            
        }

        // db sets
        public DbSet<TemperatureSensor> TemperatureSensors { get; set; }

        public DbSet<LEDSensor> LEDSensors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
