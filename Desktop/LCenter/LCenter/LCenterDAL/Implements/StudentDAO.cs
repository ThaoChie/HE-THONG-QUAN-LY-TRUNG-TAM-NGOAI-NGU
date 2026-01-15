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
    public class StudentDAO : IStudentDAO
    {
        private readonly LCenterContext _context;
        public StudentDAO(LCenterContext context) { _context = context; }

        public async Task<List<StudentDTO>> GetAllAsync()
        {
            return await _context.Database.SqlQueryRaw<StudentDTO>("EXEC sp_Student_GetAll").ToListAsync();
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var result = await _context.Database.SqlQueryRaw<StudentDTO>("EXEC sp_Student_GetById @Id", new SqlParameter("@Id", id)).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> AddAsync(Student s)
        {
            var result = await _context.Database.SqlQueryRaw<decimal>(
                "EXEC sp_Student_Insert @FullName, @Phone, @EmaIl, @DateOfBirth",
                new SqlParameter("@FullName", s.FullName),
                new SqlParameter("@Phone", s.Phone),
                new SqlParameter("@Email", s.Email ?? (object)DBNull.Value),
                new SqlParameter("@DateOfBirth", s.DateOfBirth ?? (object)DBNull.Value)
            ).ToListAsync();
            return Convert.ToInt32(result.FirstOrDefault());
        }

        public async Task<bool> UpdateAsync(Student s)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Student_Update @StudentId, @FullName, @Phone, @Email, @DateOfBirth, @Status",
                new SqlParameter("@StudentId", s.StudentId),
                new SqlParameter("@FullName", s.FullName),
                new SqlParameter("@Phone", s.Phone),
                new SqlParameter("@Email", s.Email ?? (object)DBNull.Value),
                new SqlParameter("@DateOfBirth", s.DateOfBirth ?? (object)DBNull.Value),
                new SqlParameter("@Status", s.Status)
            );
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync("EXEC sp_Student_Delete @Id", new SqlParameter("@Id", id));
            return rows > 0;
        }

        public async Task<int> CountAsync()
        {
            var result = await _context.Database.SqlQueryRaw<int>("EXEC sp_Student_Count").ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<List<StudentAcademicDTO>> GetTopAcademicAsync()
        {
            return await _context.Database.SqlQueryRaw<StudentAcademicDTO>("EXEC sp_Student_GetTopAcademic").ToListAsync();
        }
    }
}