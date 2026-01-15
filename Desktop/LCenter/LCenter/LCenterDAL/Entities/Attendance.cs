using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCenterDAL.Entities
{
    [Table("Attendances")]
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int EnrollmentId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsPresent { get; set; } 

        [ForeignKey("EnrollmentId")]
        public virtual Enrollment Enrollment { get; set; }
    }
}