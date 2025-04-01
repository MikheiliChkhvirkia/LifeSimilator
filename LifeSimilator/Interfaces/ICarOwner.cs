using System;

using LifeSimilator.Enums;
using System.Collections.Generic;

namespace LifeSimilator.Interfaces
{
    public interface ICarOwner
    {
        CarsEnum CurrentCar { get; }
        IReadOnlyList<CarsEnum> OwnedCars { get; }

        void BuyCar(CarsEnum car);
        void SetActiveCar(CarsEnum car);
        void ShowCars();
    }
}

