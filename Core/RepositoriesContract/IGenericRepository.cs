using Blog.Core.Entites;
using Blog.Core.Specifications;
using Blog.Core.Specifications.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.RepositoriesContract
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>>GetAllAsync();
        Task<IEnumerable<TEntity>>GetAllWithSpecAsync(ISpecifications<TEntity> spec);
        Task<TEntity>GetByIdAsync(int id);
        Task<TEntity>GetByIdAWithSpecAsync(ISpecifications<TEntity> spec);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        
    }
}
