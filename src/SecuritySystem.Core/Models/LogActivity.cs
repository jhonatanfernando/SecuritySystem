using System;

namespace SecuritySystem.Core.Models
{
    public class LogActivity: ModelBase<long>
    {
        public DateTimeOffset DateTimeEvent { get; set; }
    }
}