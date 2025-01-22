using YourSolution.DAL.Interfaces;
using YourSolution.BLL.Interfaces;
using YourSolution.Model;

namespace YourSolution.BLL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Add(T entity)
        {
            entity.CreateTime = DateTime.Now;
            _repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entity.UpdateTime = DateTime.Now;
            _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
} 