using System;

private static void PayDay()
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

private static void LearnedNewSkill(Character character)
{
    Console.WriteLine("You learned a new skill and got a bonus at work!");
    if (character.Job != JobEnum.Unemployed)
    {
        int bonus = (int)character.Job;
        character.Money += bonus;
        Console.WriteLine($"Your bonus is ${bonus}!");
    }
    else
    {
        Console.WriteLine("Unfortunately, you are unemployed, so no bonus received.");
    }
}

private static void ChangeCareer()
{
    Console.WriteLine("Choose a new job:");
    foreach (JobEnum job in Enum.GetValues(typeof(JobEnum)))
    {
        Console.WriteLine($"{(int)job} - {job} (${(int)job})");
    }

    if (int.TryParse(Console.ReadLine(), out int input) &&
        Enum.IsDefined(typeof(JobEnum), input))
    {
        JobEnum newJob = (JobEnum)input;
        character.ChangeJob(newJob);
    }
    else
    {
        Console.WriteLine(" Invalid job selection.");
    }
}



// ChangeCareer-ში გამოიტანე ის პროფესიები რომელშიც შეუძლია შეცვლა ( ანუ თუ არის ექიმი არ უნდა შეეძლოს ისევ ექიმის არჩევა )