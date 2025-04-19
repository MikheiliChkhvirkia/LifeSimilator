using LifeSimilator.SaveLoad;
using System.Text.Json;

namespace LifeSimilator.Services
{
    public static class SaveSystem
    {
        private const string FilePath = "savegame.json";

        public static void SaveGame(IGameData gameData)
        {
            string json = JsonSerializer.Serialize(gameData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
            Console.WriteLine("Game saved successfully.");
        }

        public static GameData LoadGame()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("No saved game found.");
                return null;
            }

            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<GameData>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load save: {ex.Message}");
                return null;
            }
        }
    }
}