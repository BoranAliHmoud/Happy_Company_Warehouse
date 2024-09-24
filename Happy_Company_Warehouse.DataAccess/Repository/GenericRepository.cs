 
using Happy_Company_Warehouse.DataAccess.Data;
using Happy_Company_Warehouse.DataAccess.IRepository;
 
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext  _context ;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> AllAsync(int skip, int take)
        {
            return await dbSet.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria ,string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        } 
        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> criteria, int skip, int take, string[] includes = null)
        {
            IQueryable<T> query = dbSet;

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.Where(criteria).Skip(skip).Take(take).ToListAsync();
        }
        public IEnumerable<T> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<List<T>> AddAsync(List<T> entity)
        {
            foreach (var item in entity)
            {
                await dbSet.AddAsync(item);
            }
            return entity;
        } 
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var data = await GetAsync(id);
            if (data == null)
            {
                return false;
            }
            dbSet.Remove(data);
            return true;
        }
        public virtual bool Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }
        public int count()
        {
            return dbSet.Count();
        }
    }
}