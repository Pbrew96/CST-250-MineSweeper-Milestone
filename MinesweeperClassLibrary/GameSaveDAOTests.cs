using MineSweeperClassLibrary.Models;
using MineSweeperClassLibrary.Services.DataAccessLayer;
using Milestone1.MineSweeperClassLibrary.Models;
using Xunit;

namespace MineSweeperTests
{
    public class GameSaveDAOTests
    {
        [Fact]
        public void SaveAndLoadGameRestoresSavedValues()
        {
            // Arrange
            string fileName =
                Path.Combine(
                    Path.GetTempPath(),
                    "minesweeper-test-save.json");

            List<CellModel> cells = new List<CellModel>
            {
                new CellModel
                {
                    Row = 0,
                    Column = 0,
                    IsVisited = true,
                    IsFlagged = false,
                    IsBomb = false,
                    HasSpecialReward = true
                }
            };

            SavedGameModel expectedGame =
                new SavedGameModel(
                    8,
                    3,
                    cells,
                    25,
                    new DateTime(2026, 7, 27, 12, 0, 0),
                    true);

            GameSaveDAO dao = new GameSaveDAO();

            try
            {
                // Act
                string saveMessage =
                    dao.SaveGame(fileName, expectedGame);

                SavedGameModel actualGame =
                    dao.LoadGame(fileName);

                // Assert
                Assert.Equal(
                    "The game was saved successfully.",
                    saveMessage);

                Assert.NotNull(actualGame);
                Assert.Equal(
                    expectedGame.BoardSize,
                    actualGame.BoardSize);

                Assert.Equal(
                    expectedGame.Difficulty,
                    actualGame.Difficulty);

                Assert.Equal(
                    expectedGame.Score,
                    actualGame.Score);

                Assert.Equal(
                    expectedGame.RewardFound,
                    actualGame.RewardFound);

                Assert.Single(actualGame.Cells);
                Assert.True(actualGame.Cells[0].IsVisited);
                Assert.True(actualGame.Cells[0].HasSpecialReward);
                Assert.Equal(expectedGame.StartTime, actualGame.StartTime);

                Assert.Equal(0, actualGame.Cells[0].Row);
                Assert.Equal(0, actualGame.Cells[0].Column);
            }
            finally
            {
                // Clean up the test file
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }
    }
}