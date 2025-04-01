using LifeSimilator.Enums;

namespace LifeSimilator.Interfaces
{
    public interface ICarOwned
    {
        public void BuyCar(CarsEnum car);
        public void SetActiveCar(CarsEnum car);
        public void RemoveCar(CarsEnum car);
        public void ShowCars();
    }
}
