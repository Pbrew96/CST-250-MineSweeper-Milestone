using MineSweeperClassLibrary.Models;
using Milestone1.MineSweeperClassLibrary.Models;
using Xunit;

namespace MineSweeperTests
{
    public class SavedGameModelTests
    {
        [Fact]
        public void SavedGameModelStoresValuesCorrectly()
        {
            // Arrange
            List<CellModel> cells = new List<CellModel>
            {
                new CellModel
                {
                    Row = 0,
                    Column = 0,
                    IsVisited = true
                }
            };

            // Act
            SavedGameModel savedGame = new SavedGameModel( 8, 2, cells, 15, DateTime.Now,true);

            // Assert
            Assert.Equal(8, savedGame.BoardSize);
            Assert.Equal(2, savedGame.Difficulty);
            Assert.Equal(15, savedGame.Score);
            Assert.True(savedGame.RewardFound);
            Assert.Single(savedGame.Cells);
        }
    }
}