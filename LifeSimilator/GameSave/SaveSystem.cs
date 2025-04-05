using System;
using System.IO;
using LifeSimilator.Enums;
using LifeSimilator.SaveLoad;

namespace LifeSimilator.Services
{
    public static class SaveSystem
    {
        private const string FilePath = "savegame.txt";
        private const string HighScorePath = "highscore.txt";

        public static void SaveGame(Character character, int eventCount)
        {
            var lines = new string[]
            {
                character.FirstName,
                character.LastName,
                character.Age.ToString(),
                character.Nationality.ToString(),
                character.Health.ToString(),
                character.Money.ToString(),
                character.Job.ToString(),
                eventCount.ToString(),
                DateTime.Now.ToString("O")
            };

            File.WriteAllLines(FilePath, lines);
            Console.WriteLine(" Game saved.");

            SaveHighScore(eventCount, character);
        }

        public static GameData LoadGame()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine(" No saved game found.");
                return null;
            }

            try
            {
                var lines = File.ReadAllLines(FilePath);

                return new GameData
                {
                    FirstName = lines[0],
                    LastName = lines[1],
                    Age = int.Parse(lines[2]),
                    Nationality = Enum.Parse<NationalityEnum>(lines[3]),
                    Health = int.Parse(lines[4]),
                    Money = decimal.Parse(lines[5]),
                    Job = Enum.Parse<JobEnum>(lines[6]),
                    EventCount = int.Parse(lines[7]),
                    SavedAt = DateTime.Parse(lines[8])
                };

                // ToDo: გამოიტანე მთელი ისტორია რაც არის ან ბოლო 10 მაინც ( Paging / Pagination )
                // 0 - 1
                // 1 - 2
                // ...
                // 9 - 10

                // ToDo: 1,2,3,4 რომ არ იყოს გაწერილი ხელით შექმენი ზოგადი ენამი რომელიც მაგას გამოიყენებს
                // ანუ გავაგზავნით სადამდე უნდა ავიდეს და რეები უნდა დაიწეროს ყოველი ნუმრის გვერდით.
                // შესაბამისად y/n-შეც იგივე

            }
            catch (Exception ex)
            {
                Console.WriteLine($" Failed to load save: {ex.Message}");
                throw;
            }
        }

        public static void SaveHighScore(int currentScore, Character character)
        {
            int bestScore = LoadHighScore();
            if (currentScore > bestScore)
            {
                var lines = new string[]
                {
                    character.FirstName,
                    character.LastName,
                    currentScore.ToString()
                };
                File.WriteAllLines(HighScorePath, lines);
                Console.WriteLine(" New high score saved!");
            }
        }

        public static int LoadHighScore()
        {
            if (!File.Exists(HighScorePath))
                return 0;

            var lines = File.ReadAllLines(HighScorePath);

            return int.TryParse(lines[2], out int score) ? score : 0;
        }
    }
}