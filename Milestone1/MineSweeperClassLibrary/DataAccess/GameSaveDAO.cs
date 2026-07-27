using MineSweeperClassLibrary.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperClassLibrary.Services.DataAccessLayer
{
    public class GameSaveDAO
    {
        public string SaveGame(
            string fileName,
            SavedGameModel savedGame)
        {
            try
            {
                string json =
                    JsonSerializer.SerializeToString(savedGame);

                File.WriteAllText(fileName, json);

                return "The game was saved successfully.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SavedGameModel LoadGame(string fileName)
        {
            string json = File.ReadAllText(fileName);

            return JsonSerializer
                .DeserializeFromString<SavedGameModel>(json);
        }
    }
}