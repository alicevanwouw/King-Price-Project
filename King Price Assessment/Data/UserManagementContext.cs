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
        //public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<UserGroup>().HasKey(ug => new { ug.UserId, ug.GroupId });

            //modelBuilder.Entity<UserGroup>()
            // .HasOne<User>(ug => ug.User)
            // .WithMany(ug => ug.UserGroups)
            // .HasForeignKey(ug => ug.UserId);


            //modelBuilder.Entity<UserGroup>()
            //    .HasOne<Group>(ug => ug.Group)
            //    .WithMany(ug => ug.UserGroups)
            //    .HasForeignKey(ug => ug.GroupId);

            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Permission>().ToTable("Permission");
        }
    }
}
