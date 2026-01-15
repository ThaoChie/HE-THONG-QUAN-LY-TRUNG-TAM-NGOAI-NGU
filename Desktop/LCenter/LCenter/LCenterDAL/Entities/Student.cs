using System;
using System.ComponentModel.DataAnnotations;

namespace LCenterDAL.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Status { get; set; }
    }
}