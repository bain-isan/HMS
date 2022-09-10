using ReservationManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationManagementSystem.Data
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options): base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}
