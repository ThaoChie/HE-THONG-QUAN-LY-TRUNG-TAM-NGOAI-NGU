using LCenterBLL.Common;
using LCenterBLL.Interfaces;
using LCenterDAL.Context; 
using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using LCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterBLL.BUS
{
    public class StudentBUS : IStudentBUS
    {
        private readonly IStudentDAO _dao;
        private readonly LCenterContext _context; 

        public StudentBUS(IStudentDAO dao, LCenterContext context)
        {
            _dao = dao;
            _context = context;
        }

        public Task<List<StudentDTO>> GetAllAsync() => _dao.GetAllAsync();

        public Task<StudentDTO> GetByIdAsync(int id) => _dao.GetByIdAsync(id);

        public async Task<int> AddAsync(StudentCreateDTO dto)
        {
            var entity = new Student
            {
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Status = "Đang học"
            };
            return await _dao.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(StudentDTO dto)
        {
            var entity = new Student
            {
                StudentId = dto.StudentId,
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Status = dto.Status
            };
            return await _dao.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id) => _dao.DeleteAsync(id);

        public async Task<StudentDTO> LookupByPhoneAsync(string phone)
        {
            var list = await _dao.GetAllAsync();
            return list.FirstOrDefault(s => s.Phone != null && s.Phone.Trim() == phone.Trim());
        }

        public async Task<string> ImportStudentsBatchAsync(List<StudentDTO> listStudents)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int index = 1;
                    foreach (var sv in listStudents)
                    {
                        if (string.IsNullOrEmpty(sv.FullName))
                            throw new Exception($"Dòng {index}: Tên không được để trống.");

                        if (string.IsNullOrEmpty(sv.Email) || !sv.Email.Contains("@"))
                            throw new Exception($"Dòng {index}: Email không hợp lệ ({sv.Email}).");

                        var entity = new Student
                        {
                            FullName = sv.FullName,
                            Email = sv.Email,
                            Phone = sv.Phone ?? "", 
                            DateOfBirth = sv.DateOfBirth,
                            Status = "Đang học" 
                        };

                        await _dao.AddAsync(entity);

                        index++;
                    }

                    await transaction.CommitAsync();
                    return "Success";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Lỗi nhập lô (đã hoàn tác): " + ex.Message);
                }
            }
        }
    }
}
