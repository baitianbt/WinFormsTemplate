using YourSolution.Model;

namespace YourSolution.BLL.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
} 