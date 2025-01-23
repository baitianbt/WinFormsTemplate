using YourSolution.BLL.Interfaces;
using YourSolution.DAL;
using YourSolution.DAL.Interfaces;
using YourSolution.Model;

namespace YourSolution.BLL.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(IBaseRepository<Role> repository, AppDbContext context) 
            : base(repository)
        {
            _context = context;
        }

        public IEnumerable<Permission> GetRolePermissions(int roleId)
        {
            return _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Join(_context.Permissions,
                    rp => rp.PermissionId,
                    p => p.Id,
                    (rp, p) => p)
                .ToList();
        }

        public void UpdateRolePermissions(int roleId, IEnumerable<int> permissionIds)
        {
            var existingPermissions = _context.RolePermissions.Where(rp => rp.RoleId == roleId);
            _context.RolePermissions.RemoveRange(existingPermissions);

            var newPermissions = permissionIds.Select(permId => new RolePermission
            {
                RoleId = roleId,
                PermissionId = permId,
                CreateTime = DateTime.Now
            });

            _context.RolePermissions.AddRange(newPermissions);
            _context.SaveChanges();
        }
    }
} 