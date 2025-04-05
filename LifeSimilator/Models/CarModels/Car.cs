using LifeSimilator.Enums;
using LifeSimilator.Events.Generic;

namespace LifeSimilator.Models.CarModels
{
    public class Car
    {
        public void BoughtCar(Character character)
        {
            Console.WriteLine(" Welcome to the Car Market!\nChoose a car to buy:");

            // Display options with prices
            foreach (var car in CarStore.Data)
            {
                Console.WriteLine($"{(int)car.Key}. {car.Value.DisplayName} - ${car.Value.Price}");
            }

            Console.WriteLine(" Enter the number of the car you want to buy:");

            if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(CarsEnum), input) && input != 0) // NoCar can't be bought
            {
                var selectedCar = CarStore.Data[(CarsEnum)input];

                if (character.Money >= selectedCar.Price)
                {
                    character.Money -= selectedCar.Price;
                    character.BuyCar(selectedCar.Type);
                    Console.WriteLine($" You bought a {selectedCar.Type} for ${selectedCar.Price}!");
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

        public  void HouseFire(Character character)
        {   var rnd=new Random();   
            int damage = rnd.Next(15, 30);
            int moneyLost = rnd.Next(20, 50);
            character.Health -= damage;
            character.Money -= moneyLost;
            Console.WriteLine($" Your house caught fire! You lost {damage} health and ${moneyLost}.");
        }

        public void BrokeCar(Character character)
        {
            var rnd = new Random();
            if (character.OwnedCars.Count > 0)
            {
                int repairCost = rnd.Next(5, 20);
                int repairCar = rnd.Next(0, character.OwnedCars.Count);

                var selectedCar = character.OwnedCars[repairCar];
                if (character.Money >= repairCost)
                {
                    character.Money -= repairCost;
                    Console.WriteLine($" Your car {selectedCar} broke down, repair cost: ${repairCost}");
                }
                else
                {
                    character.Health -= 10;
                    Console.WriteLine($" Couldn't afford repairs. u lost 10 ");
                }
            }
            else
            {
                GenericEvents.NothingHappened();
            }

        }
    }
}