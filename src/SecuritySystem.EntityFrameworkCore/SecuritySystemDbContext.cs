using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SecuritySystem.Core.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
 

namespace SecuritySystem.EntityFrameworkCore
{
    public class SecuritySystemDbContext : DbContext
    {
        public SecuritySystemDbContext() {}

        public SecuritySystemDbContext(DbContextOptions<SecuritySystemDbContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            optionsBuilder.ConfigureWarnings(w=> w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
        }

        
     }

        public DbSet<ControlAccess> ControlAccesses { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorLogActivity> DoorLogActivities { get; set; }
        public DbSet<KeyCard> KeyCards { get; set; }
        public DbSet<MotionSensor> MotionSensors { get; set; }
        public DbSet<MotionSensorActivity> MotionSensorActivities { get; set; }


    }
}