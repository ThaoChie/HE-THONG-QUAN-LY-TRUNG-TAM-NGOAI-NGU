using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class AttendanceDAO : IAttendanceDAO
    {
        private readonly LCenterContext _context;

        public AttendanceDAO(LCenterContext context)
        {
            _context = context;
        }

        public async Task<List<AttendanceDTO>> GetByClassAsync(int classId)
        {
            return await _context.Set<AttendanceDTO>()
                .FromSqlRaw("EXEC sp_Attendance_GetByClass @ClassId",
                            new SqlParameter("@ClassId", classId))
                .ToListAsync();
        }

        public async Task<bool> AddDateAsync(int classId, DateTime date)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Attendance_AddDate @ClassId, @Date",
                new SqlParameter("@ClassId", classId),
                new SqlParameter("@Date", date)
            );
            return true;
        }

        public async Task<bool> UpdateAsync(int attendanceId, bool isPresent)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Attendance_Update @Id, @Status",
                new SqlParameter("@Id", attendanceId),
                new SqlParameter("@Status", isPresent)
            );
            return rows > 0;
        }

        public async Task<bool> UpdateBatchAsync(List<AttendanceDTO> listUpdates)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var item in listUpdates)
                    {
                        await _context.Database.ExecuteSqlRawAsync(
                            "EXEC sp_Attendance_Update @Id, @Status",
                            new SqlParameter("@Id", item.AttendanceId),
                            new SqlParameter("@Status", item.IsPresent)
                        );
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw; 
                }
            }
        }
    }
}
