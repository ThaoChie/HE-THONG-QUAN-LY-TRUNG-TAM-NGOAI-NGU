using System.ComponentModel.DataAnnotations;

namespace LCenterDAL.Entities
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public int EnrollmentId { get; set; }
        public string ScoreType { get; set; }
        public double? ScoreValue { get; set; }
    }
}