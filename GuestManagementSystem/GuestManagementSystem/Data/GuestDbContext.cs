using GuestManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestManagementSystem.Data
{
    public class GuestDbContext : DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options): base(options) { }

        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasIndex(x => x.MemberCode).IsUnique(true);
            modelBuilder.Entity<Guest>().HasIndex(e => e.PhoneNumber).IsUnique(true);
            modelBuilder.Entity<Guest>().HasIndex(e => e.Email).IsUnique(true);
        }
    }
}
