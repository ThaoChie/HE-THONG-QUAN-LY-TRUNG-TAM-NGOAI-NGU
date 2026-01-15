using LCenterDAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCenterBLL.Interfaces
{
    public interface IScoreBUS
    {
        Task<List<ScoreDTO>> GetScoreBoardAsync(int classId);
        Task<bool> UpdateScoreAsync(int scoreId, double value);
        Task<bool> SaveScoreBoardAsync(List<ScoreDTO> listScores);

        Task<bool> AddNewScoreColumnAsync(int classId, string scoreName);
    }

}