using LifeSimilator.Enums;
using LifeSimilator.Interfaces;

namespace LifeSimilator.Models.CarModels
{
    public abstract class CarOwned : ICarOwned
    {
        private List<CarsEnum> _ownedCars = [];

        public List<CarsEnum> OwnedCars => _ownedCars;

        public CarsEnum CurrentCar { get; set; }

        public void BuyCar(CarsEnum car)
        {
            if(!_ownedCars.Contains(car))
            {
                _ownedCars.Add(car);
                CurrentCar = car;
                Console.WriteLine($" You bought a {car} and it's now your active car.");
            }
            else
            {
                Console.WriteLine("You already own this car.");
            }
        }

        public void RemoveCar(CarsEnum car)
        {
            if (_ownedCars.Contains(car))
                _ownedCars.Remove(car);
        }

        public void SetActiveCar(CarsEnum car)
        {
            if (_ownedCars.Contains(car))
            {
                CurrentCar = car;
                Console.WriteLine($" {car} is now your active car.");
            }
            else
            {
                Console.WriteLine(" You don’t own this car yet.");
            }
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
}
