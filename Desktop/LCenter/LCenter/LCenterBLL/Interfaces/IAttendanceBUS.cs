using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IAttendanceBUS
    {
        Task<List<AttendanceDTO>> GetAttendanceListAsync(int classId);
        Task<bool> AddAttendanceDateAsync(int classId, DateTime date);
        Task<bool> UpdateAttendanceStatusAsync(int attendanceId, bool isPresent);

        Task<bool> SaveAttendanceListAsync(List<AttendanceDTO> listUpdates);
    }
}
