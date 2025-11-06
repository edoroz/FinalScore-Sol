
using FinalScore_Core.IRepositories;
using FinalScore_Data.Context;
using FinalScore_Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalScore_Core.Repositories {
    
    public class Repository<T> : IRepository<T> where T : class {
        private readonly DbContext _dbContext;
        DbSet<T> dbSet;

        public Repository(DbContext dbContext) {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add     (T entity) {
            dbSet.Add(entity);
        }

        public void Delete  (T entity) {
            _dbContext.Remove(entity);
        }

        public void Delete  (int id) {
            Delete(GetById(id));
        }

        public T    GetById (int id) {
             return dbSet.Find(id);
        }

        public T    getFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProps = null) {
            IQueryable<T> query = dbSet;

            if (filter != null) {
                query = query.Where(filter);
            }

            if (includeProps != null) {
                foreach(var prop in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) { 
                    query = query.Include(prop);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter  = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProps = null) {
            IQueryable<T> query = dbSet;

            if(filter != null) {
                query = query.Where(filter);
            }

            if(includeProps != null) {
                foreach(var prop in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) { 
                    query = query.Include(prop);
                }
            }

            if(orderBy != null) {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

    }
    
}
