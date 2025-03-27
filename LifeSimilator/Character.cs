using LifeSimilator.Enums;

namespace LifeSimilator
{
    internal class Character : CharacterBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public IList<CarsEnum> Car { get; set; }
        public NationalityEnum Nationality { get; set; }
        public IList<Character> Family { get; set; }
    }

    internal abstract class CharacterBase
    {
        public int Health { get; set; }
        public decimal Money { get; set; }
        public JobEnum Job { get; set; }
        public bool IsAlive { get; set; } = true;
    }
}