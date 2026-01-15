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
    public class CourseBUS : ICourseBUS
    {
        private readonly ICourseDAO _dao;
        public CourseBUS(ICourseDAO dao) { _dao = dao; }

        public Task<List<CourseDTO>> GetAllAsync() => _dao.GetAllAsync();

        public async Task<int> AddAsync(CourseDTO dto)
        {
            var entity = new Course
            {
                CourseName = dto.CourseName,
                Level = dto.Level,
                DurationHours = dto.DurationHours,
                TuitionFee = dto.TuitionFee,
                Description = dto.Description
            };
            return await _dao.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(CourseDTO dto)
        {
            var entity = new Course
            {
                CourseId = dto.CourseId,
                CourseName = dto.CourseName,
                Level = dto.Level,
                DurationHours = dto.DurationHours,
                TuitionFee = dto.TuitionFee,
                Description = dto.Description
            };
            return await _dao.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id) => _dao.DeleteAsync(id);
    }
}
