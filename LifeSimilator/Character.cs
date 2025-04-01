using LifeSimilator.Enums;

namespace LifeSimilator
{
    internal class Character : CharacterBase, ICarOwner, IJob
    {
        private string firstName;
        private string lastName;
        private int age;
        private NationalityEnum nationality;
        private readonly List<CarsEnum> cars = new List<CarsEnum>();
        private readonly List<Character> family = new List<Character>();
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

        public CarsEnum CurrentCar { get; private set; } = CarsEnum.NoCar;

        public void SetActiveCar(CarsEnum car)
        {
            if (cars.Contains(car))
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
        
    }
    internal abstract class CharacterBase
    {

        private bool IsAlive;
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

public interface ICarOwner
{
    // Car system
    private List<CarsEnum> ownedCars = new();
    public IReadOnlyList<CarsEnum> OwnedCars => ownedCars.AsReadOnly();

    public CarsEnum CurrentCar { get; private set; } = CarsEnum.NoCar;

    public void BuyCar(CarsEnum car)
    {
        if (!ownedCars.Contains(car))
        {
            ownedCars.Add(car);
            CurrentCar = car;
            Console.WriteLine($" You bought a {car} and it's now your active car.");
        }
        else
        {
            Console.WriteLine("You already own this car.");
        }
    }

    public void SetActiveCar(CarsEnum car)
    {
        if (ownedCars.Contains(car))
        {
            CurrentCar = car;
            Console.WriteLine($" {car} is now your active car.");
        }
        else
        {
            Console.WriteLine(" You don’t own this car yet.");
        }
    }
    public void RemoveCar(CarsEnum car)
    {
        if (cars.Contains(car))
            cars.Remove(car);
    }

    public void ShowCars()
    {
        Console.WriteLine(" Your Garage:");
        foreach (var car in OwnedCars)
        {
            Console.WriteLine($" {car}");
        }

        Console.WriteLine($" Active Car: {CurrentCar}");
    }
}

public interface IJob
{
    private JobEnum job = JobEnum.Unemployed;

    public JobEnum Job => job;

    public decimal GetSalary()
    {
        return (decimal)job;
    }

    public void ChangeJob(JobEnum newJob)
    {
        if (job != newJob)
        {
            job = newJob;
            Console.WriteLine($"Job changed to: {job}");
        }
        else
        {
            Console.WriteLine("You already have that job!");
        }
    }
}
