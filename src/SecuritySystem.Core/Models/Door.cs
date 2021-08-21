using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecuritySystem.Core.Models
{
    public class Door : ModelBase<Guid>
    {
        [Required]
        public string Name { get; set; }

        public bool IsOpen { get; set; }
    }
}