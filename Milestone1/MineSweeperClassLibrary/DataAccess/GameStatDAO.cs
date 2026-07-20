/* Patrick Brewster
 * CST-250
 * Milestone 5
 * Minesweeper Game
 * 7/19/2026
 */
using System;
using System.Collections.Generic;
using System.Text;

using MineSweeperClassLibrary.Models;

namespace MineSweeperClassLibrary.DataAccess
{
    public class GameStatDAO
    {
        // Directory and file information
        private readonly string _fileDirectory;
        private readonly string _filePath;

        public GameStatDAO()
        {
            // Create a Data folder inside the program output folder
            _fileDirectory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data");

            // Create the full path for the game stats file
            _filePath = Path.Combine(
                _fileDirectory,
                "gamestats.txt");

            // Create the Data folder if it does not exist
            CreateDataDirectory();
        }

        /// <summary>
        /// Creates the Data folder if it does not already exist
        /// </summary>
        private void CreateDataDirectory()
        {
            if (!Directory.Exists(_fileDirectory))
            {
                Directory.CreateDirectory(_fileDirectory);
            }
        }

        /// <summary>
        /// Saves the game stats to a text file
        /// </summary>
        /// <param name="gameStats"></param>
        public void SaveGameStats(List<GameStat> gameStats)
        {
            List<string> lines = new List<string>();

            foreach (GameStat gameStat in gameStats)
            {
                string line =
                    $"{gameStat.Id}|" +
                    $"{gameStat.Name}|" +
                    $"{gameStat.Score}|" +
                    $"{gameStat.GameTime}";

                lines.Add(line);
            }

            File.WriteAllLines(_filePath, lines);
        }

        /// <summary>
        /// Loads the game stats from the text file
        /// </summary>
        /// <returns></returns>
        public List<GameStat> LoadGameStats()
        {
            List<GameStat> gameStats = new List<GameStat>();

            // Return an empty list if the file does not exist
            if (!File.Exists(_filePath))
            {
                return gameStats;
            }

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split('|');

                if (values.Length == 4)
                {
                    int id = int.Parse(values[0]);
                    string name = values[1];
                    int score = int.Parse(values[2]);
                    DateTime gameTime = DateTime.Parse(values[3]);

                    GameStat gameStat = new GameStat(
                        id,
                        name,
                        score,
                        gameTime);

                    gameStats.Add(gameStat);
                }
            }

            return gameStats;
        }
    }
}