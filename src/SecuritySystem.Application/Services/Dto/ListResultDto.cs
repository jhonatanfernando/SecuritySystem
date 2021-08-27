using System.Collections.Generic;

namespace SecuritySystem.Application.Services.Dto
{
    public class ListResultDto<T> :  IListResult<T> 
    {
        private IReadOnlyList<T> _items;

        public ListResultDto(IReadOnlyList<T> items)
        {
            Items = items;
        }

        public IReadOnlyList<T> Items
        {
            get
            {
                return _items ?? (_items = new List<T>());
            }
            set
            {
                _items = value;
            }
        }
    }
}