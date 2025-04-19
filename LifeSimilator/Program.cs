using LifeSimilator.Enums;
using LifeSimilator.Events.Generic;
using LifeSimilator.Models.CarModels;
using LifeSimilator.Models.JobModels;
using LifeSimilator.SaveLoad;
using LifeSimilator.Services;


namespace LifeSimilator
{
    static class Program
    {
        private static Character character;
        private static bool startGame = true;
        private static int eventCount = 0;

        private static Job _job;
        private static Car _car;

        public static void Main()
        {
            SetupGame();
            StartGame();
        }
        private static void SetupGame()
        {
            _job = new Job();
            _car = new Car();
        }

        private static void StartGame()
        {
            character = new Character();

            LoadHistory();

            while (startGame)
            {

                CreateCharacter();

                Console.Clear();
                ShowCharacter();

                Console.WriteLine("JUST Survive if you can!!!!");

                int eventCount = 0;
                while (character.IsAlive)
                {
                    eventCount++;
                    Console.WriteLine($"\n Event {eventCount}");
                    GenerateRandomEvent();

                    Console.WriteLine($" Health: {character.Health}, Money: {character.Money}");
                    CheckSurvival();


                    character.TakeDamage(1);
                    Thread.Sleep(1000);
                }

                Console.WriteLine($"\n {character.FirstName} died after {eventCount} events.");
                character.EventCount = eventCount;
                SaveSystem.SaveGame(character);

                Console.WriteLine($"\n Do you wish to start over.[y/n]");

                if (Console.ReadLine() != "y")
                    startGame = false;

            }
        }

        private static void LoadHistory()
        {
            Console.WriteLine(" Do you want to load your last save? (y/n)");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                var saved = SaveSystem.LoadGame();
                if (saved != null)
                {
                    character.FirstName = saved.FirstName;
                    character.LastName = saved.LastName;
                    character.Age = saved.Age;
                    character.Nationality = saved.Nationality;
                    character.Health = saved.Health;
                    character.Money = saved.Money;
                    character.Job = saved.Job;
                    eventCount = saved.EventCount;

                    Console.WriteLine($" Loaded {character.FirstName}'s save. Survived {eventCount} events.");
                    Console.WriteLine(" Last Play:");
                    Console.WriteLine($"   Name       : {character.FirstName} {character.LastName}");
                    Console.WriteLine($"   Job        : {character.Job}");
                    Console.WriteLine($"   Health     : {character.Health}");
                    Console.WriteLine($"   Money      : ${character.Money}");
                    Console.WriteLine($"   Events     : {eventCount}");

                }
                else
                {
                    Console.WriteLine(" Failed to load save. Starting new game.");
                }
            }
        }



        private static void CheckSurvival()
        {
            if (!character.IsAlive)
            {
                Console.WriteLine("You are Died/Wasted");
            }
        }

        private static void GenerateRandomEvent()
        {
            switch (GenericEvents.GetRandomEvent())
            {
                case EventsEnum.PayDay:
                    _job.PayDay(character);
                    break;
                case EventsEnum.GotSick:
                    LifeEvents.GotSick(character);
                    break;
                case EventsEnum.GotRobbed:
                   FinanceEvents.GetRobbed(character);
                    break;
                case EventsEnum.FoundTreasure:
                   FinanceEvents.FoundTreasure(character);
                    break;
                case EventsEnum.FoundDateGirl:
                   SocialEvents.DateGirl(character);
                    break;
                case EventsEnum.ChangeCareer:
                    _job.ChangeCareer(character);
                    break;
                case EventsEnum.PayRent:
                    FinanceEvents.PayRent(character);
                    break;
                case EventsEnum.Invested:
                    FinanceEvents.Invested(character);
                    break;
                case EventsEnum.BoughtCar:
                    _car.BoughtCar(character);
                    break;
                case EventsEnum.BrokeCar:
                    _car.BrokeCar(character);
                    break;
                case EventsEnum.AdoptPet:
                   SocialEvents.AdoptPet(character);
                    break;
                case EventsEnum.FoundNewFriend:
                    SocialEvents.FoundNewFriend(character);
                    break;
                case EventsEnum.HadAccident:
                    LifeEvents.HadAccident(character);
                    break;
                case EventsEnum.HouseFire:
                    _car.HouseFire(character);
                    break;
                case EventsEnum.LearnedNewSkill:
                    _job.LearnedNewSkill(character);
                    break;
                case EventsEnum.NaturalDisaster:
                    LifeEvents.NaturalDisaster(character);
                    break;
                case EventsEnum.WentOnVacation:
                   LifeEvents.WentOnVacation(character);
                    break;
                case EventsEnum.LostWallet:
                    FinanceEvents.LostWallet(character);
                    break;
                case EventsEnum.WonLottery:
                    FinanceEvents.WonLottery(character);
                    break;
                default:
                    GenericEvents.NothingHappened();
                    break;
            }
        }

        private static void CreateCharacter()
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
            character.Health = 100;
            character.Money = 100;
        }

        private static void ShowCharacter()
        {
            Console.WriteLine("======= Character Info =======");
            Console.WriteLine($"Name        : {character.FirstName} {character.LastName}");
            Console.WriteLine($"Age         : {character.Age}");
            Console.WriteLine($"Nationality : {character.Nationality}");
            Console.WriteLine($"Health      : {character.Health}");
            Console.WriteLine($"Money       : {character.Money}");
            Console.WriteLine($"Job         : {character.Job}");
            Console.WriteLine($"Car         : {character.CurrentCar}");
            Console.WriteLine("==============================");
        }
    }
}