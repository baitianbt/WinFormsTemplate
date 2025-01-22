using YourSolution.Model;

namespace YourSolution.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
} 