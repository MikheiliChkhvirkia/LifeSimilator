using LifeSimilator.Enums;

namespace LifeSimilator.Models.JobModels
{
    public class Job
    {
        public void PayDay(Character character)
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

        public void LearnedNewSkill(Character character)
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

        public void ChangeCareer(Character character)
        {
            Console.WriteLine("Choose a new job:");
            foreach (JobEnum job in Enum.GetValues(typeof(JobEnum)))
            {
                if (job != character.Job)
                    Console.WriteLine($"{(int)job} - {job} (${(int)job})");
            }

            if (int.TryParse(Console.ReadLine(), out int input) &&
                Enum.IsDefined(typeof(JobEnum), input))
            {
                character.ChangeJob((JobEnum)input);
            }
            else
            {
                Console.WriteLine(" Invalid job selection.");
            }
        }
    }
}
