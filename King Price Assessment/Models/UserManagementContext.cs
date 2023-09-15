using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace King_Price_Assessment.Models
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> Groups { get; set; }
        public DbSet<GroupPermission> Permissions { get; set; }
    }
}
