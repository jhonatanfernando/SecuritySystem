using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SecuritySystem.Core.Models
{
    public class MotionSensorActivity : ModelBase<long>
    {
        [Required]
        [ForeignKey("MotionSensor")]
        public Guid MotionSensorId { get; set; }

        public MotionSensor MotionSensor { get; set; }

        [Required]
        public bool IsAlarmTriggered { get; set; }
    }
}