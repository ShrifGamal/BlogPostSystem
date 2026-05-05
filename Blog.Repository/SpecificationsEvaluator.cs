using Blog.Core.Entites;
using Blog.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity>GetQuery(IQueryable<TEntity> inputQuery , ISpecifications<TEntity> specifications)
        {
            var query = inputQuery;

            if(specifications.Criteria is not null)
            { 
                query = query.Where(specifications.Criteria);

            }

            query = specifications.Includes.Aggregate(query, (CurrentQuery, includeExpression) => CurrentQuery.Include(includeExpression));

            return query;
        } 

    }
}
