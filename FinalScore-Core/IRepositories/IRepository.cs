

using FinalScore_Data.Models;
using System.Linq.Expressions;

namespace FinalScore_Core.IRepositories {
    
    public interface IRepository<T> where T : class {
        T GetById(int id);
        
        IEnumerable<T> GetAll(Expression<Func<T,bool>>? filter = null, 
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null, 
            string? includeProps = null);

        T getFirstOrDefault(Expression<Func<T,bool>>? filter = null, 
            string? includeProps = null);
         
        void Add(T entity);

        void Delete(T entity);

        void Delete(int id);
    }

}
