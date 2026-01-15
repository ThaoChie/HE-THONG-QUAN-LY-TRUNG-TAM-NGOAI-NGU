using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IEnrollmentBUS
    {
        Task<List<EnrollmentDTO>> GetStudentsInClassAsync(int classId); 
        Task<int> EnrollStudentAsync(int studentId, int classId); 
        Task<bool> RemoveStudentAsync(int enrollmentId);
        Task<string> EnrollStudentsBatchAsync(int classId, List<int> studentIds);
    }
}
