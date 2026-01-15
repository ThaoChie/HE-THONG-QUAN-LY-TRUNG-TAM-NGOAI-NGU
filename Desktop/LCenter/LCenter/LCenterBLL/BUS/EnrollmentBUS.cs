

using LCenterBLL.Interfaces;
using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.BUS
{
    public class EnrollmentBUS : IEnrollmentBUS
    {
        private readonly IEnrollmentDAO _dao;
        private readonly LCenterContext _context;

        public EnrollmentBUS(IEnrollmentDAO dao, LCenterContext context)
        {
            _dao = dao;
            _context = context;
        }

        public Task<List<EnrollmentDTO>> GetStudentsInClassAsync(int classId)
            => _dao.GetByClassAsync(classId);

        public async Task<int> EnrollStudentAsync(int studentId, int classId)
        {
            return await _dao.AddAsync(studentId, classId);
        }

        public Task<bool> RemoveStudentAsync(int enrollmentId) => _dao.DeleteAsync(enrollmentId);

      
        public async Task<string> EnrollStudentsBatchAsync(int classId, List<int> studentIds)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int count = 0;
                    foreach (var sId in studentIds)
                    {
                        await _dao.AddAsync(sId, classId);
                        count++;
                    }

                    await transaction.CommitAsync();
                    return $"Đã thêm thành công {count} học viên vào lớp!";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Lỗi ghi danh lô (đã hoàn tác): " + ex.Message);
                }
            }
        }
    }
}