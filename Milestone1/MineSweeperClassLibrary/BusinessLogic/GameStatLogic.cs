/* Patrick Brewster
 * CST-250
 * Milestone 5
 * Minesweeper Game
 * 7/19/2026
 */
using System.Collections.Generic;
using System.Linq;
using MineSweeperClassLibrary.DataAccess;
using MineSweeperClassLibrary.Models;

namespace MineSweeperClassLibrary.BusinessLogic
{
    public class GameStatLogic
    {
        private readonly GameStatDAO _gameStatDAO;
        private List<GameStat> _gameStats;

        public GameStatLogic()
        {
            _gameStatDAO = new GameStatDAO();
            _gameStats = new List<GameStat>();
        }

        public void AddGameStat(GameStat gameStat)
        {
            gameStat.Id = _gameStats.Count + 1;
            _gameStats.Add(gameStat);
        }

        public List<GameStat> GetGameStats()
        {
            return _gameStats;
        }

        public void SaveGameStats()
        {
            _gameStatDAO.SaveGameStats(_gameStats);
        }

        public void LoadGameStats()
        {
            _gameStats = _gameStatDAO.LoadGameStats();
        }

        public List<GameStat> SortByName()
        {
            return _gameStats
                .OrderBy(gameStat => gameStat.Name)
                .ToList();
        }

        public List<GameStat> SortByScore()
        {
            return _gameStats
                .OrderByDescending(gameStat => gameStat.Score)
                .ToList();
        }

        public List<GameStat> SortByDate()
        {
            return _gameStats
                .OrderByDescending(gameStat => gameStat.GameTime)
                .ToList();
        }
    }
}