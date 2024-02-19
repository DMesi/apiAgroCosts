using StorageServiceLibrary.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageServiceLibrary.Model;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace StorageServiceLibrary.Repository
{
    public class GenericRepositroy<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDB _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepositroy(AppDB context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IList<T>> customQuery(Expression<Func<T, bool>> expresson = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {

            IQueryable<T> query = _dbSet;

            if (expresson != null)
            {
                query = query.Where(expresson);

            }
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            if (orderBy != null)
            {

                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();

        }

        public async Task Delete(int id)
        {
            
            //throw new NotImplementedException();

            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);  
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            //throw new NotImplementedException();

            IQueryable<T> query = _dbSet;

            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);


        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expresson = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            //throw new NotImplementedException();

            IQueryable<T> query = _dbSet;


            

            if (expresson != null)
            {
                query = query.Where(expresson);

            }
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            if (orderBy != null)
            {

                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();

        }

        public async Task Insert(T entity)
        {
            // throw new NotImplementedException();
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            // throw new NotImplementedException();

            _dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
