using YourSolution.Model;

namespace YourSolution.BLL.Interfaces
{
    public interface IPermissionService : IBaseService<Permission>
    {
        IEnumerable<Permission> GetByModule(string module);
    }
} 