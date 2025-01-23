using YourSolution.BLL.Interfaces;
using YourSolution.DAL.Interfaces;
using YourSolution.Model;

namespace YourSolution.BLL.Services
{
    public class PermissionService : BaseService<Permission>, IPermissionService
    {
        public PermissionService(IBaseRepository<Permission> repository) : base(repository)
        {
        }

        public IEnumerable<Permission> GetByModule(string module)
        {
            return _repository.Find(p => p.Module == module);
        }
    }
} 