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
    public class ScoreBUS : IScoreBUS
    {
        private readonly IScoreDAO _dao;
        public ScoreBUS(IScoreDAO dao) { _dao = dao; }

        public Task<List<ScoreDTO>> GetScoreBoardAsync(int classId) => _dao.GetByClassAsync(classId);

        public async Task<bool> UpdateScoreAsync(int scoreId, double value)
        {
            if (value < 0 || value > 10) throw new Exception("Điểm phải từ 0 đến 10");
            return await _dao.UpdateAsync(scoreId, value);
        }

        public async Task<bool> SaveScoreBoardAsync(List<ScoreDTO> listScores)
        {
            if (listScores.Any(s => s.ScoreValue < 0 || s.ScoreValue > 10))
            {
                throw new Exception("Dữ liệu điểm không hợp lệ (Phải từ 0-10).");
            }

            return await _dao.UpdateManyAsync(listScores);
        }

        public async Task<bool> AddNewScoreColumnAsync(int classId, string scoreName)
        {
            if (string.IsNullOrWhiteSpace(scoreName)) throw new Exception("Tên đầu điểm không được để trống!");
            return await _dao.AddScoreTypeToClassAsync(classId, scoreName);
        }
    }
}
