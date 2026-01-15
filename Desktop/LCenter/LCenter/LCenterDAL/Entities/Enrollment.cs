using System;
using System.ComponentModel.DataAnnotations;

namespace LCenterDAL.Entities
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}