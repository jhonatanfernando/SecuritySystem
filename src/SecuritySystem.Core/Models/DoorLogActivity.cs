using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecuritySystem.Core.Models
{
    public class DoorLogActivity : LogActivity
    {
        [Required]
        public string DoorName { get; set; }

        [Required]
        public string keyCardName { get; set; }

        [Required]
        public bool IsGranted { get; set; }
    }
}