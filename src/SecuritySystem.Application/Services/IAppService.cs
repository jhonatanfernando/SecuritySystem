using System.Linq;
using System.Threading.Tasks;
using SecuritySystem.Application.Services.Dto;
using SecuritySystem.Core.Models;

namespace SecuritySystem.Application.Services
{
    public interface IAppService<TEntity, TInsertEntityDto, TPrimaryKey> 
       where TEntity :  EntityDto<TPrimaryKey>
       where TInsertEntityDto :  EntityDto<TPrimaryKey>
    {
        Task<IQueryable<TEntity>> GetAllAsync(); 
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> InsertOrUpdateAsync(TInsertEntityDto entity);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(TInsertEntityDto entity);
        Task<TEntity> UpdateAsync(TInsertEntityDto entity);
        TEntity Update(TInsertEntityDto entity);
        Task<TEntity> InsertAsync(TInsertEntityDto entity);
        TEntity InsertOrUpdate(TInsertEntityDto entity);
        TEntity Insert(TInsertEntityDto entity);
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
    }
}