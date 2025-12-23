using Microsoft.EntityFrameworkCore;
using MODEL.Entity;
using File = MODEL.Entity.File;

namespace MODEL
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<EmployeeEXT> EmployeeEXT { get; set; }
        public DbSet<MemberInfo> MemberInfo { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<TEmp_Group> TEmp_Group { get; set; }
        public DbSet<TEmp_Role> TEmp_Role { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<User> User { get; set; }

    }

}
