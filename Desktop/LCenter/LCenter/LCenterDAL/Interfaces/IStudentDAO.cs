using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{
    public interface IStudentDAO
    {
        Task<List<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int id);
        Task<int> AddAsync(Student s);
        Task<bool> UpdateAsync(Student s);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();
        Task<List<StudentAcademicDTO>> GetTopAcademicAsync();
    }
}
