using Blog.Core;
using Blog.Core.Entites;
using Blog.Core.RepositoriesContract;
using Blog.Repository.Data.Context;
using Blog.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;
        private Hashtable _repository;

        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
            _repository = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
             return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity).Name;
            if (!_repository.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repository.Add(type, repository);
            }

            return _repository[type] as IGenericRepository<TEntity>;
        }
    }
}
