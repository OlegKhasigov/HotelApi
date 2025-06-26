using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi
{
    public class AppDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BookingHistory> BookingRecords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
