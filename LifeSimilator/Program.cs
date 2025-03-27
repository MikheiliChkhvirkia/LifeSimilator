using System.ComponentModel.Design;
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
                    GetRobbed(character);
                    break;
                case EventsEnum.FoundTreasure:
                    FoundTreasure(character);
                    break;
                case EventsEnum.FoundDateGirl:
                    DateGirl(character);
                    break;
                case EventsEnum.ChangeCareer:
                    ChangeCareer(character);
                    break;  
                case EventsEnum.PayRent:
                    PayRent(character);
                    break;
                case EventsEnum.Invested:
                    Invested(character);
                    break;
                case EventsEnum.BoughtCar:
                    break;
                case EventsEnum.BrokeCar:
                    BrokeCar(character);
                    break;
                default:NothingHappened(character);
                    break;
            }
        }

        private static void NothingHappened(Character character)
        {
            Console.WriteLine("Nothing happened!");
        }

        private static void PayRent(Character character)
        {
            int rent = 5;
            if (character.Money >= rent)
            {
                character.Money -= rent;
                Console.WriteLine($"rent paid: ${rent}");
            }
            else
            {
                Console.WriteLine("could not pay rent! u lost 5 health.");
                character.Health -= 5;
            }

        }

        private static void Invested(Character character)
        {
            Console.WriteLine("do u want to invest $20? (y/n)");
            if (Console.ReadLine() == "y" && character.Money >= 20)
            {
                character.Money -= 20;
                if (random.Next(1, 101) <= 50) 
                {
                    int profite = random.Next(50, 70);
                    character.Money += profite;
                    Console.WriteLine($"great  investment! u earned {profite}");
                }
                else
                {
                    Console.WriteLine("bad investment, uu lost your $20.");
                }
            }
            else
            {
                Console.WriteLine("u either said no or don't have enough money.");
            }

        }

        private static void BrokeCar(Character character)
        {
            int repairCost = random.Next(5, 20);
            if (character.Money >= repairCost)
            {
                character.Money -= repairCost;
                Console.WriteLine($"ur car broke down, repair cost: ${repairCost}");
            }
            else
            {
                character.Health -= 10;
                Console.WriteLine($"couldnt afford repairs. u lost 10 ");
            }

        }

        private static void GotSick(Character character)
        {
            Console.WriteLine("You got sick and choose what u gonna do?");
            Console.WriteLine("go to hospital-1");
            Console.WriteLine("pay for meds-2");
            Console.WriteLine("take rest-3");

            Console.WriteLine("make ur choice by press (1,2,3)");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int cost = random.Next(20, 30);
                if (character.Money > cost) 
                { 
                  
                    character.Money -= cost;
                    Console.WriteLine($"u charged {cost} for hospital but ur healthly ");
                }else 
                 {
                    Console.WriteLine("choose other option u dont have enough money");
                    GotSick(character); 
                 }


            } else if (choice == "2") {

                int cost = random.Next(10, 15);
                if (character.Money >= cost )
                {
                    int damage = random.Next(5, 10);
                    character.Money -= cost;
                    character.Health -= damage;
                    Console.WriteLine($"-{cost} to money");
                    Console.WriteLine($"u was very ill and meds dont fully heal u,therefore u lost{damage}");
                }
                else
                {
                    Console.WriteLine("choose other option u dont have enough money");
                    GotSick(character);
                }
            } else if (choice == "3") {
                int damage = random.Next(10, 15);
                character.Health -=damage;

                Console.WriteLine("u take rest but that dont heal u, take care of ur life");
            }
            else { Console.WriteLine("u make mistake");
                int damage = random.Next(20, 30);
                int moneylost = random.Next(20, 30);
                character.Money -= moneylost;
                character.Health -= damage;
                Console.WriteLine($"u lost{damage}health and {moneylost}money.make correct choice next time by using proper keys");
            }
        }

        private static void ChangeCareer(Character character)
        {
            Console.WriteLine("choose new career: 1) programmer-$20, 2) doctor-$15, 3) TaxiDriver -$10 , 4) WoodCutter-$5 5) unempoyed-$0");
            string jobChoice = Console.ReadLine();
            switch (jobChoice)
            {
                case "1": character.Job = JobEnum.Programmer; break;
                case "2": character.Job = JobEnum.Doctor; break;
                case "3": character.Job = JobEnum.TaxiDriver; break;
                case "4": character.Job = JobEnum.WoodCutter; break;
                case "5": character.Job = JobEnum.Unemployed; break;
                default: Console.WriteLine("choose something else!"); break;
            }

        }

        private static void FoundTreasure(Character character)
        {
            int treasure = random.Next(50, 200);
            character.Money += treasure;
            Console.WriteLine($"u found box full with a money ${treasure}!");

        }

        private static void DateGirl(Character character)
        {

            Console.WriteLine("u met special WOMEN! go on a date? (y/n)");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                character.Health += 15;
                character.Money -= 15;
                Console.WriteLine("date was fun! +15 Health!But ur wealth get -15");
            }
            else
            {
                Console.WriteLine("u missed the opportunity.");
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

        private static void GetRobbed(Character character)
        {
            Console.WriteLine("thieves trying to rob u!!!!!");
            Console.WriteLine("what u gonna do?");
            Console.WriteLine("1 -fight");
            Console.WriteLine("2-try talk");
            Console.WriteLine("3-run");

            Console.WriteLine("enter ur choice as number(1,2,3)");
            string choice = Console.ReadLine();

            int chance = random.Next(1, 101);

            if (choice == "1") {

                if (chance <= 50)
                {
                    int moneytaked = random.Next(20, 40);
                    Console.WriteLine($"u fight like ilia topuria, so u beat him up and take his money {moneytaked} ");
                    character.Money += moneytaked;
                }
                else { int damage = random.Next(15, 25);
                    int moneylost = random.Next(40, 50);
                    character.Health -= damage;
                    character.Money -= moneylost;
                    Console.WriteLine($"ur brave but silly same time. u lost {damage} heald and {moneylost} money. take ur lesson and be more smart next time");

                }
            }
            else if (choice == "2")
            { if (chance <= 40)
                {
                    int moneylost = random.Next(10, 20);
                    character.Money -= moneylost;
                    Console.WriteLine($"ur great talker and because of ur soft skill u lost only{moneylost}");
                }
                else
                {
                    int moneylost = random.Next(50, 70);
                    character.Money -= moneylost;
                    Console.WriteLine($"it was better to be muted. ur poor words make u lost {moneylost}");
                }
            }
            else if (choice == "3")
            {
                if (chance <= 60)
                {
                    Console.WriteLine("u succesfully ran away. ur lil tired but u will be fine");

                }
                else
                {
                    int damage = random.Next(10, 20);
                    int moneylost = random.Next(30, 50);
                    character.Health -= damage;
                    character.Money -= moneylost;
                    Console.WriteLine($"u tired and they cought u. they beat up u for running{damage} and take ur money{moneylost}");

                }
            }
            else
            {
                Console.WriteLine("not right choice baby! thieves took advantage and get violent");
                int moneylost = random.Next(60, 100);
                character.Money -= moneylost;
                Console.WriteLine($"u lost {moneylost}");
            }
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
                        character.Health = 100;
                        character.Money = 200;
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