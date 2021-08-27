using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuritySystem.Application.Services.Dto
{
    public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>
    {

        public PagedResultDto(int totalCount, IReadOnlyList<T> items) : base(items)
        {
            TotalCount = totalCount;
        }
        public int TotalCount {get; set;}

    }
}