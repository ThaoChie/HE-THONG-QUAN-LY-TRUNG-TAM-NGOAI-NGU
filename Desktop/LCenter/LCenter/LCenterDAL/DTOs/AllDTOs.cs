using System;
using System.ComponentModel.DataAnnotations; 

namespace LCenterDAL.DTOs
{
    // =============================================================
    // 1. STUDENT (HỌC VIÊN)
    // =============================================================
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Status { get; set; } 
    }

    // DTO tạo mới (Không cần ID)
    public class StudentCreateDTO
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class StudentAcademicDTO : StudentDTO
    {
        public decimal GPA { get; set; }
    }

    // =============================================================
    // 2. USER (GIẢNG VIÊN & ADMIN)
    // =============================================================
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public string RoleName { get; set; }
        public string Specialization { get; set; }

        public bool IsActive { get; set; } 
    
        public string DisplayName => $"{UserId} - {FullName} - {Specialization}";
    }

    // =============================================================
    // 3. COURSE (KHÓA HỌC)
    // =============================================================
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Level { get; set; } 
        public int DurationHours { get; set; }
        public decimal TuitionFee { get; set; }
        public string Description { get; set; }
        public string DisplayName => $"{CourseId} - {CourseName} - {Level}";
    }

    // =============================================================
    // 4. CLASS (LỚP HỌC)
    // =============================================================
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int StudentCount { get; set; }
        public string DisplayName => $"{ClassId} - {ClassName} - {CourseName}";
    }

    public class ClassInputDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }

    // =============================================================
    // 5. ENROLLMENT (GHI DANH)
    // =============================================================
    public class EnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string StudentName { get; set; }
        public string Phone { get; set; }
    }

    // =============================================================
    // 6. SCORE (ĐIỂM SỐ)
    // =============================================================
    public class ScoreDTO
    {
        public int ScoreId { get; set; }
        public int EnrollmentId { get; set; }

        public string StudentName { get; set; }

        public string ScoreType { get; set; } 
        public double ScoreValue { get; set; }
    }

    // =============================================================
    // 7. STATISTIC (THỐNG KÊ DOANH THU)
    // =============================================================
    public class StatisticDTO
    {
        public string CourseName { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    // =============================================================
    //8. ATTENDANCE (Điểm danh)
    // =============================================================

    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int EnrollmentId { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
    }
}