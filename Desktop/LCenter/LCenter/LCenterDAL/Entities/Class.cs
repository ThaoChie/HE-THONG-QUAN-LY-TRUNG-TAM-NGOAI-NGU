using System;
using System.ComponentModel.DataAnnotations;

namespace LCenterDAL.Entities
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}