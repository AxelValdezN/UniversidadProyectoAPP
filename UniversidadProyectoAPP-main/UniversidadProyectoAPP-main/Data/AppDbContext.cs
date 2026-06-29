using Microsoft.EntityFrameworkCore;
using AppDoAPI.models;

namespace AppDoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Nombre = "administrador", Email = "admin@appdo.com", password = "1234" }
            );
        }
    }
}
#pragma warning restore format