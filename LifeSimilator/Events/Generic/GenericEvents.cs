using LifeSimilator.Enums;

namespace LifeSimilator.Events.Generic
{
    public static class GenericEvents
    {
        private static Random random = new Random();

        public static EventsEnum GetRandomEvent()
        {
            var lastEvent = Enum.GetValues(typeof(EventsEnum)).Cast<EventsEnum>().Last();
            return (EventsEnum)random.Next((int)EventsEnum.PayDay, (int)lastEvent + 1);
        }

        public static void NothingHappened()
        {
            Console.WriteLine("Nothing happened!");
        }
    }
}
