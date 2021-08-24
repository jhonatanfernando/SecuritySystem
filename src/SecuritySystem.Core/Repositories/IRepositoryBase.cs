using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecuritySystem.Core.Models;

namespace SecuritySystem.Core.Repositories
{
    public interface IRepositoryBase<TEntity, TPrimaryKey> where TEntity :  ModelBase<TPrimaryKey>
    {
        Task<IQueryable<TEntity>> GetAllAsync(); 
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        TEntity Insert(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
    }
}