using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface ICourseBUS
    {
        Task<List<CourseDTO>> GetAllAsync();
        Task<int> AddAsync(CourseDTO dto);
        Task<bool> UpdateAsync(CourseDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

