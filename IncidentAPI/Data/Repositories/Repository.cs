using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected AppDbContext DbContext;
        protected Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }
    }
}
