using System.Collections.Generic;

namespace SecuritySystem.Application.Services.Dto
{
    public interface IListResult<T>
    {
        IReadOnlyList<T> Items {get; set;}
    }
}
