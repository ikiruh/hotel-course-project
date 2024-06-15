using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DbContexts;

public class HotelDbContext : DbContext
{
    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!; 
    public DbSet<RoomFloor> RoomsFloors { get; set; } = null!;
    public DbSet<RoomType> RoomTypes { get; set; } = null!;

    public HotelDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hotel.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
