using System.ComponentModel.DataAnnotations;

namespace LCenterDAL.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Level { get; set; }
        public int DurationHours { get; set; }
        public decimal TuitionFee { get; set; }
        public string Description { get; set; }
    }
}