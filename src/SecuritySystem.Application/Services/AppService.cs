using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SecuritySystem.Application.Services.Dto;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services
{
    public class AppService<TEntity, TEntityDto, TPrimaryKey> : IAppService<TEntityDto, TPrimaryKey> 
        where TEntity : ModelBase<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        IRepositoryBase<TEntity, TPrimaryKey> _repository;
        IMapper _mapper;
        public AppService(IMapper mapper, IRepositoryBase<TEntity, TPrimaryKey> repository)
        {
           _repository = repository;
           _mapper = mapper;
        }

        public void Delete(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> FirstOrDefaultAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IQueryable<TEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var result = _mapper.Map<IList<TEntityDto>>(entities.ToList());
            return result.AsQueryable<TEntityDto>();
        }

        public Task<TEntityDto> GetAsync(TPrimaryKey id)
        {
            throw new System.NotImplementedException();
        }

        public TEntityDto Insert(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> InsertAsync(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntityDto InsertOrUpdate(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> InsertOrUpdateAsync(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntityDto Update(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntityDto> UpdateAsync(TEntityDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}