using Milestone1.MineSweeperClassLibrary.BusinessLogic;
using MineSweeperClassLibrary.BusinessLogic;
using MineSweeperClassLibrary.Models;

namespace MineSweeperTests
{
    public class GameStatTests
    {
        [Fact]
        public void GameStatConstructor_ShouldSetProperties()
        {
            // Arrange
            DateTime gameTime = DateTime.Now;

            // Act
            GameStat gameStat = new GameStat(
                1,
                "Patrick",
                66,
                gameTime);

            // Assert
            Assert.Equal(1, gameStat.Id);
            Assert.Equal("Patrick", gameStat.Name);
            Assert.Equal(66, gameStat.Score);
            Assert.Equal(gameTime, gameStat.GameTime);
        }

        [Fact]
        public void AddGameStat_ShouldAddScoreToList()
        {
            // Arrange
            GameStatLogic gameStatLogic = new GameStatLogic();

            GameStat gameStat = new GameStat(
                0,
                "Patrick",
                66,
                DateTime.Now);

            int countBefore = gameStatLogic.GetGameStats().Count;

            // Act
            gameStatLogic.AddGameStat(gameStat);

            int countAfter = gameStatLogic.GetGameStats().Count;

            // Assert
            Assert.Equal(countBefore + 1, countAfter);
        }

        [Fact]
        public void SortByName_ShouldSortAlphabetically()
        {
            // Arrange
            GameStatLogic gameStatLogic = new GameStatLogic();

            gameStatLogic.AddGameStat(
                new GameStat(0, "Zach", 20, DateTime.Now));

            gameStatLogic.AddGameStat(
                new GameStat(0, "Patrick", 30, DateTime.Now));

            // Act
            List<GameStat> sortedScores =
                gameStatLogic.SortByName();

            // Assert
            Assert.Equal("Patrick", sortedScores[0].Name);
        }

        [Fact]
        public void SortByScore_ShouldSortHighestScoreFirst()
        {
            // Arrange
            GameStatLogic gameStatLogic = new GameStatLogic();

            gameStatLogic.AddGameStat(
                new GameStat(0, "Patrick", 66, DateTime.Now));

            gameStatLogic.AddGameStat(
                new GameStat(0, "John", 25, DateTime.Now));

            // Act
            List<GameStat> sortedScores =
                gameStatLogic.SortByScore();

            // Assert
            Assert.Equal(66, sortedScores[0].Score);
        }

        [Fact]
        public void SortByDate_ShouldSortNewestDateFirst()
        {
            // Arrange
            GameStatLogic gameStatLogic = new GameStatLogic();

            DateTime olderDate = DateTime.Now.AddDays(-1);
            DateTime newerDate = DateTime.Now;

            gameStatLogic.AddGameStat(
                new GameStat(0, "Patrick", 25, olderDate));

            gameStatLogic.AddGameStat(
                new GameStat(0, "John", 30, newerDate));

            // Act
            List<GameStat> sortedScores =
                gameStatLogic.SortByDate();

            // Assert
            Assert.Equal(newerDate, sortedScores[0].GameTime);
        }
        [Fact]
        public void CalculateFinalScore_HardDifficulty_ShouldReturnTripleScore()
        {
            // Arrange
            BoardLogic boardLogic = new BoardLogic();

            // Act
            int finalScore = boardLogic.CalculateFinalScore(22, 3);

            // Assert
            Assert.Equal(66, finalScore);
        }
    }
}