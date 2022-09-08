using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options): base(options) { }

        public DbSet<Inventory> Inventorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasIndex(x => x.RoomNumber).IsUnique(true);
            modelBuilder.Entity<Inventory>().HasIndex(x => x.InventoryCode).IsUnique(true);
        }
    }
}
