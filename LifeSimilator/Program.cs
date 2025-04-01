using LifeSimilator.Enums;

namespace LifeSimilator
{
    static class Program
    {
        private static Character Character;
        private static Random random = new Random();
        private static bool startGame = true;
        public static void Main()
        {
            StartGame();
        }
        //ToDo:
        // 1) "1" ან "y"/"Y" ნაცვლად შემოიტანე enum.
        //.
        // 3) გამოიდგას interface/abstract კლასები რომელიც იქნება ლოგიკურად აწყობილი (მაგ: IJob, IRobbed ასე შემდეგ)
        // 
        private static void StartGame()
        {
            while (startGame)
            {
                 character = new Character();

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

                    
                    character.TakeDamage(eventCount);
                    Thread.Sleep(1000);
                }

                Console.WriteLine($"\n {character.FirstName} died. Game over.");


                Console.WriteLine($"\n Do you wish to start over.[y/n]");

                if (Console.ReadLine() != "y")
                    startGame = false;
            }
        }

        private static void CheckSurvival()
        {
            if (character.Health <= 0)
            {
                Console.WriteLine("You are Died/Wasted");
                character.IsAlive = false;
            }
        }

        private static void GenerateRandomEvent()
        {

            EventsEnum randomEvent = GetRandomEvent();

            switch (eventType)
            {
                case EventsEnum.PayDay:
                    PayDay();
                    break;
                case EventsEnum.GotSick:
                    GotSick();
                    break;
                case EventsEnum.NothingHappened:
                    NothingHappened();
                    break;
                case EventsEnum.GotRobbed:
                    GetRobbed();
                    break;
                case EventsEnum.FoundTreasure:
                    FoundTreasure();
                    break;
                case EventsEnum.FoundDateGirl:
                    DateGirl();
                    break;
                case EventsEnum.ChangeCareer:
                    ChangeCareer();
                    break;
                case EventsEnum.PayRent:
                    PayRent();
                    break;
                case EventsEnum.Invested:
                    Invested();
                    break;
                case EventsEnum.BoughtCar:
                    BoughtCar();
                    break;
                case EventsEnum.BrokeCar:
                    BrokeCar();
                    break;
                case EventsEnum.AdoptPet:
                    AdoptPet();
                    break;
                case EventsEnum.FoundNewFriend:
                    FoundNewFriend();
                    break;
                case EventsEnum.HadAccident:
                    HadAccident();
                    break;
                case EventsEnum.HouseFire:
                    HouseFire();
                    break;
                case EventsEnum.LearnedNewSkill:
                    LearnedNewSkill();
                    break;
                case EventsEnum.NaturalDisaster:
                    NaturalDisaster();
                    break;
                case EventsEnum.WentOnVacation:
                    WentOnVacation();
                    break;
                case EventsEnum.LostWallet:
                    LostWallet();
                    break;
                case EventsEnum.WonLottery:
                    WonLottery();
                    break;
                default:
                    NothingHappened();
                    break;
            }
        }

        private static void NothingHappened()
        {
            Console.WriteLine("Nothing happened!");
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
            Console.WriteLine($"Car         : {Character.Car}");
            Console.WriteLine("==============================");
        }
    }
}