using King_Price_Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace King_Price_Assessment.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Group>()
                .ToTable("Group")
                .HasIndex(g => g.Name)
                .IsUnique();
            modelBuilder.Entity<Permission>().ToTable("Permission")
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
