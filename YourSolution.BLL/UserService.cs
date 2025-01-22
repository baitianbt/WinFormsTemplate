using YourSolution.DAL.Interfaces;
using YourSolution.BLL.Interfaces;
using YourSolution.Model;
using System.Linq;

namespace YourSolution.BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IBaseRepository<User> repository) : base(repository)
        {
        }

        public User GetByUsername(string username)
        {
            return _repository.GetAll().FirstOrDefault(u => u.Username == username);
        }

        public bool ValidateUser(string username, string password)
        {
            var user = GetByUsername(username);
            return user != null && user.Password == password && user.IsActive;
        }
    }
} 