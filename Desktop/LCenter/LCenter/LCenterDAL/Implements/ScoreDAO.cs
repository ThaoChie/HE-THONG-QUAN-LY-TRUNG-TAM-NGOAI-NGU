using LCenterDAL.Context;
using LCenterDAL.DTOs;
using LCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Implements
{
    public class ScoreDAO : IScoreDAO
    {
        private readonly LCenterContext _context;
        public ScoreDAO(LCenterContext context) { _context = context; }

        public async Task<List<ScoreDTO>> GetByClassAsync(int classId)
        {
            return await _context.Database.SqlQueryRaw<ScoreDTO>(
                "EXEC sp_Score_GetByClass @ClassId",
                new SqlParameter("@ClassId", classId)
            ).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int scoreId, double value)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Score_Update @ScoreId, @Value",
                new SqlParameter("@ScoreId", scoreId),
                new SqlParameter("@Value", value)
            );
            return rows > 0;
        }

        public async Task<bool> AddScoreTypeToClassAsync(int classId, string scoreType)
        {
            int rows = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Score_AddTypeToClass @ClassId, @ScoreType",
                new SqlParameter("@ClassId", classId),
                new SqlParameter("@ScoreType", scoreType)
            );
            return true;
        }

        public async Task<bool> UpdateManyAsync(List<ScoreDTO> listScores)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var dto in listScores)
                    {
                        await _context.Database.ExecuteSqlRawAsync(
                            "EXEC sp_Score_Update @ScoreId, @ScoreValue",
                            new SqlParameter("@ScoreId", dto.ScoreId),
                            new SqlParameter("@ScoreValue", dto.ScoreValue)
                        );
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw; 
                }
            }
        }

    }
}