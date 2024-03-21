using Microsoft.EntityFrameworkCore;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _dbSet;

        private DbSet<T> DbSet => _dbSet ??= _dbContext.Set<T>();

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(_ => (_ as EntityBase).Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
