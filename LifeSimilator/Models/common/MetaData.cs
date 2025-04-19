namespace LifeSimilator.Models.common
{
    public class MetaData<TEnum> where TEnum : Enum
    {
        public TEnum Type { get; set; }
        public int Price { get; set; }
        public string DisplayName { get; set; }

        public MetaData(TEnum type, int price, string displayName = default)
        {
            Type = type;
            Price = price;
            DisplayName = displayName;
        }
    }
}
