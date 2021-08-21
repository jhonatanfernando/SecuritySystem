using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SecuritySystem.Core.Models
{
    public class MotionSensor : ModelBase<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}