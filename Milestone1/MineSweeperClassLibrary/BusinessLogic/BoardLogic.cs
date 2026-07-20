/* Patrick Brewster
 * CST-250
 * Milestone 5
 * Minesweeper Game
 * 7/19/2026
 */
using Milestone1.MineSweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Milestone1.MineSweeperClassLibrary.BusinessLogic
{
    public class BoardLogic
    {
        private Random _random = new Random();

        /// <summary>
        /// Randomly places bombs on the board.
        /// </summary>
        public void SetupBombs(BoardModel board)
        {
            int bombCount = board.Size;

            if (board.Difficulty == 2)
            {
                bombCount = board.Size * 2;
            }
            else if (board.Difficulty == 3)
            {
                bombCount = board.Size * 3;
            }

            int bombsPlaced = 0;

            while (bombsPlaced < bombCount)
            {
                int row = _random.Next(board.Size);
                int col = _random.Next(board.Size);

                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        /// <summary>
        /// Counts how many bombs are next to each cell.
        /// </summary>
        public void CountBombsNearby(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = 9;
                    }
                    else
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = CountNeighbors(board, row, col);
                    }
                }
            }
        }

        /// <summary>
        /// Counts bombs around one cell.
        /// </summary>
        private int CountNeighbors(BoardModel board, int row, int col)
        {
            int count = 0;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r == row && c == col)
                    {
                        continue;
                    }

                    if (r >= 0 && r < board.Size && c >= 0 && c < board.Size)
                    {
                        if (board.Cells[r, c].IsBomb)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }



        /// <summary>
        /// Placeholder for using a special bonus.
        /// </summary>
        public void UseSpecialBonus(BoardModel board)
        {
            if (board.RewardsRemaining > 0)
            {
                board.RewardsRemaining--;
            }
        }

        /// <summary>
        /// Determines the final score.
        /// </summary>
        public int DetermineFinalScore(BoardModel board)
        {
            TimeSpan timePlayed = DateTime.Now - board.StartTime;
            int score = (board.Size * 100) - (int)timePlayed.TotalSeconds;

            if (score < 0)
            {
                score = 0;
            }

            return score;
        }
        /// <summary>
        /// Determines the game state.
        /// </summary>
        public GameState DetermineGameState(BoardModel board)
        {
            bool allSafeCellsVisited = true;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsBomb && cell.IsVisited)
                    {
                        board.GameState = GameState.GameLost;
                        return GameState.GameLost;
                    }

                    if (!cell.IsBomb && !cell.IsVisited && !cell.IsFlagged)
                    {
                        allSafeCellsVisited = false;
                    }
                }
            }

            if (allSafeCellsVisited)
            {
                board.GameState = GameState.GameWon;
                return GameState.GameWon;
            }

            board.GameState = GameState.StillPlaying;
            return GameState.StillPlaying;
        }
        public void FloodFill(BoardModel board, int row, int col)
        {
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
            {
                return;
            }

            CellModel cell = board.Cells[row, col];

            if (cell.IsVisited || cell.IsFlagged || cell.IsBomb)
            {
                return;
            }

            cell.IsVisited = true;

            if (cell.NumberOfBombNeighbors > 0)
            {
                return;
            }

            FloodFill(board, row - 1, col);
            FloodFill(board, row + 1, col);
            FloodFill(board, row, col - 1);
            FloodFill(board, row, col + 1);
            FloodFill(board, row - 1, col - 1);
            FloodFill(board, row - 1, col + 1);
            FloodFill(board, row + 1, col - 1);
            FloodFill(board, row + 1, col + 1);
        }
        public int CalculateFinalScore(int score, int difficulty)
        {
            return score * difficulty;
        }
    }


}