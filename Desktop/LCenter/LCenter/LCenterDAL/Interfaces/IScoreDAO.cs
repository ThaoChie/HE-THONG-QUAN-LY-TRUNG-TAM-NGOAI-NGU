using LCenterDAL.DTOs;
using LCenterDAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterDAL.Interfaces
{

    public interface IScoreDAO
    {
        Task<List<ScoreDTO>> GetByClassAsync(int classId);
        Task<bool> UpdateAsync(int scoreId, double value);

        Task<bool> AddScoreTypeToClassAsync(int classId, string scoreType);
        Task<bool> UpdateManyAsync(List<ScoreDTO> listScores);
    }
}
