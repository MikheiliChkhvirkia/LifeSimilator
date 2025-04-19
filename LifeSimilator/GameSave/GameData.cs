using LifeSimilator.Enums;

namespace LifeSimilator.SaveLoad
{
    public class GameData : IGameData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public NationalityEnum Nationality { get; set; }
        public int Health { get; set; }
        public decimal Money { get; set; }
        public JobEnum Job { get; set; }
        public int EventCount { get; set; }
        public DateTime SavedAt { get; set; }


        public int Score => EventCount;
    }

    public interface IGameData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public NationalityEnum Nationality { get; set; }
        public int Health { get; set; }
        public decimal Money { get; set; }
        public JobEnum Job { get; set; }
        public int EventCount { get; set; }
    }
}
