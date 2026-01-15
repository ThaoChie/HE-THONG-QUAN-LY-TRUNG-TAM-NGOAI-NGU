using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{
    public interface IStatisticDAO
    {
        Task<List<StatisticDTO>> GetStatisticsAsync();
    }
}