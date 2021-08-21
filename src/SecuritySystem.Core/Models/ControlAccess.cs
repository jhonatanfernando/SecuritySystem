using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecuritySystem.Core.Models
{
    public class ControlAccess : ModelBase<long>
    {
        [Required]
        [ForeignKey("Door")]
        public Guid DoorId { get; set; }

        public Door Door { get; set; }
        
        [Required]
        [ForeignKey("KeyCard")]
        public Guid KeyCardId {get; set;}

        public KeyCard KeyCard { get; set; }

        [Required]
        public bool HasAccess { get; set; }
    }
}