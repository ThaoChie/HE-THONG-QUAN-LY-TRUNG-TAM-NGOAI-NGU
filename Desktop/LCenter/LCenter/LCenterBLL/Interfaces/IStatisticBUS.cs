using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IStatisticBUS
    {
        Task<List<StudentAcademicDTO>> GetTopStudentsAsync();
        Task<List<StatisticDTO>> GetCourseRevenueAsync();
        Task<int> GetTotalStudentsAsync();
    }
}
