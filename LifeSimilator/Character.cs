using LifeSimilator.Enums;
using LifeSimilator.Interfaces;
using LifeSimilator.Models.CarModels;
using LifeSimilator.SaveLoad;

namespace LifeSimilator
{
    public class Character : CharacterBase, IJob, IGameData
    {
        private string firstName;
        private string lastName;
        private int age;
        private NationalityEnum nationality;
        private int eventCount;
        private readonly List<CarsEnum> cars = [];
        private readonly List<Character> family = [];
        //public allowing on private info for using 
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public NationalityEnum Nationality
        {
            get => nationality;
            set => nationality = value;
        }

        public int EventCount
        {
            get => eventCount;
            set => eventCount = value;
        }


        public CarsEnum VisibleCar => CurrentCar;

        public void SelectedCarFromGarage(CarsEnum car)
        {
            if (OwnedCars.Contains(car))
                CurrentCar = car;
            else
                Console.WriteLine("You don't own this car.");
        }

        public IReadOnlyList<Character> Family => family.AsReadOnly();

        // methods to safely edit list
        public void AddFamilyMember(Character member)
        {
            if (!family.Contains(member))
                family.Add(member);
        }

        public void RemoveFamilyMember(Character member)
        {
            if (family.Contains(member))
                family.Remove(member);
        }

        public void ChangeJob(JobEnum newJob)
        {
            if (Job != newJob)
            {
                Job = newJob;
                Console.WriteLine($"Job changed to: {Job}");
            }
            else
            {
                Console.WriteLine("You already have that job!");
            }
        }
    }
    public abstract class CharacterBase : CarOwned
    {
        private int health;
        private decimal money;
        private JobEnum job;

        //enkafsulacia
        public int Health
        {
            get => health;
            set => health = value;
        }

        public decimal Money
        {
            get => money;
            set => money = value;
        }

        public JobEnum Job
        {
            get => job;
            set => job = value;
        }

        public bool IsAlive => Health > 0;

        public decimal GetSalary()
        {
            return (decimal)Job;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }

        public void Heal(int amount)
        {
            Health += amount;
        }
    }
}



