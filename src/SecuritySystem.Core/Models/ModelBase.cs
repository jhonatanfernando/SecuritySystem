using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecuritySystem.Core.Models
{
    public class ModelBase <T>
    {
        [Key]
        public T Id { get; set; }
    }
}