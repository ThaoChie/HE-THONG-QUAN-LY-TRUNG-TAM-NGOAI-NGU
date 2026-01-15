using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{

    public interface ICourseDAO
    {
        Task<List<CourseDTO>> GetAllAsync();
        Task<CourseDTO> GetByIdAsync(int id);
        Task<int> AddAsync(Course c);
        Task<bool> UpdateAsync(Course c);
        Task<bool> DeleteAsync(int id);
    }
}
