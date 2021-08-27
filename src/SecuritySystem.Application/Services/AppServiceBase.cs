using System.Threading.Tasks;
using SecuritySystem.Application.Services.Dto;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services
{
    public abstract class AppServiceBase<TEntity, TEntityDto, TPrimaryKey> : IAppService<TEntityDto, TPrimaryKey> 
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TEntity :  ModelBase<TPrimaryKey>
    {
        readonly IRepositoryBase<TEntity,TPrimaryKey> repository;
        protected AppServiceBase(IRepositoryBase<TEntity, TPrimaryKey> repository)
        {
            this.repository = repository;
        }

        protected IRepositoryBase<TEntity,TPrimaryKey> Repository => repository;

        public Task<TEntityDto> CreateAsync(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> DeleteAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultDto<TEntityDto>> GetAllAsync(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> GetAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> UpdateAsync(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}