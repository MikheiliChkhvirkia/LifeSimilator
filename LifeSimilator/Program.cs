using LifeSimilator.Enums;

namespace LifeSimilator
{
    static class Program
    {
        static Random random = new Random();
        static bool startGame = true;
        public static void Main()
        {
            StartGame();
        }

        private static void StartGame()
        {
            while (startGame)
            {
                var character = new Character();

                CreateCharacter(character);

                Console.Clear();
                ShowCharacter(character);

                Console.WriteLine("JUST Survive if you can!!!!");

                int eventCount = 0;
                while (character.IsAlive)
                {
                    eventCount++;
                    Console.WriteLine($"\n Event {eventCount}");
                    GenerateRandomEvent(character);

                    Console.WriteLine($" Health: {character.Health}, Money: {character.Money}");
                    CheckSurvival(character);

                    Thread.Sleep(1000);
                }

                Console.WriteLine($"\n {character.FirstName} died. Game over.");


                Console.WriteLine($"\n Do you wish to start over.[y/n]");

                if (Console.ReadLine() != "y")
                    startGame = false;
            }
        }

        private static void CheckSurvival(Character character)
        {
            if(character.Health <= 0)
            {
                Console.WriteLine("You are Died/Wasted");
                character.IsAlive = false;
            }
        }

        private static void GenerateRandomEvent(Character character)
        {
            EventsEnum eventType = (EventsEnum)random.Next(1, 4);
            switch (eventType)
            {
                case EventsEnum.PayDay:
                    PayDay(character);
                    break;
                case EventsEnum.GotSick:
                    GotSick(character);
                    break;
                case EventsEnum.NothingHappened:
                    NothingHappened(character);
                    break;
                case EventsEnum.GotRobbed:
                    break;
                case EventsEnum.FoundTreasure:
                    break;
                case EventsEnum.FoundDateGirl:
                    break;
                case EventsEnum.ChangeCareer:
                    break;
                case EventsEnum.PayRent:
                    break;
                case EventsEnum.Invested:
                    break;
                case EventsEnum.BoughtCar:
                    break;
                case EventsEnum.BrokeCar:
                    break;
                default:
                    break;
            }
        }

        private static void NothingHappened(Character character)
        {
            Console.WriteLine("Nothing happened!");
        }

        private static void GotSick(Character character)
        {
            Console.WriteLine("You got sick and paid for medicine!");
            int cost = random.Next(10,36);
            if (character.Money - cost >= 0)
            {
                character.Money -= cost;
                Console.WriteLine($"-{cost} to money");
            }
            else
            {
                character.Health -= random.Next(5, 18);
                Console.WriteLine("You lost health because you don't have money");
            }
        }

        private static void PayDay(Character character)
        {
            if (character.Job == JobEnum.Unemployed)
            {
                Console.WriteLine("You are Unemployed, and you cant get PayDay!");
                return;
            }

            Console.WriteLine("Payday: You got paid for your job.");
            int salary = (int)character.Job;
            character.Money += salary;
            Console.WriteLine($"+{salary} money");
        }

        private static void CreateCharacter(Character character)
        {
            Console.Write("Insert character FirstName: ");
            character.FirstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Insert character LastName: ");
            character.LastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Insert character Age: ");
            character.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Insert character Nationality");
            Console.WriteLine();
            foreach (var nationalityVal in Enum.GetValues<NationalityEnum>())
            {
                Console.WriteLine($"Option {(int)nationalityVal}: Value {nationalityVal}");
            }
            Console.WriteLine();
            Console.Write("Answer Nationality:");
            character.Nationality = (NationalityEnum)Convert.ToInt32(Console.ReadLine());

            character.Job = JobEnum.Unemployed;
            character.Health = 10;
            character.Money = 10;
        }

        private static void ShowCharacter(Character character)
        {
            Console.WriteLine("======= Character Info =======");
            Console.WriteLine($"Name        : {character.FirstName} {character.LastName}");
            Console.WriteLine($"Age         : {character.Age}");
            Console.WriteLine($"Nationality : {character.Nationality}");
            Console.WriteLine($"Health      : {character.Health}");
            Console.WriteLine($"Money       : {character.Money}");
            Console.WriteLine($"Job         : {character.Job}");
            Console.WriteLine("==============================");
        }
    }
}