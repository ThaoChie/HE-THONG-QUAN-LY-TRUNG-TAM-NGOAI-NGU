using LCenterBLL.Common;
using LCenterBLL.Interfaces;
using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using LCenterDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCenterBLL.BUS
{
    public class ClassBUS : IClassBUS
    {
        private readonly IClassDAO _dao;
        public ClassBUS(IClassDAO dao) { _dao = dao; }

        public Task<List<ClassDTO>> GetAllAsync() => _dao.GetAllAsync();

        public async Task<int> AddAsync(ClassInputDTO dto)
        {
            if (dto.EndDate < dto.StartDate) throw new Exception("Ngày kết thúc phải sau ngày bắt đầu!");

            var entity = new Class
            {
                ClassName = dto.ClassName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CourseId = dto.CourseId,
                TeacherId = dto.TeacherId
            };
            return await _dao.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(ClassInputDTO dto)
        {
            if (dto.EndDate < dto.StartDate) throw new Exception("Ngày kết thúc phải sau ngày bắt đầu!");

            var entity = new Class
            {
                ClassId = dto.ClassId,
                ClassName = dto.ClassName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CourseId = dto.CourseId,
                TeacherId = dto.TeacherId
            };
            return await _dao.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id) => _dao.DeleteAsync(id);
    }

}