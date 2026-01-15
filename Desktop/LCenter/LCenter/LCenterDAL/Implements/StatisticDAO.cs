using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class StatisticDAO : IStatisticDAO
    {
        private readonly LCenterContext _context;
        public StatisticDAO(LCenterContext context) { _context = context; }

        public async Task<List<StatisticDTO>> GetStatisticsAsync()
        {
            return await _context.Database.SqlQueryRaw<StatisticDTO>("EXEC sp_GetStatistics").ToListAsync();
        }
    }
}