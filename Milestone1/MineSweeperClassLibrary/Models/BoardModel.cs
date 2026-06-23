using System;
using System.Collections.Generic;
using System.Text;

namespace Milestone1.MineSweeperClassLibrary.Models
{
    /// <summary>
    /// Represents the Minesweeper game board.
    /// </summary>
    public class BoardModel
    {
        public int Size { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public CellModel[,] Cells { get; set; }
        public int Difficulty { get; set; }
        public int RewardsRemaining { get; set; }
        public GameState GameState { get; set; }

        /// <summary>
        /// Constructor for BoardModel.
        /// </summary>
        public BoardModel(int size)
        {
            Size = size;
            StartTime = DateTime.Now;
            EndTime = DateTime.MinValue;
            Difficulty = 1;
            RewardsRemaining = 0;
            GameState = GameState.StillPlaying;

            Cells = new CellModel[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new CellModel(row, col);
                }
            }
        }
    }
}