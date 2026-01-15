using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using LCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class CourseDAO : ICourseDAO
    {
        private readonly LCenterContext _context;
        public CourseDAO(LCenterContext context) { _context = context; }

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            return await _context.Database.SqlQueryRaw<CourseDTO>("EXEC sp_Course_GetAll").ToListAsync();
        }

        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var result = await _context.Database.SqlQueryRaw<CourseDTO>("EXEC sp_Course_GetById @Id", new SqlParameter("@Id", id)).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> AddAsync(Course c)
        {
            var result = await _context.Database.SqlQueryRaw<decimal>(
                "EXEC sp_Course_Insert @Name, @Level, @Duration, @Fee, @Desc",
                new SqlParameter("@Name", c.CourseName),
                new SqlParameter("@Level", c.Level),
                new SqlParameter("@Duration", c.DurationHours),
                new SqlParameter("@Fee", c.TuitionFee),
                new SqlParameter("@Desc", c.Description ?? (object)DBNull.Value)
            ).ToListAsync();
            return Convert.ToInt32(result.FirstOrDefault());
        }

        public async Task<bool> UpdateAsync(Course c)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Course_Update @Id, @Name, @Level, @Duration, @Fee, @Desc",
                new SqlParameter("@Id", c.CourseId),
                new SqlParameter("@Name", c.CourseName),
                new SqlParameter("@Level", c.Level),
                new SqlParameter("@Duration", c.DurationHours),
                new SqlParameter("@Fee", c.TuitionFee),
                new SqlParameter("@Desc", c.Description ?? (object)DBNull.Value)
            );
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync("EXEC sp_Course_Delete @Id", new SqlParameter("@Id", id));
            return rows > 0;
        }
    }
}