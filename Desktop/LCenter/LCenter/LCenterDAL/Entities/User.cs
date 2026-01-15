using System.ComponentModel.DataAnnotations;

namespace LCenterDAL.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; } // 'Admin', 'Teacher'
        public bool IsActive { get; set; }

        public string Specialization { get; set; } // Chuyên môn
    }
}