using YourSolution.Model;

namespace YourSolution.DAL.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
} 