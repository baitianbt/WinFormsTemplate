using YourSolution.Model;

namespace YourSolution.BLL.Interfaces
{
    public interface IRoleService : IBaseService<Role>
    {
        IEnumerable<Permission> GetRolePermissions(int roleId);
        void UpdateRolePermissions(int roleId, IEnumerable<int> permissionIds);
    }
} 