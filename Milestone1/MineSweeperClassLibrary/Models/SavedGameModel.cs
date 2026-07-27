using Milestone1.MineSweeperClassLibrary.Models;

namespace MineSweeperClassLibrary.Models
{
    public class SavedGameModel
    {
        public int BoardSize { get; set; }
        public int Difficulty { get; set; }
        public List<CellModel> Cells { get; set; }
        public int Score { get; set; }
        public DateTime StartTime { get; set; }
        public bool RewardFound { get; set; }

        public SavedGameModel()
        {
            Cells = new List<CellModel>();
        }

        public SavedGameModel(
            int boardSize,
            int difficulty,
            List<CellModel> cells,
            int score,
            DateTime startTime,
            bool rewardFound)
        {
            BoardSize = boardSize;
            Difficulty = difficulty;
            Cells = cells;
            Score = score;
            StartTime = startTime;
            RewardFound = rewardFound;
        }
    }
}