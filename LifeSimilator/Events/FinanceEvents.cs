using System;
using LifeSimilator.Enums;
using LifeSimilator.Models.ReusableMethods;


namespace LifeSimilator.Events.Generic
{
    public static class FinanceEvents
    {
        private static readonly Random random = new();

        public static void GetRobbed(Character character)
        {
            Console.WriteLine("\nYou're being robbed! What do you do?");

            RobberyActionEnum[] options = (RobberyActionEnum[])Enum.GetValues(typeof(RobberyActionEnum));
            
            Console.Write("Choose (1/2/3): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int actionValue) &&
                Enum.IsDefined(typeof(RobberyActionEnum), actionValue))
            {
                RobberyActionEnum action = (RobberyActionEnum)actionValue;
                HandleRobbery(character, action);
            }
            else
            {
                Console.WriteLine("Invalid input. You stood still. They robbed you for $50.");
                character.Money -= 50;
            }
        }

        private static void HandleRobbery(Character character, RobberyActionEnum action)
        {
            int chance = random.Next(1, 101);

            switch (action)
            {
                case RobberyActionEnum.Fight:
                    if (chance <= 50)
                    {
                        int gain = random.Next(20, 40);
                        character.Money += gain;
                        Console.WriteLine($" You fought back and gained ${gain}!");
                    }
                    else
                    {
                        int loss = random.Next(30, 50);
                        character.TakeDamage(15);
                        character.Money -= loss;
                        Console.WriteLine($" You lost the fight. Lost ${loss} and 15 health.");
                    }
                    break;

                case RobberyActionEnum.Talk:
                    int talkLoss = random.Next(10, 30);
                    character.Money -= talkLoss;
                    Console.WriteLine($" You tried to talk. Lost ${talkLoss}.");
                    break;

                case RobberyActionEnum.Run:
                    if (chance <= 60)
                    {
                        Console.WriteLine(" You escaped safely!");
                    }
                    else
                    {
                        int runLoss = random.Next(25, 40);
                        character.TakeDamage(10);
                        character.Money -= runLoss;
                        Console.WriteLine($" You failed to escape. Lost ${runLoss} and 10 health.");
                    }
                    break;
            }
        }

        public static void PayRent(Character character)
        {
            int rent = 15;
            if (character.Money >= rent)
            {
                character.Money -= rent;
                Console.WriteLine($" Rent paid: -${rent}");
            }
            else
            {
                character.Health -= 10;
                Console.WriteLine(" Couldn't pay rent. You lost 5 health due to stress.");
            }
        }

        public static void Invested(Character character)
        {
            Console.WriteLine(" Do you want to invest $20? (y/n)");
            string input = Console.ReadLine();
            GetYesNoResponse(question);

            if (input?.Trim().ToLower() == "y" && character.Money >= 20)
            {
                character.Money -= 20;

                if (random.Next(1, 101) <= 50)
                {
                    int profit = random.Next(50, 70);
                    character.Money += profit;
                    Console.WriteLine($" Great investment! You earned ${profit}.");
                }
                else
                {
                    Console.WriteLine(" Bad investment. You lost your $20.");
                }
            }
            else
            {
                Console.WriteLine(" You either said no or don't have enough money.");
            }
        }

        public static void LostWallet(Character character)
        {
            int lostMoney = random.Next(10, 40);
            character.Money -= lostMoney;
            Console.WriteLine($" You lost your wallet with ${lostMoney} inside.");
        }

        public static void FoundTreasure(Character character)
        {
            int treasure = random.Next(20, 60);
            character.Money += treasure;
            Console.WriteLine($" You found a mysterious treasure chest with ${treasure} inside!");
        }

        public static void WonLottery(Character character)
        {
            int prize = random.Next(20, 100);
            character.Money += prize;
            Console.WriteLine($" Congratulations! You won the lottery! Prize: ${prize}.");
        }
    }
}