using System;
private static void GetRobbed()
{
    Console.WriteLine("Thieves trying to rob u!What u gonna do?\n1 -fight\n2-try talk\3-run\nenter ur choice as number(1,2,3)");

    string choice = Console.ReadLine();

    if (int.TryParse(Console.ReadLine(), out int input) &&
        Enum.IsDefined(typeof(RobberyActionEnum), input))
    {
        RobberyActionEnum action = (RobberyActionEnum)input;

        HandleRobbery(action);
    }
    else
    {
        Console.WriteLine("Invalid input. You stood still. They robbed you.");
        character.Money -= 50;
    }

private static void HandleRobbery(RobberyActionEnum action)
{
    int chance = random.Next(1, 101);

    switch (action)
    {
        case RobberyActionEnum.Fight:
            if (chance <= 50)
            {
                int gain = random.Next(20, 40);
                character.Money += gain;
                Console.WriteLine($"You fight like ilia topuria, so u beat him up and take his money${gain}");
            }
            else
            {
                int loss = random.Next(30, 50);
                character.TakeDamage(15);
                character.Money -= loss;
                Console.WriteLine($"You lost the fight! Lost ${loss} and 15 health.");
            }
            break;

        case RobberyActionEnum.Talk:
            int talkLoss = random.Next(10, 30);
            character.Money -= talkLoss;
            Console.WriteLine($"You tried to talk. Lost ${talkLoss}.");
            break;

        case RobberyActionEnum.Run:
            if (chance <= 60)
            {
                Console.WriteLine("You escaped safely!");
            }
            else
            {
                int runLoss = random.Next(25, 40);
                character.TakeDamage(10);
                character.Money -= runLoss;
                Console.WriteLine($"You failed to escape. Lost ${runLoss} and 10 health.");
            }
            break;
    }
}

private static void PayRent()
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

private static void Invested()
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

private static void LostWallet()
{
    int lostMoney = random.Next(10, 50);
    character.Money -= lostMoney;
    Console.WriteLine($"You lost your wallet containing ${lostMoney}!");
}

private static void FoundTreasure()
{
    int treasure = random.Next(50, 200);
    character.Money += treasure;
    Console.WriteLine($"u found box full with a money ${treasure}!");

}
private static void WonLottery(Character character)
{
    int prize = random.Next(100, 500);
    character.Money += prize;
    Console.WriteLine($"Congratulations! You won the lottery! Prize: ${prize}");
}


