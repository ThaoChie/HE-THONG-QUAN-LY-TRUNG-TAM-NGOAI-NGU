using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCenterBLL.BUS
{
    public class AttendanceBUS : IAttendanceBUS
    {
        private readonly IAttendanceDAO _dao;
        public AttendanceBUS(IAttendanceDAO dao) { _dao = dao; }

        public Task<List<AttendanceDTO>> GetAttendanceListAsync(int classId) => _dao.GetByClassAsync(classId);

        public Task<bool> AddAttendanceDateAsync(int classId, DateTime date)
        {
            if (date > DateTime.Now.AddDays(1)) throw new Exception("Không thể tạo điểm danh cho tương lai!");
            return _dao.AddDateAsync(classId, date);
        }
        public async Task<bool> SaveAttendanceListAsync(List<AttendanceDTO> listUpdates)
        {
            if (listUpdates == null || listUpdates.Count == 0) return false;
            return await _dao.UpdateBatchAsync(listUpdates);
        }

        public Task<bool> UpdateAttendanceStatusAsync(int attendanceId, bool isPresent) => _dao.UpdateAsync(attendanceId, isPresent);
    }
}
