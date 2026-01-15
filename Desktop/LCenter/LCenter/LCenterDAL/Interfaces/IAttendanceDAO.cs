using LCenterDAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{
    public interface IAttendanceDAO
    {
        Task<List<AttendanceDTO>> GetByClassAsync(int classId);
        Task<bool> AddDateAsync(int classId, DateTime date);
        Task<bool> UpdateAsync(int attendanceId, bool isPresent);

        Task<bool> UpdateBatchAsync(List<AttendanceDTO> listUpdates);
    }
}
