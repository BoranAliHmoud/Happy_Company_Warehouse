using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.DataAccess.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> AllAsync(int skip , int take);
        Task<T> GetAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> criteria, int skip, int take, string[] includes = null);
        IEnumerable<T> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        Task<T> AddAsync(T entity);
        Task<List<T>> AddAsync(List<T> entity);
        Task<bool> DeleteAsync(int id); 
        
        bool Update(T entity);

        int count();
    }
}
