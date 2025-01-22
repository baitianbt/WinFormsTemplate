using YourSolution.Model;

namespace YourSolution.BLL.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User GetByUsername(string username);
        bool ValidateUser(string username, string password);
    }
} 