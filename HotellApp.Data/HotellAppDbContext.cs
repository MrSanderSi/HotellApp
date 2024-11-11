using HotellApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotellApp.Data;

public class HotellAppDbContext : DbContext
{
	public DbSet<HotellRoom> Rooms { get; set; }
	public DbSet<Person> People { get; set; }
	public DbSet<Booking> Bookings { get; set; }

    public HotellAppDbContext(DbContextOptions options) : base(options)
    {
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<HotellRoom>()
			.HasMany(x => x.Bookings)
			.WithOne(x => x.Room)
			.HasForeignKey(x => x.Id);

		modelBuilder.Entity<Person>()
			.HasMany(x => x.Bookings)
			.WithOne(x => x.Person)
			.HasForeignKey(x => x.Id);
	}
}
