using System.Diagnostics;

namespace LifeSimilator.Enums
{
    public enum CarsEnum
    {
        NoCar,
        Toyota,
        Mercedes ,
        Porsche ,
    }

    public class CarMetaData
    {
        public CarsEnum Type { get; set; }
        public int Price { get; set; }
        public string DisplayName { get; set; }

        public CarMetaData(CarsEnum type, int price, string displayName = default)
        {
            Type = type;
            Price = price;
            DisplayName = displayName;
        }
    }
}
