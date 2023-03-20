using DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbLayer
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<Clouds> Clouds { get; set; }
        public DbSet<Coord> Coord { get; set; }
        public DbSet<Main> Main { get; set; }
        public DbSet<Sys> Sys { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<Wind> Wind { get; set; }
    }
}
