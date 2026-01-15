using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{

    public interface IEnrollmentDAO
    {
        Task<List<EnrollmentDTO>> GetByClassAsync(int classId);
        Task<int> AddAsync(int studentId, int classId);
        Task<bool> DeleteAsync(int enrollmentId);
    }
}
