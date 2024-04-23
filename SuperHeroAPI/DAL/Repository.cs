namespace SuperheroAPI.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    namespace SuperheroAPI.DAL
    {
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly AppDbContext _context;
            private readonly DbSet<T> _dbSet;

            public Repository(AppDbContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }
            public async Task Add(T entity)
            {
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
            }
            //Add Range to add multible Heroes if desired later.

            public async Task<IEnumerable<T>> GetAll()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
        }

    }

}
