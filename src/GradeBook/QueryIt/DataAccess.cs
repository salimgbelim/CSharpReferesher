using System;
using System.Data.Entity;
using System.Linq;

namespace GradeBook.QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public interface IReadOnlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit(); 
    }

    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
    {
    }

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext _ctx;
        private DbSet<T> _set;

        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}