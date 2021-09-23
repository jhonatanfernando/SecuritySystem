using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.EntityFrameworkCore.Repositories
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepositoryBase<TEntity, TPrimaryKey> where TEntity :  ModelBase<TPrimaryKey>
    {
        private SecuritySystemDbContext _dbContextProvider;

        public RepositoryBase(SecuritySystemDbContext dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        } 

        public virtual DbContext Context => _dbContextProvider;  
        public virtual DbSet<TEntity> Table => Context.Set<TEntity>();
     
        public async Task DeleteAsync(TPrimaryKey id)
        {
            var entity =  Table.Local.FirstOrDefault(c=> EqualityComparer<TPrimaryKey>.Default.Equals(c.Id, id));
            if(entity == null)
            {
                entity = await FirstOrDefaultAsync(id);
                if(entity == null)
                    return;
            }

            Delete(entity);
        }
        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
            _dbContextProvider.SaveChanges();
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(Table.AsQueryable());
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await FirstOrDefaultAsync(id);
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            var entitySaved = Task.FromResult(Table.Add(entity).Entity);
            _dbContextProvider.SaveChanges();
            return entitySaved;
             
        }

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return entity.IsTransient() ? InsertAsync(entity) : UpdateAsync(entity);
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            return entity.IsTransient() ? Insert(entity) : Update(entity);
        }

        public TEntity Insert(TEntity entity)
        {
            var entitySaved =  Table.Add(entity).Entity;
            _dbContextProvider.SaveChanges();
            return entitySaved;
        }

        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            _dbContextProvider.SaveChanges();
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            _dbContextProvider.SaveChanges();
            return Task.FromResult(entity);
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            var query = await GetAllAsync();
            return query.FirstOrDefault<TEntity>(CreateEqualityExpressionForId(id));
        }

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof(TEntity));

            var value = Convert.ChangeType(id, typeof(TPrimaryKey));
            var valueExpression = Expression.Constant(value, typeof(TPrimaryKey));

            BinaryExpression lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                valueExpression
            );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if(!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }
    }
}