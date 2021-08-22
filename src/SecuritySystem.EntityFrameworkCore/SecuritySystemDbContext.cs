using Microsoft.EntityFrameworkCore;
using SecuritySystem.Core.Models;

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
           optionsBuilder.UseSqlServer("Data Source=SQL5101.site4now.net;Initial Catalog=db_a76e65_securitysystem;User Id=db_a76e65_securitysystem_admin;Password=securitysystem.1");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ControlAccess> ControlAccesses { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorLogActivity> DoorLogActivities { get; set; }
        public DbSet<KeyCard> KeyCards { get; set; }
        public DbSet<MotionSensor> MotionSensors { get; set; }
        public DbSet<MotionSensorActivity> MotionSensorActivities { get; set; }


    }
}