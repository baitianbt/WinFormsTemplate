using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YourSolution.DAL.Interfaces;
using YourSolution.Model;

namespace YourSolution.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual void Add(T entity)
        {
            entity.CreateTime = DateTime.Now;
            _dbSet.Add(entity);
            SaveChanges();
        }

        public virtual void Update(T entity)
        {
            entity.UpdateTime = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
} 