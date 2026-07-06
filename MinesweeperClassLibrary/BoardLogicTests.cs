using Milestone1.MineSweeperClassLibrary.BusinessLogic;
using Milestone1.MineSweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.Tests
{
    public class BoardLogicTests
    {
        [Fact]
        public void BoardModel_ShouldCreateCorrectSizeBoard()
        {
            BoardModel board = new BoardModel(10);

            Assert.Equal(10, board.Size);
            Assert.Equal(10, board.Cells.GetLength(0));
            Assert.Equal(10, board.Cells.GetLength(1));
        }

        [Fact]
        public void BoardModel_ShouldInitializeCells()
        {
            BoardModel board = new BoardModel(10);

            Assert.NotNull(board.Cells[0, 0]);
            Assert.Equal(0, board.Cells[0, 0].Row);
            Assert.Equal(0, board.Cells[0, 0].Column);
        }

        [Fact]
        public void SetupBombs_ShouldPlaceBombsOnBoard()
        {
            BoardModel board = new BoardModel(10);
            board.Difficulty = 1;

            BoardLogic logic = new BoardLogic();
            logic.SetupBombs(board);

            int bombCount = 0;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        bombCount++;
                    }
                }
            }

            Assert.True(bombCount > 0);
        }

        [Fact]
        public void CountBombsNearby_ShouldSetNeighborCounts()
        {
            BoardModel board = new BoardModel(3);

            board.Cells[0, 0].IsBomb = true;

            BoardLogic logic = new BoardLogic();
            logic.CountBombsNearby(board);

            Assert.Equal(1, board.Cells[0, 1].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[1, 0].NumberOfBombNeighbors);
            Assert.Equal(1, board.Cells[1, 1].NumberOfBombNeighbors);
        }
        [Fact]
        public void FloodFill_ShouldVisitStartingCell()
        {
            BoardModel board = new BoardModel(4);
            BoardLogic logic = new BoardLogic();

            logic.FloodFill(board, 0, 0);

            Assert.True(board.Cells[0, 0].IsVisited);
        }
        [Fact]
        public void FloodFill_ShouldNotVisitBomb()
        {
            BoardModel board = new BoardModel(4);
            BoardLogic logic = new BoardLogic();

            board.Cells[0, 0].IsBomb = true;

            logic.FloodFill(board, 0, 0);

            Assert.False(board.Cells[0, 0].IsVisited);
        }
        [Fact]
        public void FloodFill_ShouldNotVisitFlaggedCell()
        {
            BoardModel board = new BoardModel(4);
            BoardLogic logic = new BoardLogic();

            board.Cells[0, 0].IsFlagged = true;

            logic.FloodFill(board, 0, 0);

            Assert.False(board.Cells[0, 0].IsVisited);
        }
        [Fact]
        public void FloodFill_ShouldStopAtNumberedCell()
        {
            BoardModel board = new BoardModel(4);
            BoardLogic logic = new BoardLogic();

            board.Cells[0, 0].NumberOfBombNeighbors = 1;

            logic.FloodFill(board, 0, 0);

            Assert.True(board.Cells[0, 0].IsVisited);
            Assert.False(board.Cells[0, 1].IsVisited);
        }
        [Fact]
        public void FloodFill_ShouldRevealConnectedEmptyCells()
        {
            BoardModel board = new BoardModel(4);
            BoardLogic logic = new BoardLogic();

            logic.FloodFill(board, 0, 0);

            Assert.True(board.Cells[0, 0].IsVisited);
            Assert.True(board.Cells[0, 1].IsVisited);
            Assert.True(board.Cells[1, 0].IsVisited);
            Assert.True(board.Cells[1, 1].IsVisited);
        }
        [Fact]
        public void FloodFill_ShouldNotCrashWhenOutOfBounds()
        {
            BoardModel board = new BoardModel(4);
            BoardLogic logic = new BoardLogic();

            logic.FloodFill(board, -1, 0);
            logic.FloodFill(board, 0, -1);
            logic.FloodFill(board, 4, 0);
            logic.FloodFill(board, 0, 4);

            Assert.True(true);
        }
    }
}