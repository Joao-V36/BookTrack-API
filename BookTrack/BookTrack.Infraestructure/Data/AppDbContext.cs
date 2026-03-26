using BookTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookTrack.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
