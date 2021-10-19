using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using SecuritySystem.Application.Services.Dto;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Application.Services
{

    public class AppService<TEntity, TEntityDto, TPrimaryKey> : AppService<TEntity, TEntityDto, TEntityDto, TPrimaryKey>
        where TEntity : ModelBase<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        public AppService(IMapper mapper, IRepositoryBase<TEntity, TPrimaryKey> repository) : base(mapper, repository)
        {

        }
    }

    public class AppService<TEntity, TEntityDto, TInsertEntityDto, TPrimaryKey> : IAppService<TEntityDto, TInsertEntityDto, TPrimaryKey> 
        where TEntity : ModelBase<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
        where TInsertEntityDto : EntityDto<TPrimaryKey>
    {
        IRepositoryBase<TEntity, TPrimaryKey> _repository;
        IMapper _mapper;

        public IRepositoryBase<TEntity, TPrimaryKey> Repository => _repository;
        public IMapper Mapper => _mapper;

        public AppService(IMapper mapper, IRepositoryBase<TEntity, TPrimaryKey> repository)
        {
           _repository = repository;
           _mapper = mapper;
        }

        public void Delete(TInsertEntityDto entity)
        {
             var entityDb = _mapper.Map<TEntity>(entity); 
             _repository.Delete(entityDb);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<TEntityDto> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await GetAsync(id);
        }

        public async Task<IQueryable<TEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var result = _mapper.Map<IList<TEntityDto>>(entities.ToList());
            return result.AsQueryable<TEntityDto>();
        }

        public async Task<TEntityDto> GetAsync(TPrimaryKey id)
        {
            var entity = await _repository.GetAsync(id);
            var result = _mapper.Map<TEntityDto>(entity);
            return result;
        }

        public TEntityDto Insert(TInsertEntityDto entity)
        {
           var entityDb = _mapper.Map<TEntity>(entity); 
           var entityInserted =  _repository.Insert(entityDb);
           var result = _mapper.Map<TEntityDto>(entityInserted);
           return result;
        }

        public async Task<TEntityDto> InsertAsync(TInsertEntityDto entity)
        {
            var entityDb = _mapper.Map<TEntity>(entity); 
           var entityInserted = await _repository.InsertAsync(entityDb);
           var result = _mapper.Map<TEntityDto>(entityInserted);
           return result;
        }

        public TEntityDto InsertOrUpdate(TInsertEntityDto entity)
        {
          var entityDb = _mapper.Map<TEntity>(entity); 
           var entityInserted =  _repository.InsertOrUpdate(entityDb);
           var result = _mapper.Map<TEntityDto>(entityInserted);
           return result;
        }

        public async Task<TEntityDto> InsertOrUpdateAsync(TInsertEntityDto entity)
        {
            var entityDb = _mapper.Map<TEntity>(entity); 
           var entityInserted = await _repository.InsertOrUpdateAsync(entityDb);
           var result = _mapper.Map<TEntityDto>(entityInserted);
           return result;
        }

        public TEntityDto Update(TInsertEntityDto entity)
        {
          var entityDb = _mapper.Map<TEntity>(entity); 
           var entityInserted =  _repository.Update(entityDb);
           var result = _mapper.Map<TEntityDto>(entityInserted);
           return result;
        }

        public async Task<TEntityDto> UpdateAsync(TInsertEntityDto entity)
        {
          var entityDb = await _repository.GetAsync(entity.Id);
           entityDb = _mapper.Map(entity,entityDb); 
           var entityInserted = await _repository.UpdateAsync(entityDb);
           var result = _mapper.Map<TEntityDto>(entityInserted);
           return result;
        }
    }
}