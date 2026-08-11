using Microsoft.EntityFrameworkCore;
using Blood_Donation_Management.Models;

namespace Blood_Donation_Management.TaskDbContext
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Users table
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Make Email unique
            builder.Entity<User>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
        }
    }
}