using System;


private static void AdoptPet(Character character)
{
    int petCost = 30;
    if (character.Money >= petCost)
    {
        character.Money -= petCost;
        character.Health += 20;
        Console.WriteLine($"You adopted a pet! -${petCost} money, +20 Health.");
    }
    else
    {
        Console.WriteLine("You wanted a pet but couldn't afford it. No changes occurred.");
    }
}

private static void FoundNewFriend(Character character)
{
    Console.WriteLine("You met a new friend who taught you how to manage your health better! +10 Health.");
    character.Health += 10;
}

private static void DateGirl()
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