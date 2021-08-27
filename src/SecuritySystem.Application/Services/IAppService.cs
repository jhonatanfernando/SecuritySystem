using System.Threading.Tasks;
using SecuritySystem.Application.Services.Dto;

namespace SecuritySystem.Application.Services
{
    public interface IAppService<TEntityDto, TPrimaryKey> where TEntityDto : IEntityDto<TPrimaryKey>
    {
          Task<TEntityDto> GetAsync(TPrimaryKey id);
          Task<TEntityDto> CreateAsync(TEntityDto entity);
          Task<TEntityDto> UpdateAsync(TEntityDto entity);
          Task<TEntityDto> DeleteAsync(TPrimaryKey id);
          Task<PagedResultDto<TEntityDto>> GetAllAsync(TEntityDto entity);


    }
}