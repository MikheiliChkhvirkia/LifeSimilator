//using System;


//private static void NaturalDisaster(Character character)
//{
//    int damage = random.Next(10, 25);
//    character.Health -= damage;
//    Console.WriteLine($"A natural disaster occurred! You lost {damage} health.");
//}

//private static void WentOnVacation(Character character)
//{
//    int vacationCost = 50;
//    if (character.Money >= vacationCost)
//    {
//        character.Money -= vacationCost;
//        character.Health += 25;
//        Console.WriteLine($"You went on vacation! -${vacationCost}, but +25 Health.");
//    }
//    else
//    {
//        Console.WriteLine("You couldn't afford vacation. You feel stressed (-10 Health).");
//        character.Health -= 10;
//    }
//}

//private static void HadAccident(Character character)
//{
//    int medicalCost = random.Next(20, 60);
//    int injury = random.Next(10, 25);

//    character.Health -= injury;

//    if (character.Money >= medicalCost)
//    {
//        character.Money -= medicalCost;
//        Console.WriteLine($"You had an accident! Lost {injury} health and paid ${medicalCost} medical expenses.");
//    }
//    else
//    {
//        Console.WriteLine($"You had an accident! Lost {injury} health but couldn't pay ${medicalCost} medical expenses. Additional -10 Health penalty.");
//        character.Health -= 10;
//    }
//}

//private static void GotSick()
//{
//    Console.WriteLine(@"You got sick and choose what u gonna do?\ngo to hospital-1\npay for meds-2\ntake rest-3\nmake ur choice by press (1,2,3)");
//    string choice = Console.ReadLine();


//    switch (choice)
//    {
//        case "1":
//            int hospitalCost = random.Next(20, 30);
//            if (character.Money >= hospitalCost)
//            {
//                character.Money -= hospitalCost;
//                Console.WriteLine($"Hospital visit: -${hospitalCost}, you're healthy now.");
//                validChoice = true;
//            }
//            else
//            {
//                Console.WriteLine("Not enough money for hospital.");
//            }
//            break;

//        case "2":
//            int medsCost = random.Next(10, 15);
//            if (character.Money >= medsCost)
//            {
//                int healthLoss = random.Next(5, 10);
//                character.Money -= medsCost;
//                character.Health -= healthLoss;
//                Console.WriteLine($"Meds bought: -${medsCost}, but you lost {healthLoss} health due to incomplete healing.");
//                validChoice = true;
//            }
//            else
//            {
//                Console.WriteLine("Not enough money for meds.");
//            }
//            break;

//        case "3":
//            int restPenalty = random.Next(10, 15);
//            character.Health -= restPenalty;
//            Console.WriteLine($"You rested, but got worse. Lost {restPenalty} health.");
//            validChoice = true;
//            break;

//        default:
//            int penaltyDamage = random.Next(20, 30);
//            int penaltyMoney = random.Next(20, 30);
//            character.Money -= penaltyMoney;
//            character.Health -= penaltyDamage;
//            Console.WriteLine($"Invalid input. You lost {penaltyDamage} health and ${penaltyMoney}.");
//            validChoice = true;
//            break;
//    }
//}
