using Microsoft.EntityFrameworkCore;
using YourSolution.Model;

namespace YourSolution.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(_context.Roles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => r)
                .ToList();
        }

        public IEnumerable<Permission> GetUserPermissions(int userId)
        {
            return _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(_context.RolePermissions,
                    ur => ur.RoleId,
                    rp => rp.RoleId,
                    (ur, rp) => rp.PermissionId)
                .Join(_context.Permissions,
                    permId => permId,
                    perm => perm.Id,
                    (permId, perm) => perm)
                .Distinct()
                .ToList();
        }

        public void UpdateUserRoles(int userId, IEnumerable<int> roleIds)
        {
            var existingUserRoles = _context.UserRoles.Where(ur => ur.UserId == userId);
            _context.UserRoles.RemoveRange(existingUserRoles);

            var newUserRoles = roleIds.Select(roleId => new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                CreateTime = DateTime.Now
            });

            _context.UserRoles.AddRange(newUserRoles);
            _context.SaveChanges();
        }
    }
} 