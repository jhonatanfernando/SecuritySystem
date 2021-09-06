using System.Linq;
using System.Threading.Tasks;
using SecuritySystem.Application.Services.Dto;
using SecuritySystem.Core.Models;

namespace SecuritySystem.Application.Services
{
    public interface IAppService<TEntity, TPrimaryKey> where TEntity :  EntityDto<TPrimaryKey>
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