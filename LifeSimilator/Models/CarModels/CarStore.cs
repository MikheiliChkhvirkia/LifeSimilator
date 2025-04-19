using LifeSimilator.Enums;

namespace LifeSimilator.Models.CarModels
{
    public static class CarStore
    {
        public static readonly Dictionary<CarsEnum, CarMetaData> Data = new()
        {
            [CarsEnum.NoCar] = new CarMetaData(CarsEnum.NoCar, 0),
            [CarsEnum.Toyota] = new CarMetaData(CarsEnum.Toyota, 10, "Toyota"),
            [CarsEnum.Mercedes] = new CarMetaData(CarsEnum.Mercedes, 15, "Mercedes"),
            [CarsEnum.Porsche] = new CarMetaData(CarsEnum.Porsche, 20, "Porsche")
        };
    }
}
