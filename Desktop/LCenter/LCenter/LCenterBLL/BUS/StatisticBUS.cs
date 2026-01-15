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
    public class StatisticBUS : IStatisticBUS
    {
        private readonly IStatisticDAO _dao;
        private readonly IStudentDAO _studentDao;

        public StatisticBUS(IStatisticDAO dao, IStudentDAO studentDao)
        {
            _dao = dao;
            _studentDao = studentDao;
        }

        public Task<List<StatisticDTO>> GetCourseRevenueAsync() => _dao.GetStatisticsAsync();

        public Task<List<StudentAcademicDTO>> GetTopStudentsAsync() => _studentDao.GetTopAcademicAsync();

        public Task<int> GetTotalStudentsAsync() => _studentDao.CountAsync();
    }
}
