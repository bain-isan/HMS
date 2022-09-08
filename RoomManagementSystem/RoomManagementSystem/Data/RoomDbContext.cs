using Microsoft.EntityFrameworkCore;
using RoomManagementSystem.Models;

namespace RoomManagementSystem.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options): base(options) { }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasIndex(x => x.RoomNumber).IsUnique(true);
        }
    }
}
