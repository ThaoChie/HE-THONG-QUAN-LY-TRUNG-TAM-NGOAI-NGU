using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class EnrollmentDAO : IEnrollmentDAO
    {
        private readonly LCenterContext _context;
        public EnrollmentDAO(LCenterContext context) { _context = context; }

        public async Task<List<EnrollmentDTO>> GetByClassAsync(int classId)
        {
            return await _context.Database.SqlQueryRaw<EnrollmentDTO>(
                "EXEC sp_Enrollment_GetByClass @ClassId",
                new SqlParameter("@ClassId", classId)
            ).ToListAsync();
        }

        public async Task<int> AddAsync(int studentId, int classId)
        {
            var result = await _context.Database.SqlQueryRaw<decimal>(
                "EXEC sp_Enrollment_Insert @StudentId, @ClassId",
                new SqlParameter("@StudentId", studentId),
                new SqlParameter("@ClassId", classId)
            ).ToListAsync();
            return Convert.ToInt32(result.FirstOrDefault());
        }

        public async Task<bool> DeleteAsync(int enrollmentId)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Enrollment_Delete @Id",
                new SqlParameter("@Id", enrollmentId)
            );
            return rows > 0;
        }
    }
}