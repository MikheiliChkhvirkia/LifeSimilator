using System;
private static void BoughtCar()
{
    Console.WriteLine(" Welcome to the Car Market!\nChoose a car to buy:");


    // Display options with prices
    foreach (var car in CarPrices)
    {
        Console.WriteLine($"{(int)car.Key}. {car.Key} - ${car.Value}");
    }

    Console.WriteLine("Enter the number of the car you want to buy:");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int choice) &&
        Enum.IsDefined(typeof(CarsEnum), choice) &&
        choice != 0) // NoCar can't be bought
    {
        CarsEnum selectedCar = (CarsEnum)choice;
        int price = CarPrices[selectedCar];

        if (character.Money >= price)
        {
            character.Money -= price;
            character.AddCar(selectedCar); // You can allow multiple or set a current car
            Console.WriteLine($" You bought a {selectedCar} for ${price}!");
        }
        else
        {
            Console.WriteLine(" Not enough money to buy that car.");
        }
    }
    else
    {
        Console.WriteLine(" Invalid selection.");
    }
}
private static void HouseFire(Character character)
{
    int damage = random.Next(15, 30);
    int moneyLost = random.Next(20, 50);
    character.Health -= damage;
    character.Money -= moneyLost;
    Console.WriteLine($"Your house caught fire! You lost {damage} health and ${moneyLost}.");
}

private static void BrokeCar()
{
    if (character.Car != CarsEnum.NoCar)
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
    else
    {
        NothingHappened();
    }

}

private List<CarsEnum> ownedCars = new();

public IReadOnlyList<CarsEnum> OwnedCars => ownedCars.AsReadOnly();
public CarsEnum CurrentCar { get; private set; } = CarsEnum.NoCar;
                        
public void BuyCar(CarsEnum car)
{
    if (!ownedCars.Contains(car))
    {
        ownedCars.Add(car);
        CurrentCar = car; // optionally auto-equip
    }
}

public void ShowCars()
{
    Console.WriteLine(" Your Cars:");
    foreach (var car in ownedCars)
    {
        Console.WriteLine($"- {car}");
    }

    Console.WriteLine($" Current active car: {CurrentCar}");
}