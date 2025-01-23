using Microsoft.EntityFrameworkCore;
using YourSolution.Model;

namespace YourSolution.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置索引和关系
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<Permission>()
                .HasIndex(p => p.Code)
                .IsUnique();

            // 初始化数据
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // 添加默认权限
            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Code = "USER_VIEW", Name = "View Users", Module = "User Management", Description = "Can view user list" },
                new Permission { Id = 2, Code = "USER_CREATE", Name = "Create User", Module = "User Management", Description = "Can create new users" },
                new Permission { Id = 3, Code = "USER_EDIT", Name = "Edit User", Module = "User Management", Description = "Can edit existing users" },
                new Permission { Id = 4, Code = "USER_DELETE", Name = "Delete User", Module = "User Management", Description = "Can delete users" },
                new Permission { Id = 5, Code = "ROLE_VIEW", Name = "View Roles", Module = "Role Management", Description = "Can view role list" },
                new Permission { Id = 6, Code = "ROLE_CREATE", Name = "Create Role", Module = "Role Management", Description = "Can create new roles" },
                new Permission { Id = 7, Code = "ROLE_EDIT", Name = "Edit Role", Module = "Role Management", Description = "Can edit existing roles" },
                new Permission { Id = 8, Code = "ROLE_DELETE", Name = "Delete Role", Module = "Role Management", Description = "Can delete roles" }
            );

            // 添加默认角色
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrator", Description = "System Administrator", IsActive = true },
                new Role { Id = 2, Name = "User", Description = "Normal User", IsActive = true }
            );

            // 为管理员角色添加所有权限
            modelBuilder.Entity<RolePermission>().HasData(
                Enumerable.Range(1, 8).Select(i => new RolePermission { Id = i, RoleId = 1, PermissionId = i })
            );

            // 为普通用户角色添加基本权限
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { Id = 9, RoleId = 2, PermissionId = 1 }  // 只有查看用户的权限
            );

            // 添加默认管理员用户
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin", Email = "admin@example.com", IsActive = true }
            );

            // 为默认管理员分配管理员角色
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1 }
            );
        }
    }
} 