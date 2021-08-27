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

        public DbSet<ControlAccess> ControlAccesses { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorLogActivity> DoorLogActivities { get; set; }
        public DbSet<KeyCard> KeyCards { get; set; }
        public DbSet<MotionSensor> MotionSensors { get; set; }
        public DbSet<MotionSensorActivity> MotionSensorActivities { get; set; }


    }
}