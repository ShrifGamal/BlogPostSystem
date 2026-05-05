using Blog.Core.Entites;
using Blog.Core.RepositoriesContract;
using Blog.Core.Specifications;
using Blog.Repository.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BlogDbContext _context;

        public GenericRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> spec)
        {
            return await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>() , spec).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAWithSpecAsync(ISpecifications<TEntity> spec)
        {
            return await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), spec).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
