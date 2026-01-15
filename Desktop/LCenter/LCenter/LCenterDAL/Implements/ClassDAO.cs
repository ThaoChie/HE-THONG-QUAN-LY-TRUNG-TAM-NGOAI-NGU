using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using LCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class ClassDAO : IClassDAO
    {
        private readonly LCenterContext _context;
        public ClassDAO(LCenterContext context) { _context = context; }

        public async Task<List<ClassDTO>> GetAllAsync()
        {
            return await _context.Database.SqlQueryRaw<ClassDTO>("EXEC sp_Class_GetAll").ToListAsync();
        }

        public async Task<ClassDTO> GetByIdAsync(int id)
        {
            var result = await _context.Database.SqlQueryRaw<ClassDTO>("EXEC sp_Class_GetById @Id", new SqlParameter("@Id", id)).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> AddAsync(Class c)
        {
            var result = await _context.Database.SqlQueryRaw<decimal>(
                "EXEC sp_Class_Insert @Name, @Start, @End, @CourseId, @TeacherId",
                new SqlParameter("@Name", c.ClassName),
                new SqlParameter("@Start", c.StartDate),
                new SqlParameter("@End", c.EndDate),
                new SqlParameter("@CourseId", c.CourseId),
                new SqlParameter("@TeacherId", c.TeacherId)
            ).ToListAsync();
            return Convert.ToInt32(result.FirstOrDefault());
        }

        public async Task<bool> UpdateAsync(Class c)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Class_Update @Id, @Name, @Start, @End, @CourseId, @TeacherId",
                new SqlParameter("@Id", c.ClassId),
                new SqlParameter("@Name", c.ClassName),
                new SqlParameter("@Start", c.StartDate),
                new SqlParameter("@End", c.EndDate),
                new SqlParameter("@CourseId", c.CourseId),
                new SqlParameter("@TeacherId", c.TeacherId)
            );
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync("EXEC sp_Class_Delete @Id", new SqlParameter("@Id", id));
            return rows > 0;
        }
    }
}