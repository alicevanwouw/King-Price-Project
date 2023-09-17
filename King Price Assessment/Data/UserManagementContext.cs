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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<User>().ToTable("user");

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //            .HasName("user_pkey");

        //        entity.ToTable("user", "user_management");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

        //        entity.Property(e => e.FirstName)
        //           .HasColumnType("character varying")
        //           .HasColumnName("first_name");

        //        entity.Property(e => e.Surname)
        //           .HasColumnType("character varying")
        //           .HasColumnName("surname");

        //        entity.Property(e => e.Email)
        //           .HasColumnType("email")
        //           .HasColumnName("email");

        //        //TO DO: groups

        //        entity.Property(e => e.PhoneNumber)
        //           .HasColumnType("character varying")
        //           .HasColumnName("phone_number");

        //        entity.Property(e => e.Groups)
        //           .HasColumnName("groups");

        //        entity.Property(e => e.CreatedAt)
        //            .HasColumnType("timestamp with time zone")
        //            .HasColumnName("created_at")
        //            .HasDefaultValueSql("now()");

        //    });

        //    //modelBuilder.Entity<UserGroup>().ToTable("group");

        //    modelBuilder.Entity<Group>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //            .HasName("group_pkey");

        //        entity.ToTable("group", "user_management");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

        //        entity.Property(e => e.Name)
        //           .HasColumnType("character varying")
        //           .HasColumnName("name");

        //        entity.Property(e => e.Permissions)
        //             .HasColumnName("permissions");

        //        entity.Property(e => e.CreatedAt)
        //            .HasColumnType("timestamp with time zone")
        //            .HasColumnName("created_at")
        //            .HasDefaultValueSql("now()");

        //        entity.Property(e => e.IsActive)
        //           .HasColumnName("is_active")
        //           .HasDefaultValueSql("true");
        //    });

        //    //modelBuilder.Entity<GroupPermission>().ToTable("permission");

        //    modelBuilder.Entity<GroupPermission>(entity =>
        //    {
        //        entity.HasKey(e => e.Id)
        //            .HasName("permission_pkey");

        //        entity.ToTable("permission", "user_management");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

        //        entity.Property(e => e.Name)
        //           .HasColumnType("character varying")
        //           .HasColumnName("name");

        //        entity.Property(e => e.CreatedAt)
        //            .HasColumnType("timestamp with time zone")
        //            .HasColumnName("created_at")
        //            .HasDefaultValueSql("now()");

        //        entity.Property(e => e.IsActive)
        //           .HasColumnName("is_active")
        //           .HasDefaultValueSql("true");
        //    });

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Permission>().ToTable("Permission");
        }
    }
}
