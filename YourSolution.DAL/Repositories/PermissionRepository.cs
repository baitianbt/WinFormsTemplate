using YourSolution.Model;

namespace YourSolution.DAL.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
} 