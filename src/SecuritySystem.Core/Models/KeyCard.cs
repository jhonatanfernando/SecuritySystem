using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecuritySystem.Core.Models
{
    public class KeyCard :  ModelBase<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}