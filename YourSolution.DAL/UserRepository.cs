using YourSolution.Model;
using YourSolution.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace YourSolution.DAL
{
    public class UserRepository : IBaseRepository<User>
    {
        // 模拟数据库，实际项目中应该使用真实数据库
        private static List<User> _users = new List<User>() { new User() { Id =1, Username = "1", Password = "1",IsActive =true} };

        
        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Add(User entity)
        {
            entity.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(entity);
        }

        public void Update(User entity)
        {
            var user = GetById(entity.Id);
            if (user != null)
            {
                user.Username = entity.Username;
                user.Email = entity.Email;
                user.IsActive = entity.IsActive;
                user.UpdateTime = entity.UpdateTime;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
} 